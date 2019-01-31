using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Commons;
namespace BLL.Interfaces
{
    /// <summary>
    /// 文章接口
    /// </summary>
    public interface IArticleBLL
    {
        IQueryable<Article> GetAll();

        Article GetById(int id);

        List<Article> GetAllList();

        List<ModelArticle> GetArticleByModel(List<WZZModel> model);

        IQueryable<Article> GetArticleByModelId(int id);

        IPageList<Article> GetArticlePageList(SearchViewModel model);
    }
}
