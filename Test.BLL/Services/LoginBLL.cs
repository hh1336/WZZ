using BLL.Commons;
using BLL.Interfaces;
using DAL;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginBLL : ILoginBLL
    {
        private readonly MyDbContext _db;
        public LoginBLL(MyDbContext db)
        {
            _db = db;
        }

        public LoginInfo LoginUser(string email, string pwd)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            var info = new LoginInfo();
            if (user == null)
            {
                info.code = 0;
                info.msg = "登陆失败，没有找到用户";
                return info;
            }
            var newpwd = ParseMD5.GetMD5(pwd);
            if (!user.Pwd.Equals(newpwd))
            {
                info.code = 0;
                info.msg = "登陆失败，密码错误";
                return info;
            }
            info.email = user.Email;
            info.PortraitUrl = user.PortraitUrl;
            info.code = 1;
            info.msg = "登陆成功";
            info.url = "/Home/Index";
            return info;
        }
    }
}
