using colortv_test_automation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace colortv_test_automation
{
    public partial class Form_Pass_Mes : Form
    {
        public Form_Pass_Mes()
        {
            InitializeComponent();
        }
       
        /// <summary>
        /// todo Clear_SN
        /// </summary>
        /// <returns></returns>
        private bool Clear_SN()
        {
            int sn = Convert.ToInt16(passmes_config_json.PLC_SN_Register)-1;
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    sn = sn + i;
                    PLC.Write(sn.ToString(), Convert.ToInt16(0));
                }
                tb_sn.Text = "";
            }
            catch (Exception ex)
            {
                addmemo("清除SN失败： " + ex);
                return false;
            }
            int type = Convert.ToInt16(passmes_config_json.PLC_Type_Register);
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    type = type + i;
                    PLC.Write(type.ToString(), Convert.ToInt16(0));
                }
                tb_type.Text = "";

            }
            catch (Exception ex)
            {
                addmemo("清除type失败： " + ex);
                return false;
            }
            return true;
        }

        HslCommunication.ModBus.ModbusTcpNet PLC;


       
        /// <summary>
        ///  窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            // 实例化对象，指定PLC的ip地址和端口号
            // HslCommunication.Profinet.Melsec.MelsecMcNet melsecMc = new HslCommunication.Profinet.Melsec.MelsecMcNet("192.168.1.110", 6000);
            // 举例读取D100的值

            //short D100 = melsecMc.ReadInt16("D100").Content;

            //HslCommunication.LogNet.ILogNet logNet = new HslCommunication.LogNet.LogNetDateTime("D:\\Logs", HslCommunication.LogNet.GenerateMode.ByEveryDay);
            //logNet.WriteDebug("Debug log test");
            //logNet.WriteInfo("Info log test");
            //logNet.WriteWarn("Warn log test");
            //logNet.WriteError("Error log test");
            //logNet.WriteFatal("Fatal log test");


            data = new Class_Passmes_Data_V10();
        
            tb_sn.Focus();
            tb_sn.SelectAll();
    

            TextBox.CheckForIllegalCrossThreadCalls = false;

            System.IO.DirectoryInfo di_config = new DirectoryInfo("d:\\软件配置");
            if (di_config.Exists == false) di_config.Create();

            if (File.Exists(passmes_config_json.config_file_path) == false)
            {
                File.Copy("passmes_config.json", passmes_config_json.config_file_path);
                MessageBox.Show("已创建新的配置文件，请根据实际情况更新相关数据。");
            }


            passmes_config_json.config_json_readall();
            cb_ir.Checked = passmes_config_json.F10;
            lb_workstationid.Text = passmes_config_json.Workstationid;
            PLC_IP.Text = passmes_config_json.PLC_IP;
            ShakeHand_OK_Code.Text = passmes_config_json.ShakeHand_OK_Code;
            lb_title.Text = passmes_config_json.Title;
            string path_log = "d:\\logs\\";
            DirectoryInfo di = new DirectoryInfo(path_log);
            if (di.Exists == false) di.Create();


            PLC = new HslCommunication.ModBus.ModbusTcpNet(passmes_config_json.PLC_IP,
                   Convert.ToInt16(passmes_config_json.PLC_Port),
                   Convert.ToByte(passmes_config_json.PLC_Station));

            // Sunisoft.IrisSkin.SkinEngine SkinEngine = new Sunisoft.IrisSkin.SkinEngine(); //加皮肤step1
            // SkinEngine.SkinFile = "DiamondOlive.ssk";//加皮肤step2
            // SkinEngine.Active = true;//加皮肤step3


            timer_plc = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为500毫秒；
            timer_plc.Elapsed += new System.Timers.ElapsedEventHandler(timer_plc_Tick);//到时间的时候执行事件；
          //  timer_plc.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            timer_plc.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件；
            data.WORKSTATIONID = lb_workstationid.Text;
            data.SOFT_VER = tb_SOFT_VER.Text;

        }
  
        /// <summary>
        /// 开始按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            lb_status.Text = "过站运行中";
            string path_log = "d:\\logs\\";
            DirectoryInfo di = new DirectoryInfo(path_log);
            if (di.Exists == false) di.Create();

            logfile = path_log + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";

        

            if (plc_connect() == false)
            {
                lb_status.Text = "PLC连接失败";
                return;
            }

            light_green_on();
            //每1000ms刷新一次当前PLC的值
            timer_plc.Enabled = true;
            //timer_plc_Tick();
            lb_plc_info.Text = "过站中";
        }
   


        /// <summary>
        /// todo wb hw:timer_plc_Tick 间隔读SN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_plc_Tick(object sender, ElapsedEventArgs e)
        {
            timer_plc.Enabled = false;

            plc_read5000();

            if (lb_plc_info.Text == "0")
            {
                lb_plc_info.Text = "工装板未就位";
                timer_plc.Enabled = true;
                return;
                // addmemo(DateTime.Now.ToString()+":工装板未就位");
            }

            if (lb_plc_info.Text == ShakeHand_OK_Code.Text)
            {
                System.Threading.Thread.Sleep(500);
                if (tb_sn.Text == "")
                {
                    addmemo("获取型号和序列号");
                    tb_sn.Text = PLC_Class.Get_TV_SN(PLC);
                    tb_type.Text = PLC_Class.Get_TV_Type(PLC);
                }

                if (tb_sn.Text == "")
                {
                    addmemo("sn获取失败，两秒后重试");
                    System.Threading.Thread.Sleep(2000);
                    tb_sn.Text = PLC_Class.Get_TV_SN(PLC);
                    tb_type.Text = PLC_Class.Get_TV_Type(PLC);
                }

                if (tb_sn.Text == "")
                {
                    addmemo("sn获取失败，两秒后重试");
                    System.Threading.Thread.Sleep(2000);
                    tb_sn.Text = PLC_Class.Get_TV_SN(PLC);
                    tb_type.Text = PLC_Class.Get_TV_Type(PLC);
                }

                if (tb_sn.Text == "")
                {
                    MessageBox.Show("sn获取失败");
                    return;
                }

                addmemo("获取到产品型号：" + tb_type.Text + " SN:" + tb_sn.Text);
                tb_memo.Text = "";
                timer_plc.Enabled = false;
                data.MO = tb_type.Text;
                data.SN = tb_sn.Text;
                data.RESULT = "OK";
                data.调试时间 = DateTime.Now.ToString();

                string json = SendDataToMes.Hw_Data_To_Json(data);
                tb_memo.Text += ("发送到MES:" + json);

                string mesreply = SendDataToMes.SendStr(json);
                data.mesreply = mesreply;
                tb_memo.Text += ("MES回复:" + mesreply);
                if (tb_mesall.Text.Length > 5000) tb_mesall.Text = "";
                tb_mesall.Text += "\r\n" +tb_sn.Text+":"+ mesreply;
                Mysql_Class.InsertDataV20(data);
                addmemo("清除type和sn");
                Clear_SN();
                PLC.Write("5000", Convert.ToInt16(0));
                if (cb_ir.Checked)
                {
                    addmemo("发送红外F10");
                    IR_Send(IR_SendStr_F10);
                }

                addmemo("tv放行");
                tv_letpass();
                addmemo("等待下一台机器到位");
                timer_plc.Enabled = true;
            }
            else {
                timer_plc.Enabled = true;
                ////
            }
        }


        byte[] IR_SendStr_F15 = new byte[] { 0x50, 0xfa, 0x50, 0x01, 0x00, 0x51 };  //1遥控器F15，打开白平衡调试开关
        byte[] IR_SendStr_Factory = new byte[] { 0x50, 0xfa, 0x50, 0x02, 0x00, 0x52 }; //2打开工厂模式
        byte[] IR_SendStr_HDMI = new byte[] { 0x50, 0xfa, 0x50, 0x03, 0x00, 0x53 };  //3
        byte[] IR_SendStr_F10 = new byte[] { 0x50, 0xfa, 0x50, 0x04, 0x00, 0x54 };   //4
       bool  Com_IR_inited = false;

        private void IR_Send(byte[] sendstr)
        {
            if (ir_init() == false) return;
            com_IR.DiscardInBuffer();
            com_IR.DiscardOutBuffer();
            com_IR.Write(sendstr, 0, sendstr.Length);  //发送F15
            addmemo("红外发送成功！");
        }
        /// <summary>
        /// 打开红外遥控器通讯串口
        /// </summary>
        /// <returns></returns>
        private bool ir_init()
        {
            if (Com_IR_inited == false)
            {
                com_IR.PortName=passmes_config_json.com_IR_PortName;
              
                if (com_IR.IsOpen == false)
                {
                    try
                    {
                        com_IR.Open();
                        Com_IR_inited = true;
                        addmemo("红外发射端口打开成功");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        addmemo("红外发射端口打开失败：" + com_IR.PortName + "-" + ex.Message);
                        return false;
                    }
                }
            }
            return true;
        }
        //定时1秒
        //读取PLC控制寄存值  5000 1开始测试
        bool plc_read5000()
        {
            HslCommunication.OperateResult<byte[]> read = PLC.Read(passmes_config_json.PLC_StartTest_Register, 1);
            if (read.IsSuccess)
            {
                short value1 = PLC.ByteTransform.TransInt16(read.Content, 0);
                lb_plc_info.Text = value1.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }




        public bool plc_connnected { get; private set; }
        internal Class_Passmes_Data_V10 data { get; private set; }
        public System.Timers.Timer timer_plc { get; private set; }
        public string logfile { get; private set; }

    
        /// <summary>
        /// addmemo 添加日志
        /// </summary>
        /// <param name="memo"></param>
        private void addmemo(string memo)
        {
            try
            {
                string txt = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] ") + memo + Environment.NewLine;
                tb_memo.AppendText(txt);
                tb_memo.ScrollToCaret();
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(logfile, true);
                sw2.Write(txt);
                sw2.Close();
            }
            catch { }
        }

        /// <summary>
        /// todo TestBegin()开始测试
        /// </summary>
        private void TestBegin()
        {

            System.Threading.Thread.Sleep(200);
            if(tb_sn.Text == "")
            {
                tb_sn.Text = PLC_Class.Get_TV_SN(PLC);
                tb_type.Text = PLC_Class.Get_TV_Type(PLC);
            }

            if  (tb_sn.Text == "")
            {
                addmemo("sn获取失败，两秒后重试");
                System.Threading.Thread.Sleep(2000);
                tb_sn.Text = PLC_Class.Get_TV_SN(PLC);
                tb_type.Text = PLC_Class.Get_TV_Type(PLC);
            }

            if (tb_sn.Text == "")
            {
                addmemo("sn获取失败，两秒后重试");
                System.Threading.Thread.Sleep(2000);
                tb_sn.Text = PLC_Class.Get_TV_SN(PLC);
                tb_type.Text = PLC_Class.Get_TV_Type(PLC);
            }

            if (tb_sn.Text == "")
            {
                MessageBox.Show("sn获取失败");
               
                return;
            }

            addmemo("获取到产品型号："+tb_type.Text+" SN:"+tb_sn.Text);
           // Application.DoEvents();

             //启动测试
            addmemo("开始进行测试");
        
            data = new Class_Passmes_Data_V10();  //保存测试数据的类
            data.MO = tb_type.Text;
            data.SN = tb_sn.Text;
            data.WORKSTATIONID = lb_workstationid.Text;
            data.SOFT_VER = tb_SOFT_VER.Text;
        
        }




        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
 

   


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

   

        bool plc_connect()
        {
            if (plc_connnected == false)
            {
                HslCommunication.OperateResult resut = PLC.ConnectServer();
                if (resut.IsSuccess)
                {
                    plc_connnected = true;
                    addmemo("PLC连接成功！");
                    return true;
                }
                else
                {
                    addmemo("PLC连接失败！");
                    return false;
                }
            }
            return true;
        }
        void light_green_on()
        {
            if (plc_connnected == false) plc_connect();
            PLC.Write(passmes_config_json.PLC_Light_Register, Convert.ToInt16(passmes_config_json.PLC_Light_GREEN));
            PLC.Write(passmes_config_json.PLC_Light_Register, Convert.ToInt16(passmes_config_json.PLC_Light_GREEN));
        }
        /// <summary>
        /// todo 亮红灯
        /// </summary>
        void light_red_on()
        {
            if (plc_connnected == false) plc_connect();
            PLC.Write(passmes_config_json.PLC_Light_Register, Convert.ToInt16(passmes_config_json.PLC_Light_RED));
            PLC.Write(passmes_config_json.PLC_Light_Register, Convert.ToInt16(passmes_config_json.PLC_Light_RED));
        }
        /// <summary>
        /// 亮黄灯
        /// </summary>
        void light_yellow_on()
        {
            if (plc_connnected == false) plc_connect();
            PLC.Write(passmes_config_json.PLC_Light_Register, Convert.ToInt16(passmes_config_json.PLC_Light_YELLOW));
            PLC.Write(passmes_config_json.PLC_Light_Register, Convert.ToInt16(passmes_config_json.PLC_Light_YELLOW));
        }
        /// <summary>
        /// 放行电视
        /// </summary>
        private void tv_letpass()
        {
            adapter_off();
            addmemo("TV 放行(PLCPLC写入：" + passmes_config_json.PLC_LetTVPass_Register + "=" + 1.ToString() + ")");
            PLC.Write(passmes_config_json.PLC_LetTVPass_Register, Convert.ToInt16(1));
        }

        /// <summary>
        /// 合连线夹具
        /// </summary>
        private void adapter_on()
        {
            //4099 4
           // MessageBox.Show(config_json.PLC_Control_Register);
            PLC.Write(passmes_config_json.PLC_Adapter_Register, Convert.ToInt16(4));
        }
        /// <summary>
        /// 松连线夹具
        /// </summary>
        private void adapter_off()
        {
            //4099 5
            PLC.Write(passmes_config_json.PLC_Adapter_Register, Convert.ToInt16(5));
        }


        private void mES测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_pass_check setup = new Form_pass_check();
            setup.ShowDialog();
        }

        private void com_IR_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //休眠100ms等待接收完数据
            System.Threading.Thread.Sleep(100);

            this.Invoke((EventHandler)delegate
            {
                Byte[] receivedData = new Byte[com_IR.BytesToRead]; //创建接收字节数组 
                com_IR.Read(receivedData, 0, receivedData.Length);  //读取数据 

                string showstr;
                showstr = byteToHexStr(receivedData);

                addmemo("红外返回:" + showstr + Environment.NewLine);

            });
        }

        private void btn_ir_send_Click(object sender, EventArgs e)
        {
            //发射回复的最后两位：
            //03 发送成功
            //04 发送失败(通常是没有学习过一次，存储器里面还是空白)
            addmemo("发送红外F10");
            IR_Send(IR_SendStr_F10);
        }

        private void cb_ir_CheckedChanged(object sender, EventArgs e)
        {
            passmes_config_json.save("F10", cb_ir.Checked.ToString());
        }
    }
}
