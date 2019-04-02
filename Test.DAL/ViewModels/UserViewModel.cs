using DAL.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class UserViewModel
    {
        public int Id { set; get; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { set; get; }

        /// <summary>
        /// 登陆用的邮箱
        /// </summary>
        public string Email { set; get; }

        public string PortraitUrl { set; get; }

    }
}
