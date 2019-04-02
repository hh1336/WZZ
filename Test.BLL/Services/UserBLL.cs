using BLL.Commons;
using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using DAL.enums;
using DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserBLL : IUserBLL
    {
        private readonly MyDbContext _db;
        public UserBLL(MyDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DelUser(UserViewModel data,string username)
        {
            if (data.Id == 0) return false;
            var actionuser = await _db.Users.SingleOrDefaultAsync(s => s.Email == username);
            if (actionuser == null) return false;
            var user = await _db.Users.SingleOrDefaultAsync(s => s.Id == data.Id);
            if (user == null) return false;
            user.deltime = DateTime.Now;
            user.deluser = actionuser.Id;
            user.userstate = UserState.删除;
            await _db.SaveChangesAsync();
            return true;
        }

        public User Get(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public User Get(string email)
        {
            return _db.Users.SingleOrDefault(u => u.Email == email);
        }

        public async Task<IPageList<User>> GetAllList(SearchViewModel data)
        {
            var result = await _db.Users.Where(s => s.userstate > 0).Sort(data.field, data.order).ToPageList(data.limit, data.page);
            return result;
        }


        public async Task<User> GetUserById(int id)
        {
            if (id == 0) return new User();
            var user = await _db.Users.SingleOrDefaultAsync(s => s.Id == id);
            if (user == null) return new User();
            return user;
        }

        public async Task<bool> Save(User userdata,string username)
        {
            var actionuser = await _db.Users.SingleOrDefaultAsync(s => s.Email == username);
            if (actionuser == null) return false;
            if (userdata.Id == 0)
            {
                var isEmail = this.Get(userdata.Email);
                if (isEmail != null) return false;
                userdata.Pwd = ParseMD5.GetMD5(userdata.Pwd);
                userdata.createtime = DateTime.Now;
                userdata.userstate = userdata.userstate;
                userdata.createuser = actionuser.Id;
                await _db.Users.AddAsync(userdata);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                var user = await _db.Users.SingleOrDefaultAsync(s => s.Id == userdata.Id);
                if (user == null) return false;
                user.Nickname = userdata.Nickname;
                user.PortraitUrl = userdata.PortraitUrl;
                user.Pwd = ParseMD5.GetMD5(userdata.Pwd);
                user.updatetime = DateTime.Now;
                user.updateuser = actionuser.Id;
                user.userstate = userdata.userstate;
                await _db.SaveChangesAsync();
                return true;
            }
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
