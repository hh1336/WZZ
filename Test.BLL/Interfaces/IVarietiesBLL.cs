using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVarietiesBLL
    {
        Task<ArticleInfoModel> GetAcById(int id);
    }
}
