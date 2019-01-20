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
    /// 轮播图服务实现
    /// </summary>
    public class RotationChartBLL : IRotationChartBLL
    {
        private readonly MyDbContext _db;

        public RotationChartBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<RotationChart> GetAll()
        {
            return _db.RotationCharts.Where(r => r.id >= 0);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<RotationChart> GetAllList()
        {
            var result = GetAll();
            return result.ToList();
        }

        /// <summary>
        /// 根据id获取轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RotationChart GetById(int id)
        {
            return _db.RotationCharts.SingleOrDefault(r => r.id == id);
        }

        /// <summary>
        /// 根据模块的id来加载轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RotationChart> GetImgByModelId(int id)
        {
            var result = _db.RotationCharts.Where(r => r.WZZModelId == id);
            return result.ToList();
        }
    }
}
