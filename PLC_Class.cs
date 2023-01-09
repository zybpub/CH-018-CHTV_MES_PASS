using HslCommunication.ModBus;
using System;

namespace colortv_test_automation
{
    class PLC_Class
    {

        public static HslCommunication.ModBus.ModbusTcpNet get_ModbusTcpNet()
        {
            HslCommunication.ModBus.ModbusTcpNet ModbusTcpNet1 =
                new HslCommunication.ModBus.ModbusTcpNet(passmes_config_json.PLC_IP,
                   Convert.ToInt16(passmes_config_json.PLC_Port),
                   Convert.ToByte(passmes_config_json.PLC_Station));
            
            return ModbusTcpNet1;
        }

        public bool light_set_green() {
            HslCommunication.ModBus.ModbusTcpNet PLC = PLC_Class.get_ModbusTcpNet();

            return true;
        }

        /// <summary>
        /// 获取电视机SN，读取PLC寄存器5022~5071
        /// </summary>
       
        public static string Get_TV_SN(ModbusTcpNet PLC)
        {
            String[] TV_SN = new String[50];
            int plc_reg = 5022;
            HslCommunication.OperateResult<byte[]> read = PLC.Read("5021", 1);

            if (read.IsSuccess)
            {
                for (int i = 0; i < 50; i++)
                {
                    HslCommunication.OperateResult<byte[]> reg_value = PLC.Read(Convert.ToString(plc_reg + i), 1);

                    short value = PLC.ByteTransform.TransInt16(reg_value.Content, 0);

                    TV_SN[i] = AsciiToStr(value);
                }
                return string.Join("", TV_SN);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取电视机机型信息，读取PLC寄存器5002~5021
        /// </summary>

        public static string Get_TV_Type(ModbusTcpNet PLC)
        {
            string plc_reg_5002 = "5002";
            HslCommunication.OperateResult<byte[]> read = PLC.Read(plc_reg_5002, 1);
            String[] TV_type = new String[20];
            if (read.IsSuccess)
            {
                for (int i = 0; i < 20; i++)
                {
                    HslCommunication.OperateResult<byte[]> reg_value = PLC.Read(Convert.ToString(5002 + i), 1);
                    short value1 = PLC.ByteTransform.TransInt16(reg_value.Content, 0);

                    TV_type[i] = AsciiToStr(value1);
                }
                return string.Join("", TV_type);
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ASCII码转Str
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string AsciiToStr(int asciiCode)
        {
            try
            {
                if (asciiCode >= 0 && asciiCode <= 255)
                {
                    System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                    byte[] byteArray = new byte[] { (byte)asciiCode };
                    string strCharacter = asciiEncoding.GetString(byteArray);
                    return (strCharacter);
                }
                else
                {
                    // throw new Exception("ASCII Code is not valid.");
                    return "";
                }
            }
            catch {
                return "";
            }
        }
    }




   

}
/*
 线体控制寄存器，寄存器地址：4096
 0 工装板未就们 1 工装板就位 2测试合格放行 3测试不合格放行 4 松开对接头 5 合上对接头

 指示灯状态寄存器，地址：4097
 1 green 2 red 3 yellow  WholeOutstr
     
     
     */
