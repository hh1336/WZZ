using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { set; get; }

        /// <summary>
        /// 登陆用的邮箱
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { set; get; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string PortraitUrl { set; get; }
    }
}
