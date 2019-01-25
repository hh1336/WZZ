using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    /// <summary>
    /// 用于返回登陆的结果信息
    /// </summary>
    public class LoginInfo
    {
        public int code { set; get; }
        public string msg { set; get; }
        public string url { set; get; }
        public string email { get; set; }
        public string PortraitUrl { get; set; }
    }
}
