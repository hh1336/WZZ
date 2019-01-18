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
    }
}
