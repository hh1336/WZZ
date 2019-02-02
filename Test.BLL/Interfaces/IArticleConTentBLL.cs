using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IArticleConTentBLL
    {
        Task<int> AddOrUpdate(ArticleConTent data);
    }
}
