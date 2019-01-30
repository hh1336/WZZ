using BLL.Commons;
using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class UserBLL : IUserBLL
    {
        private readonly MyDbContext _db;
        public UserBLL(MyDbContext db)
        {
            _db = db;
        }

        public User Get(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public User Get(string email)
        {
            return _db.Users.SingleOrDefault(u => u.Email == email);
        }

        public bool Updata(User user, out string url)
        {
            url = "";
            var userinfo = Get(user.Id);
            if (userinfo != null)
            {
                userinfo.Nickname = user.Nickname;
                if (!userinfo.PortraitUrl.Equals(user.PortraitUrl))
                {
                    url = userinfo.PortraitUrl;
                    userinfo.PortraitUrl = user.PortraitUrl;
                }
                user.Pwd = ParseMD5.GetMD5(user.Pwd);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
