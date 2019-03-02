using BLL.Commons;
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
    public class RecoveryServiceBLL : IRecoveryServiceBLL
    {
        private readonly MyDbContext _db;
        public RecoveryServiceBLL(MyDbContext db)
        {
            _db = db;
        }

        public async Task<bool> BackData(int id)
        {
            if (id <= 0) return false;
            var result = await _db.Articles.SingleOrDefaultAsync(s => s.id == id && s.isShow == 0);
            if (result == null) return false;
            result.isShow = 1;
            return true;
        }

        public async Task<DelArticleResultModel> Clear()
        {
            var result = _db.Articles
                .Include(s => s.ArticleConTents)
                .ThenInclude(s => s.ArticleImage)
                .Include(s => s.Subheadings)
                .Where(a => a.isShow == 0);
            var list = new List<string>();
            foreach (var item in result)
            {
                if (item.imgurl != null) list.Add(item.imgurl);
                foreach (var ac in item.ArticleConTents)
                {
                    foreach (var img in ac.ArticleImage)
                    {
                        list.Add(img.url);
                    }
                }
            }
            _db.Articles.RemoveRange(result);
            await _db.SaveChangesAsync();
            return new DelArticleResultModel()
            {
                code = true,
                list = list
            };
        }

        public async Task<DelArticleResultModel> DelData(int id)
        {
            //判断数据准确性
            if (id <= 0) return new DelArticleResultModel() { code = false };
            var result = await _db.Articles
                .Include(s => s.ArticleConTents)
                .ThenInclude(s => s.ArticleImage)
                .Include(s => s.Subheadings)
                .SingleOrDefaultAsync(a => a.id == id);
            if (result == null) return new DelArticleResultModel() { code = false };
            var list = new List<string>();
            //得到当前文章的图片
            if (result.imgurl != null) list.Add(result.imgurl);
            //得到所有文章图片的链接
            foreach (var item in result.ArticleConTents)
            {
                foreach (var img in item.ArticleImage)
                {
                    list.Add(img.url);
                }
                //删除图片数据
                _db.ArticleImages.RemoveRange(item.ArticleImage);
                await _db.SaveChangesAsync();
            }
            //删除标题
            _db.Subheadings.RemoveRange(result.Subheadings);
            await _db.SaveChangesAsync();

            //删除文章内容
            _db.ArticleConTents.RemoveRange(result.ArticleConTents);
            await _db.SaveChangesAsync();

            //删除文章
            _db.Articles.Remove(result);
            await _db.SaveChangesAsync();

            return new DelArticleResultModel() {
                code = true,
                list = list
            };
        }

        public async Task<IQueryable<Article>> GetAll()
        {
            var result = _db.Articles.Include(s => s.WZZModel).ThenInclude(s => s.WZZModels).Where(a => a.isShow == 0);
            return result;
        }

        public async Task<IPageList<Article>> GetAllToPage(SearchViewModel data)
        {
            var result = await GetAll().Sort(data.field, data.order).ToPageList(data.limit, data.page);
            return result;
        }
    }
}
