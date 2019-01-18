using BLL.Interfaces;
using DAL;
using DAL.Entitys;
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
