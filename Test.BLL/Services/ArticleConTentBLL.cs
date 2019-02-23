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
    public class ArticleConTentBLL : IArticleConTentBLL
    {
        private readonly MyDbContext _db;
        public ArticleConTentBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 新增或修改文章段落
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<int> AddOrUpdate(ArticleConTent data)
        {
            //判断是新增还是修改
            if (data.id == 0)
            {
                await _db.ArticleConTents.AddAsync(data);
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return data.id;
                }
                else
                {
                    return 0;
                }
            }
            else//修改
            {
                var acontent = await _db.ArticleConTents.SingleOrDefaultAsync(a => a.id == data.id);
                if (acontent == null)
                {
                    return 0;
                }
                if (data.ArticleId.HasValue) acontent.ArticleId = data.ArticleId;
                acontent.articleText = data.articleText;
                if (data.Subheadingid.HasValue) acontent.Subheadingid = data.Subheadingid;
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return acontent.id;
                }
                else
                {
                    return 0;
                }
            }

        }
    }
}
