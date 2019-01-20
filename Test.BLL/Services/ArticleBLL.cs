using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    /// <summary>
    /// 文章服务实现
    /// </summary>
    public class ArticleBLL : IArticleBLL
    {
        private readonly MyDbContext _db;

        public ArticleBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 返回所有文章
        /// </summary>
        /// <returns></returns>
        public IQueryable<Article> GetAll()
        {
            return _db.Articles.Where(a => a.id >= 0);
        }

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns>List</returns>
        public List<Article> GetAllList()
        {
            var reslut = GetAll();
            return reslut.ToList();
        }

        /// <summary>
        /// 根据模块获取文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回文章和模块信息</returns>
        public List<ModelArticle> GetArticleByModel(List<WZZModel> model)
        {
            List<ModelArticle> modellist = new List<ModelArticle>();
            //循环每一个模块
            foreach (var item in model)
            {
                //把每个模块下的文章查询出来
                var Articles = _db.Articles.Where(a => a.WZZModelId == item.id);
                //把每个模块信息和对应的文章都放在一个ModelArticle集合中
                modellist.Add(new ModelArticle() { WZZModel = item, Articles = Articles.ToList() });
            }
            return modellist;
        }

        /// <summary>
        /// 根据id获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article GetById(int id)
        {
            return _db.Articles.SingleOrDefault(a => a.id == id);
        }
    }
}
