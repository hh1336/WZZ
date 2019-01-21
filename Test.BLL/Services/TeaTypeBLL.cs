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
    /// 茶类型服务实现
    /// </summary>
    public class TeaTypeBLL : ITeaTypeBLL
    {
        private readonly MyDbContext _db;

        public TeaTypeBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取所有茶数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<TeaType> GetAll()
        {
            return _db.TeaTypes.Where(t => t.id >= 0);
        }

        /// <summary>
        /// 获取所有茶数据并且转换成list
        /// </summary>
        /// <returns></returns>
        public List<TeaType> GetAllList()
        {
            var result = GetAll();
            return result.ToList();
        }

        /// <summary>
        /// 根据id获取茶类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TeaType GetById(int id)
        {
            return _db.TeaTypes.SingleOrDefault(t => t.id == id);
        }

        //返回茶类型和对应的文章
        public List<TeaTypeAndArticlesViewModel> GetTeaTypeAndArticle()
        {
            var teas = GetAll();
            List<TeaTypeAndArticlesViewModel> list = new List<TeaTypeAndArticlesViewModel>();
            foreach (var item in teas)
            {
                list.Add(new TeaTypeAndArticlesViewModel()
                {
                    teaType = item,
                    articles = _db.Articles.Where(a => a.TeaTypeId == item.id).ToList()
                });
            }

            return list;
        }
    }
}
