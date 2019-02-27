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
        Task<List<ArticleImage>> FindByActId(int actId);

        /// <summary>
        /// 根据id删除图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelById(int id);
    }
}
