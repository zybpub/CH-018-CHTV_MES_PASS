using System;

namespace colortv_test_automation
{
    class SendDataToMes
    {
        public static  string SendData(string jsondata) {

           try
            {
                string url = "http://10.52.88.17:8080/N2/http/interface.ms?model=IntoScgz&method=intoScgzSaveInfo";

                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);    //创建了一个http请求
                request.ContentType = "application/json;charset=UTF-8";
                request.Method = "POST";     //请求方式Post

                byte[] payload = System.Text.Encoding.UTF8.GetBytes(jsondata);

                //设置请求的 ContentLength 
                request.ContentLength = payload.Length;
                using (System.IO.Stream streamWriter = request.GetRequestStream())
                {
                    streamWriter.Write(payload, 0, payload.Length);
                }

                var response = (System.Net.HttpWebResponse)request.GetResponse();
                using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return "服务器连接失败：" + ex.Message;
            }
        }

        public static string Hw_Data_To_Json(Class_Passmes_Data_V10 data)
        {
            //整理将要提交的数据data
            System.IO.StringWriter sw = new System.IO.StringWriter();
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                writer.WriteStartObject();

                writer.WritePropertyName("TESTS");

                writer.WriteStartArray();

                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("白平衡");
                writer.WritePropertyName("VALUE");
                writer.WriteValue("OK");
                writer.WriteEndObject();

                //writer.WriteStartObject();
                //writer.WritePropertyName("KEY");
                //writer.WriteValue("maxlightness");
                //writer.WritePropertyName("VALUE");
                //writer.WriteValue(data.maxlightness);
                //writer.WriteEndObject();


                writer.WriteEndArray();

                writer.WritePropertyName("MO");
                writer.WriteValue(data.MO);

                writer.WritePropertyName("SN");
                writer.WriteValue(data.SN);

                writer.WritePropertyName("WORKSTATIONID");
                writer.WriteValue(data.WORKSTATIONID);

                writer.WritePropertyName("SOFT_VER");
                writer.WriteValue(data.SOFT_VER);
                writer.WritePropertyName("RESULT");
                writer.WriteValue(data.RESULT);
                if (data.ERROR_CODE != "")
                {
                    writer.WritePropertyName("ERRORS");
                    writer.WriteStartArray();
                    writer.WriteStartObject();
                    writer.WritePropertyName("ERROR_CODE");
                    writer.WriteValue(data.ERROR_CODE);
                    writer.WriteEndObject();
                    writer.WriteStartObject();
                    writer.WritePropertyName("ERROR_SPOT");
                    writer.WriteValue(data.ERROR_SPOT);
                    writer.WriteEndObject();
                    writer.WriteEndArray();
                }

                writer.WriteEndObject();
                writer.Flush();
            }
            sw.Close();
            return sw.ToString();
        }

      
        public static string SendStr(string data) {

            try
            {
                string url = passmes_config_json.MES_URL;

                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);    //创建了一个http请求
                request.ContentType = "application/json;charset=UTF-8";
                request.Method = "POST";     //请求方式Post

                byte[] payload = System.Text.Encoding.UTF8.GetBytes(data);

                //设置请求的 ContentLength 
                request.ContentLength = payload.Length;
                using (System.IO.Stream streamWriter = request.GetRequestStream())
                {
                    streamWriter.Write(payload, 0, payload.Length);
                }

                var response = (System.Net.HttpWebResponse)request.GetResponse();
                using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result.ToString();
                }
            }
            catch (Exception ex) {
                return "服务器连接失败：" + ex.Message;
            }
        }
    }
}
