using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserBLL
    {
        bool Updata(User user,out string url);

        User Get(int id);
        User Get(string email);
    }
}
