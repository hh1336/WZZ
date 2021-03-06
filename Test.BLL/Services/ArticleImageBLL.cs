﻿using BLL.Interfaces;
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
    public class ArticleImageBLL : IArticleImageBLL
    {
        private readonly MyDbContext _db;
        public ArticleImageBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 保存对应段落的图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<int> Add(ArticleImage data)
        {
            await _db.ArticleImages.AddAsync(data);
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

        /// <summary>
        /// 根据id删除图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelById(int id)
        {
            if (id == 0) return false;
            var img = await _db.ArticleImages.SingleOrDefaultAsync(a => a.id == id);
            if (img == null) return false;
            _db.ArticleImages.Remove(img);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 根据文章内容id获取图片
        /// </summary>
        /// <param name="actId"></param>
        /// <returns></returns>
        public async Task<List<ArticleImage>> FindByActId(int actId)
        {
            var result = _db.ArticleImages.Where(a => a.ArticleConTentId == actId);
            return await result.ToListAsync();
        }

        /// <summary>
        /// 修改对应段落图片的描述
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTitle(ArticleImage data)
        {
            if (data.ArticleConTentId == 0)
            {
                return false;
            }
            var artimgs = _db.ArticleImages.Where(a => a.ArticleConTentId == data.ArticleConTentId);

            if (artimgs.Count() > 0)
            {
                foreach (var item in artimgs)
                {
                    item.title = data.title;
                }
                var result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
