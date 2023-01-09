using System;

namespace colortv_test_automation
{
    class passmes_config_json
    {
        public passmes_config_json() {
        }
        #region 变量
        public static string Ver="V20200101";

        public static string pass = "QWQ/r3FGnyU=";   //999
        public static string config_file_path = "d:\\软件配置\\passmes_config.json";

        public static bool AUTO_RUN;            //是否运行程序后自动开始测试
        public static string MES_URL = "http://10.52.88.17:8080/N2/http/interface.ms?model=IntoScgz&method=intoScgzSaveInfo";

        public static string TV_IP="192.168.1.101";
        public static string TV_Port="9100";

        public static string CA410_PortName;           //CA410串口端口号
        public static string CA410_BaudRate ;           //CA410串口波特率
        public static string CA410_DataBits;           //CA410串口数据位

        public static bool PLC_Used = true;    //是否启用数据库
        public static string PLC_IP;              //PLC IP地址
        public static string PLC_Port = "502";             //PLC 端口 默认：502
        public static string PLC_Station = "1";             //PLC 站号  默认：1
        public static string PLC_StartTest_Register = "5000";   //PLC控制是否测试可以开始 0不测试 1 测试
        public static string PLC_LetTVPass_Register = "5001";
        public static string PLC_Type_Register = "5002";
        public static string PLC_SN_Register = "5022";    //PLC读取sn地址
        public static string PLC_Adapter_Register = "4099";
        public static string PLC_Light_Register = "4119";     //PLC红绿黄灯控制寄存器地址
        public static string PLC_Light_GREEN = "1";
        public static string PLC_Light_RED = "2";
        public static string PLC_Light_YELLOW = "3";
        public static string ShakeHand_OK_Code = "2";  //启动测试信号值

        public static bool mysql_used;    //是否启用数据库
        public static string Mysql_IP;       //Mysql IP 地址
        public static string Mysql_Port;      //Mysql 端口号
        public static string Mysql_User;      //Mysql 用户名 需要有写入权限
        public static string Mysql_Pass;      //Mysql 密码
        public static string mysql_database_name;  //数据库名


        public static string sn_filename="d:\\sn.txt";      //gamma测试sn写入文件名
        public static string result_filename = "d:\\result.txt";    //gamma测试结果读取文件名

        public static bool retryafterfail;
        public static bool stopafterfail;
        public static bool sendresulttomes;
        public static object prefailstomes = true;
        public static bool debug;

        public static string TestChannel { get; internal set; }
        public static string Workstationid;
        public static bool sendtomes { get; private set; }
        public static string SOFT_VER { get; internal set; }
        public static string Title { get; private set; }
        public static string com_IR_PortName { get; internal set; }
        public static bool F10 { get; private set; }

