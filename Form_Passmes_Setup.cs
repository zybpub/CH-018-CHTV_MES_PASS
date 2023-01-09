using System;
using System.Windows.Forms;

namespace colortv_test_automation
{


    public partial class Form_Passmes_Setup : Form
    {
       

        public Form_Passmes_Setup()
        {
            InitializeComponent();
        }

        string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "param/config.ini");//在当前程序路径创建
        private void Form_Gamma_Setup_Load(object sender, EventArgs e)
        {
            passmes_config_json.config_json_readall();

            tb_SOFT_VER.Text = passmes_config_json.SOFT_VER;
            tb_workstationids.Text = passmes_config_json.Workstationid;
            Title.Text = passmes_config_json.Title;


            ShakeHand_OK_Code.Text = passmes_config_json.ShakeHand_OK_Code;

            cb_mysql_used.Checked = (bool)passmes_config_json.mysql_used;
            Mysql_IP.Text = passmes_config_json.Mysql_IP;
            Mysql_Port.Text = passmes_config_json.Mysql_Port;
            Mysql_User.Text = passmes_config_json.Mysql_User;
            Mysql_Pass.Text = passmes_config_json.Mysql_Pass;
            mysql_database_name.Text = passmes_config_json.mysql_database_name;

            PLC_Used.Checked = (bool)passmes_config_json.PLC_Used;
            PLC_IP.Text = passmes_config_json.PLC_IP;
            PLC_Port.Text = passmes_config_json.PLC_Port;
            PLC_Station.Text = passmes_config_json.PLC_Station;
            PLC_LetTVPass_Register.Text = passmes_config_json.PLC_LetTVPass_Register;
            PLC_Light_Register.Text = passmes_config_json.PLC_Light_Register;
            PLC_Adapter_Register.Text = passmes_config_json.PLC_Adapter_Register;
            PLC_Light_GREEN.Text = passmes_config_json.PLC_Light_GREEN;
            PLC_Light_RED.Text = passmes_config_json.PLC_Light_RED;
            PLC_Light_YELLOW.Text = passmes_config_json.PLC_Light_YELLOW;
            PLC_Type_Register.Text = passmes_config_json.PLC_Type_Register;
            PLC_SN_Register.Text = passmes_config_json.PLC_SN_Register;
            PLC_StartTest_Register.Text = passmes_config_json.PLC_StartTest_Register;

          

            pass.Text = Encrypt.DES.DesDecrypt(passmes_config_json.pass);
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称
            {
                cbb_IR.Items.Add(com);
            }
            try { cbb_IR.Text = passmes_config_json.com_IR_PortName; } catch { }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string json = System.IO.File.ReadAllText(passmes_config_json.config_file_path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            jsonObj["Workstationid"] = tb_workstationids.Text;
            jsonObj["SOFT_VER"] = tb_SOFT_VER.Text;
              jsonObj["Title"] = Title.Text;
            
            jsonObj["Mysql_IP"] = Mysql_IP.Text;
            jsonObj["Mysql_IP"] = Mysql_IP.Text;
            jsonObj["Mysql_Port"] = Mysql_Port.Text;
            jsonObj["Mysql_User"] = Mysql_User.Text;
            jsonObj["Mysql_Pass"] = Mysql_Pass.Text;
            jsonObj["mysql_database_name"] = mysql_database_name.Text;
            jsonObj["mysql_table_name"] = tb_mysql_table_name.Text;
            jsonObj["mysql_used"] = cb_mysql_used.Checked.ToString();

            jsonObj["PLC_Used"] = PLC_Used.Checked.ToString();
            jsonObj["PLC_IP"] = PLC_IP.Text;
            jsonObj["PLC_IP"] = PLC_IP.Text;
            jsonObj["PLC_Port"] = PLC_Port.Text;
            jsonObj["PLC_Station"] = PLC_Station.Text;
            jsonObj["PLC_LetTVPass_Register"] = PLC_LetTVPass_Register.Text;
            jsonObj["PLC_Adapter_Register"] = PLC_Adapter_Register.Text;
            jsonObj["PLC_Light_Register"] = PLC_Light_Register.Text;
            jsonObj["PLC_Light_GREEN"] = PLC_Light_GREEN.Text;
            jsonObj["PLC_Light_RED"] = PLC_Light_RED.Text;
            jsonObj["PLC_Light_YELLOW"] = PLC_Light_YELLOW.Text;
            jsonObj["PLC_Type_Register"] = PLC_Type_Register.Text;
            jsonObj["PLC_SN_Register"] = PLC_SN_Register.Text;
            jsonObj["PLC_StartTest_Register"] = PLC_StartTest_Register.Text;
            jsonObj["ShakeHand_OK_Code"] = ShakeHand_OK_Code.Text;

            jsonObj["com_IR_PortName"] = cbb_IR.Text;
           
            jsonObj["MES_URL"] = tb_mesurl.Text;

            jsonObj["pass"] = Encrypt.DES.DesEncrypt(pass.Text);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(passmes_config_json.config_file_path, output);
            passmes_config_json.config_json_readall();

         
            MessageBox.Show("保存成功！");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
