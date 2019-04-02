using DAL.enums;
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

        /// <summary>
        /// 用户状态
        /// </summary>
        public UserState userstate { set; get; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? createuser { set; get; }

        /// <summary>
        /// 删除人
        /// </summary>
        public int? deluser { set; get; }

        /// <summary>
        /// 编辑人
        /// </summary>
        public int? updateuser { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createtime { set; get; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? deltime { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updatetime { set; get; }
    }
}
