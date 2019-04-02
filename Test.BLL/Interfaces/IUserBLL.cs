using BLL.Commons;
using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBLL
    {
        bool Updata(User user,out string url);

        User Get(int id);
        User Get(string email);
        Task<IPageList<User>> GetAllList(SearchViewModel data);
        Task<User> GetUserById(int id);
        Task<bool> Save(User user, string username);
        Task<bool> DelUser(UserViewModel data,string username);
    }
}
