using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;

namespace BLL.Interfaces
{
    public interface ISubheadingBLL
    {
        Task<int> AddOrUpdate(Subheading data);
    }
}
