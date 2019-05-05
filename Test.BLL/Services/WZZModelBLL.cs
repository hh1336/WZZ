using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using DAL.ViewModels;
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
            
            var result = await _db.WZZModels.Include(a => a.Articles).Include(a => a.WZZModels).SingleOrDefaultAsync(w => w.id == id);
            if(result == null)
            {
                try
                {
                    throw new Exception("模块为空") { HelpLink = "/LatestInformation/Index" };
                }
                catch (Exception)
                {

                    return new WZZModel();
                }
                
            }
            return result;
        }

        public async Task<List<WZZModelViewModel>> GetModelByMainModelId(int id)
        {
            if (id == 0) return new List<WZZModelViewModel>();
            var wzz = _db.WZZModels.Where(s => s.Pid == id);
            var result = new List<WZZModelViewModel>();
            foreach (var item in wzz)
            {
                var wzzmodel = new WZZModelViewModel()
                {
                    id = item.id,
                    name = item.name,
                    Pid = item.Pid,
                    icon = item.icon,
                    Subheading = item.Subheading
                };
                var query = from arc in _db.Articles.Where(s => s.WZZModelId == item.id && s.isShow == 1)
                            orderby arc.createTime descending
                            select new Article {
                                author = arc.author,
                                createTime = arc.createTime,
                                id = arc.id,
                                imgurl = arc.imgurl,
                                source = arc.source,
                                title = arc.title,
                                Portrait = arc.Portrait,
                                User = new User()
                                {
                                    PortraitUrl = _db.Users.SingleOrDefault(s => s.Id == arc.createuser.Value).PortraitUrl
                                }
                            };



                wzzmodel.Articles = await query.ToListAsync();
                result.Add(wzzmodel);
            }


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

        public async Task<bool> SaveModel(WZZModel data)
        {
            //创建
            if(data.id == 0)
            {
                await _db.WZZModels.AddAsync(data);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                
                var wzzmodel = await _db.WZZModels.SingleOrDefaultAsync(s => s.id == data.id);
                if (wzzmodel == null) return false;
                wzzmodel.name = data.name;
                wzzmodel.Pid = data.Pid.HasValue ? data.Pid : null;
                wzzmodel.Subheading = data.Subheading;
                wzzmodel.icon = data.icon;
                await _db.SaveChangesAsync();
                return true;
            }
        }
    }
}
