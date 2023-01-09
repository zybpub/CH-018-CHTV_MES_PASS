namespace colortv_test_automation
{
    /// <summary>
    /// 数据格式
    /// </summary>
    /// 
    
    class Class_Passmes_Data_V10
    {
        public string MO;　　     　//模组型号
        public string SN;               // 序列号
        public string WORKSTATIONID;    //工作站ID
        public string SOFT_VER;         //软件版本
        public string ERROR_CODE="";       //错误代码
        public string ERROR_SPOT="";   //错误点
        public string 调试时间;
        public bool 良品;
        public string mesreply;
        public string memo;
        public string RESULT;

        public string 调试时长 { get; internal set; }
    }
}