        #endregion
        public static bool save(string key,string value) {
            try
            {
                string json = System.IO.File.ReadAllText(config_file_path);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj[key] =value;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(config_file_path, output);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static bool config_json_readall()
        {
            System.IO.StreamReader file = System.IO.File.OpenText(config_file_path);
            Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file);
            Newtonsoft.Json.Linq.JObject jsonObject =
                            (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);

            if (jsonObject["Workstationid"] != null) Workstationid = (string)jsonObject["Workstationid"];
            if (jsonObject["SOFT_VER"] != null) SOFT_VER = (string)jsonObject["SOFT_VER"];
            if (jsonObject["Title"] != null) Title = (string)jsonObject["Title"];

            if (jsonObject["AUTO_RUN"] != null) AUTO_RUN = (bool)jsonObject["AUTO_RUN"];


            if (jsonObject["PLC_IP"] != null) PLC_IP = (string)jsonObject["PLC_IP"];
            if (jsonObject["PLC_Port"] != null) PLC_Port = (string)jsonObject["PLC_Port"];
            if (jsonObject["PLC_Station"] != null) PLC_Station = (string)jsonObject["PLC_Station"];
            if (jsonObject["PLC_LetTVPass_Register"] != null) PLC_LetTVPass_Register = (string)jsonObject["PLC_LetTVPass_Register"];  //产品放行地址
            if (jsonObject["PLC_Adapter_Register"] != null) PLC_Adapter_Register = (string)jsonObject["PLC_Adapter_Register"];
            if (jsonObject["PLC_Light_Register"] != null) PLC_Light_Register = (string)jsonObject["PLC_Light_Register"];
            if (jsonObject["PLC_Light_GREEN"] != null) PLC_Light_GREEN = (string)jsonObject["PLC_Light_GREEN"];
            if (jsonObject["PLC_Light_RED"] != null) PLC_Light_RED = (string)jsonObject["PLC_Light_RED"];
            if (jsonObject["PLC_Light_YELLOW"] != null) PLC_Light_YELLOW = (string)jsonObject["PLC_Light_YELLOW"];
            if (jsonObject["PLC_Type_Register"] != null) PLC_Type_Register = (string)jsonObject["PLC_Type_Register"];
            if (jsonObject["PLC_SN_Register"] != null) PLC_SN_Register = (string)jsonObject["PLC_SN_Register"];
            if (jsonObject["PLC_StartTest_Register"] != null) PLC_StartTest_Register = (string)jsonObject["PLC_StartTest_Register"];
            if (jsonObject["ShakeHand_OK_Code"] != null) ShakeHand_OK_Code = (string)jsonObject["ShakeHand_OK_Code"];

            if (jsonObject["mysql_used"] != null) mysql_used = (bool)jsonObject["mysql_used"];
            if (jsonObject["Mysql_IP"] != null) Mysql_IP = (string)jsonObject["Mysql_IP"];
            if (jsonObject["Mysql_Port"] != null) Mysql_Port = (string)jsonObject["Mysql_Port"];
            if (jsonObject["Mysql_User"] != null) Mysql_User = (string)jsonObject["Mysql_User"];
            if (jsonObject["Mysql_Pass"] != null) Mysql_Pass = (string)jsonObject["Mysql_Pass"];
            if (jsonObject["mysql_database_name"] != null) mysql_database_name = (string)jsonObject["mysql_database_name"];
            if (jsonObject["com_IR_PortName"] != null) com_IR_PortName = (string)jsonObject["com_IR_PortName"];

            if (jsonObject["F10"] != null) F10 = (bool)jsonObject["F10"];

            file.Close();

            return true;
        }
      
        /// <summary>
        /// 读取指定键名的值
        /// </summary>
        /// <param name="key">输入要获取值的键名</param>
        /// <returns></returns>
        public static string config_json_read(string workstation,string key)
        {
            string result = "";
            try
            {
                System.IO.StreamReader file = System.IO.File.OpenText(workstation+".json");
                Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file);
                Newtonsoft.Json.Linq.JObject jsonObject =
                                (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);
                if (jsonObject[key] != null)
                    result = (string)jsonObject[key];
                file.Close();
            }
            catch { }
            return result;
        }
    }
}


/*
passmes_config.json 示例文件
 
{
  "SOFT_VER": "V1.0",
  "Workstationid": "HC1-BPHTS",
  "Mysql_IP": "127.0.0.1",
  "Mysql_Port": "3306",
  "Mysql_User": "root",
  "Mysql_Pass": "jczx",
  "mysql_database_name": "jczx_mysql_db",
  "mysql_table_name": "hw_colorgamut_data",
  "mysql_used": "True",
  "PLC_Used": "True",
  "PLC_IP": "10.52.105.128",
  "PLC_Port": "502",
  "PLC_Station": "1",
  "PLC_LetTVPass_Register": "5001",
  "PLC_Adapter_Register": "4099",
  "PLC_Light_Register": "4119",
  "PLC_Light_GREEN": "2",
  "PLC_Light_RED": "1",
  "PLC_Light_YELLOW": "3",
  "PLC_Type_Register": "5002",
  "PLC_SN_Register": "5020",
  "PLC_StartTest_Register": "5000",
  "ShakeHand_OK_Code": "1",
  "MES_URL": "http://10.52.88.17:8080/N2/http/interface.ms?model=IntoScgz&method=intoScgzSaveInfo",
  "pass": "QWQ/r3FGnyU=",
  "Title": "本机型不调白平衡"
}
     
     
     */
