using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// 模块服务实现
    /// </summary>
    public class WZZModelBLL : IWZZModelBLL
    {
        private readonly MyDbContext _db;

        public WZZModelBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<WZZModel> GetAll()
        {
            return _db.WZZModels.Where(w => w.id >= 0);
        }

        /// <summary>
        /// 获取所有数据并返回list类型的集合
        /// </summary>
        /// <returns></returns>
        public List<WZZModel> GetAllList()
        {
            var result = GetAll();
            return result.ToList();
        }

        public async Task<List<WZZModel>> GetAllModal()
        {
            var result = _db.WZZModels.Include(a => a.WZZModeles).Where(s => s.Pid == null);
            return await result.ToListAsync();
        }

        /// <summary>
        /// 根据id获取模块信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WZZModel> GetById(int id)
        {
            var result = await _db.WZZModels.SingleOrDefaultAsync(w => w.id == id);
            return result;
        }

        /// <summary>
        /// 根据副id获取对应大模块下的小模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<WZZModel> GetModelByPid(int? id)
        {
            List<WZZModel> result = new List<WZZModel>();
            if (id.HasValue)
            {
                result = _db.WZZModels.Where(w => w.Pid == id).ToList();
            }
            else
            {
                var query = _db.WZZModels.Where(w => w.Pid == null);
                result = query.ToList();
            }

            return result;
        }
    }
}
