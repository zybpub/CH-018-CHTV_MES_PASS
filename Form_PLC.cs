using System;
using System.Windows.Forms;

namespace colortv_test_automation
{
    public partial class Form_PLC : Form
    {
        public Form_PLC()
        {
        　　//参考网址 https://www.cnblogs.com/dathlin/p/7782315.html
     　　　 //在Visual Studio 中的NuGet管理器中可以下载安装，
            //也可以直接在NuGet控制台输入下面的指令安装：Install-Package HslCommunication
            InitializeComponent();
        }
        private void Form_PLC_Load(object sender, EventArgs e)
        {
            tbPLC_ip.Text = passmes_config_json.PLC_IP;
            tbPLC_port.Text = passmes_config_json.PLC_Port;
            tbPLC_station.Text = passmes_config_json.PLC_Station;
            tb_control_register.Text = passmes_config_json.PLC_Adapter_Register;
            lb_workstation.Text = passmes_config_json.Workstationid;
            
            tb_light_register.Text = passmes_config_json.PLC_Light_Register;
            tb_sn.Text = passmes_config_json.PLC_SN_Register;
            tb_start_reg.Text = passmes_config_json.PLC_StartTest_Register;
        }

        private HslCommunication.ModBus.ModbusTcpNet PLC;
        private string PLC_ip = "192.168.1.5";
        private int PLC_port = 502;
        private byte PLC_station = 1;
        private bool connected=false;



        private void btn_client_connect_Click(object sender, EventArgs e)
        {
            PLC_ip = tbPLC_ip.Text;
            PLC_port = Convert.ToInt16(tbPLC_port.Text);
            PLC_station = Convert.ToByte(tbPLC_station.Text);

            //在使用读写功能之前必须先进行实例化：
            PLC = new HslCommunication.ModBus.ModbusTcpNet(PLC_ip, PLC_port, PLC_station);   // 站号1
          //  PLC=
           //     new HslCommunication.ModBus.ModbusTcpNet("10.7.141.154", 502, Convert.ToByte(1));
            //上面的实例化指定了服务器的IP地址，端口号（一般都是502），以及自己的站号，允许设置为0-255，
            //后面的两个参数有默认值，在实例化的时候可以省略。

            HslCommunication.OperateResult resut= PLC.ConnectServer();
            if (resut.IsSuccess)
            {
                lb_connect_info.Text = "已成功连接PLC";
                btn_client_connect.Enabled = false;
                btn_client_disconnect.Enabled = true;
                btn_reg_write.Enabled = true;
                btn_reg_read.Enabled = true;
                connected = true;
            }
            else {
                lb_connect_info.Text = "连接PLC失败";
            }
        }



        private void btn_reg_read_Click(object sender, EventArgs e)
        {
            // lb_reg.Text=   PLC.ReadInt16(tb_reg.Text,1).Content.ToString();

            HslCommunication.OperateResult<byte[]> read = PLC.Read(tb_control_register.Text, 1);
            if (read.IsSuccess)
            {
                // 共返回20个字节，每个数据2个字节，高位在前，低位在后
                // 在数据解析前需要知道里面到底存了什么类型的数据，所以需要进行一些假设：
                // 前两个字节是short数据类型
                short value1 = PLC.ByteTransform.TransInt16(read.Content, 0);
                lb_reg.Text = value1.ToString();
                // 接下来的2个字节是ushort类型
                //  ushort value2 = PLC.ByteTransform.TransUInt16(read.Content, 2);
                // 接下来的4个字节是int类型
                //  int value3 = PLC.ByteTransform.TransInt32(read.Content, 4);
                // 接下来的4个字节是float类型
                // string value4 = PLC.ByteTransform.TransString(read.Content, 8,1,Encoding.UTF8);
                // 接下来的全部字节，共8个字节是规格信息
                // string speci = Encoding.ASCII.GetString(read.Content, 12, 8);

                // 已经提取完所有的数据
            }
            else
            {
                MessageBox.Show(read.ToMessageShowString());
            }
        }

