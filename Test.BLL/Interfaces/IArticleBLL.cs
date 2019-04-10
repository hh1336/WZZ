using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Commons;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// 文章接口
    /// </summary>
    public interface IArticleBLL
    {
        IQueryable<Article> GetAll();

        Task<Article> GetById(int id);

        List<Article> GetAllList();

        List<ModelArticle> GetArticleByModel(List<WZZModel> model);

        IQueryable<Article> GetArticleByModelId(int id);

        /// <summary>
        /// 获取最新更新的文章
        /// </summary>
        /// <returns></returns>
        Task<List<Article>> GetNewArticle();
        Task<IPageList<Article>> GetArticlePageList(SearchViewModel model);
        Task<int> AddOrUpdate(Article data,string username);
        Task<bool> Show(int id);
        Task<bool> SoftDel(int id,string username);
        Task<ArticleInfoModel> GetAcByAcid(int id);
        Task<Article> UserEditTheAc(int value, string username);

        IQueryable<Article> GetArticleAllByModelId(int id);
    }
}
