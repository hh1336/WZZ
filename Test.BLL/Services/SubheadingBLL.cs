using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class SubheadingBLL : ISubheadingBLL
    {
        private readonly MyDbContext _db;

        public SubheadingBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<int> AddOrUpdate(Subheading data)
        {
            if (data.id <= 0)
            {

                await _db.Subheadings.AddAsync(data);
                await _db.SaveChangesAsync();
                return data.id;
            }
            else
            {
                var shead = await _db.Subheadings.SingleOrDefaultAsync(s => s.id == data.id);
                if (shead == null) return 0;
                shead.head = data.head;
                await _db.SaveChangesAsync();
                return data.id;
            }
        }

        /// <summary>
        /// 删除对应的文章标题数据和对应的文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Del(int id)
        {
            if (id == 0) return false;
            var subhead = await _db.Subheadings.SingleOrDefaultAsync(s => s.id == id);
            if (subhead == null) return false;
            var acontents = _db.ArticleConTents.Where(a => a.Subheadingid == id);
            if (acontents.Count() > 0)
            {
                foreach (var item in acontents)
                {
                    var imgdata = _db.ArticleImages.Where(a => a.ArticleConTentId == item.id);
                    if (imgdata.Count() > 0)
                    {
                        foreach (var idata in imgdata)
                        {
                            _db.ArticleImages.Remove(idata);
                        }
                    }
                    _db.ArticleConTents.Remove(item);
                }
                _db.SaveChanges();
            }
            _db.Subheadings.Remove(subhead);
            _db.SaveChanges();
            return true;
        }
    }
}