        private void btn_reg_write_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);

            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(tb_value.Text));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = "写入成功：" + tb_value.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(2));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = "写入成功：2";
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void config_json_read()
        {
            //读取配置
            try
            {
                System.IO.StreamReader file = System.IO.File.OpenText("config.json");
                Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file);
                Newtonsoft.Json.Linq.JObject jsonObject =
                                (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);
                if (jsonObject["PLC_IP"] != null)
                    tbPLC_ip.Text = (string)jsonObject["PLC_IP"];
                if (jsonObject["PLC_PORT"] != null)
                    tbPLC_port.Text = (string)jsonObject["PLC_PORT"];
                if (jsonObject["PLC_STATION"] != null)
                    tbPLC_station.Text = (string)jsonObject["PLC_STATION"];
                if (jsonObject["PLC_REGISTER"] != null)
                    tb_control_register.Text = (string)jsonObject["PLC_REGISTER"];
                file.Close();
            }
            catch
            {
                //MessageBox.Show("CAN卡配置有误！");
            }
        }

        private void config_json_save()
        {
            try
            {
                string json = System.IO.File.ReadAllText("config.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj["PLC_IP"] = tbPLC_ip.Text;
                jsonObj["PLC_PORT"] = tbPLC_port.Text;
                jsonObj["PLC_STATION"] = tbPLC_station.Text;
                jsonObj["PLC_REGISTER"] = tb_control_register.Text;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText("config.json", output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置文件有误：" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write("4097", Convert.ToInt16(1));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = "4097写入成功：1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(4));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = "写入成功：4";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(5));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = "写入成功：5";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(2));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = tb_control_register.Text + "已写入：2";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(3));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = tb_control_register.Text + "已写入：3";
            }
        }

        private void btn_write1_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(1));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = tb_control_register.Text +"已写入：1";
            }
        }

        private void btn_write3_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_control_register.Text, Convert.ToInt16(3));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = tb_control_register.Text + "已写入：3";
            }
        }

        private void btn_light1_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_light_register.Text, Convert.ToInt16(1));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = tb_light_register.Text + "已写入：3";
            }
        }

        private void btn_light2_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_light_register.Text, Convert.ToInt16(2));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = tb_light_register.Text + "已写入：3";
            }
        }

        private void btn_light3_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);
            HslCommunication.OperateResult result = PLC.Write(tb_light_register.Text, Convert.ToInt16(3));
            if (result.IsSuccess)
            {
                lb_reg_write_message.Text = tb_light_register.Text + "已写入：3";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (connected == false) btn_client_connect_Click(null, null);

            HslCommunication.OperateResult result = PLC.Write(tb_start_reg.Text, Convert.ToInt16(tb_startregvalue.Text));
            if (result.IsSuccess)
            {
                lb_start.Text = "写入成功：" + tb_startregvalue.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HslCommunication.OperateResult<byte[]> read = PLC.Read(tb_start_reg.Text, 1);
            if (read.IsSuccess)
            {
                short value1 = PLC.ByteTransform.TransInt16(read.Content, 0);
                lb_start.Text = value1.ToString();
            }
            else
            {
                MessageBox.Show(read.ToMessageShowString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (connected == false) btn_client_connect_Click(null, null);

            HslCommunication.OperateResult result = PLC.Write(tb_sn.Text, tb_snvalue.Text);
            if (result.IsSuccess)
            {
                lb_sn.Text = tb_sn.Text+"写入成功：" + tb_snvalue.Text;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HslCommunication.OperateResult<byte[]> read = PLC.Read(tb_sn.Text, 50);
            if (read.IsSuccess)
            {
                short value1 = PLC.ByteTransform.TransInt16(read.Content, 50);
                lb_sn.Text = tb_sn.Text+"读取值："+ value1.ToString();
            }
            else
            {
                MessageBox.Show(read.ToMessageShowString());
            }
        }
    }
}
