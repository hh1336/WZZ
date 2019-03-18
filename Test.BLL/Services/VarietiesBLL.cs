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
    public class VarietiesBLL : IVarietiesBLL
    {
        private readonly MyDbContext _db;
        public VarietiesBLL(MyDbContext db)
        {
            _db = db;
        }
        public async Task<ArticleInfoModel> GetAcById(int id)
        {
            if (id != 0)
            {
                var arc = await _db.Articles.SingleOrDefaultAsync(s => s.id == id && s.isShow == 1);
                if (arc == null) return new ArticleInfoModel();
                var result = new ArticleInfoModel()
                {
                    id = arc.id,
                    author = arc.author,
                    createTime = arc.createTime,
                    imgurl = arc.imgurl,
                    isShow = arc.isShow,
                    source = arc.source,
                    title = arc.title
                };
                result.ArticleConTents = await _db.ArticleConTents.Where(s => s.ArticleId == id && s.Subheadingid == null).ToListAsync();
                return result;
            }

            return new ArticleInfoModel();

        }
    }
}
