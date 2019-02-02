using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;

namespace BLL.Interfaces
{
    public interface IArticleImageBLL
    {
        Task<int> Add(ArticleImage data);
        Task<bool> UpdateTitle(ArticleImage data);
    }
}
