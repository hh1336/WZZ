using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Linq;
using System.Text;
using BLL.Commons;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BLL.Services
{
    /// <summary>
    /// 文章服务实现
    /// </summary>
    public class ArticleBLL : IArticleBLL
    {
        private readonly MyDbContext _db;

        public ArticleBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 创建或修改文章表信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<int> AddOrUpdate(Article data,string username)
        {
            var user = await _db.Users.SingleOrDefaultAsync(s => s.Email == username);
            if (data.id == 0)
            {//判断是0就为新增
                data.createTime = DateTime.Now;
                data.createuser = user.Id;
                await _db.Articles.AddAsync(data);
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
            else//不是0就为修改
            {
                var article = await _db.Articles.SingleOrDefaultAsync(a => a.id == data.id);
                if (article == null)
                {
                    //如果查不到数据则返回false
                    return 0;
                }
                article.title = data.title;
                article.TeaTypeId = data.TeaTypeId;
                article.source = data.source;
                article.imgurl = data.imgurl;
                article.author = data.author;
                article.updateTime = DateTime.Now;
                article.WZZModelId = data.WZZModelId;
                article.isShow = data.isShow;
                var result = await _db.SaveChangesAsync();
                if (result == 1)
                {
                    return article.id;
                }
                else
                {
                    return 0;
                }

            }
        }

        /// <summary>
        /// 根据文章id获取文章的段落
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ArticleInfoModel> GetAcByAcid(int id)
        {
            //判断传入的数据是否有错
            if (id == 0) return new ArticleInfoModel();

            var ac = await _db.Articles.SingleOrDefaultAsync(s => s.id == id && s.isShow == 1);
            if (ac == null) return new ArticleInfoModel();
            //得到小节标题内容
            var achead = _db.Subheadings
                .Include(w => w.ArticleConTents)
                .ThenInclude(img => img.ArticleImage)
                .Where(s => s.Articleid == id);

            //找到没有小节标题的所有内容
            var nullheadAc = _db.ArticleConTents
                .Include(img => img.ArticleImage)
                .Where(a => a.ArticleId == id && a.Subheadingid == null);

            ArticleInfoModel result = new ArticleInfoModel() {
                id = ac.id,
                author = ac.author,
                createTime = ac.createTime,
                imgurl = ac.imgurl,
                source = ac.source,
                title = ac.title,
                updateTime = ac.updateTime                
            };
            result.ArticleConTents = await nullheadAc.ToListAsync();
            result.Subheadings = await achead.ToListAsync();

            return result;
        }

        /// <summary>
        /// 返回所有文章
        /// </summary>
        /// <returns></returns>
        public IQueryable<Article> GetAll()
        {
            return _db.Articles.Where(a => a.id >= 0);
        }

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns>List</returns>
        public List<Article> GetAllList()
        {
            var reslut = GetAll();
            return reslut.ToList();
        }

        /// <summary>
        /// 根据模块获取文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回文章和模块信息</returns>
        public List<ModelArticle> GetArticleByModel(List<WZZModel> model)
        {
            List<ModelArticle> modellist = new List<ModelArticle>();
            //循环每一个模块
            foreach (var item in model)
            {
                //把每个模块下的文章查询出来
                var Articles = _db.Articles.Where(a => a.WZZModelId == item.id);
                //把每个模块信息和对应的文章都放在一个ModelArticle集合中
                modellist.Add(new ModelArticle() { WZZModel = item, Articles = Articles.OrderByDescending(s => s.createTime).ToList() });
            }
            return modellist;
        }

        /// <summary>
        /// 根据模块id获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Article> GetArticleByModelId(int id)
        {
            var result = _db.Articles.Where(a => a.WZZModelId == id && a.isShow == 1);
            return result;
        }

        /// <summary>
        /// 对数据进行分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IPageList<Article>> GetArticlePageList(SearchViewModel model)
        {
            var result = await GetArticleByModelId(model.ModelId).Sort(model.field, model.order).ToPageList(model.limit, model.page);
            return result;
        }

        /// <summary>
        /// 根据id获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Article> GetById(int id)
        {
            return await _db.Articles.SingleOrDefaultAsync(a => a.id == id);


        }

        public async Task<List<Article>> GetNewArticle()
        {
            var result = _db.Articles.Where(s => s.isShow == 1).OrderByDescending(a => a.updateTime).Take(6);
            return await result.ToListAsync();
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Show(int id)
        {
            var article = await _db.Articles.SingleOrDefaultAsync(a => a.id == id);
            if (article == null) return false;
            article.isShow = 1;
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SoftDel(int id,string username)
        {
            var article = await _db.Articles.SingleOrDefaultAsync(a => a.id == id);
            if (article == null) return false;
            var user = await _db.Users.SingleOrDefaultAsync(s => s.Email == username);
            article.isShow = 0;
            article.deluser = user.Id;
            article.deltime = DateTime.Now;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Article> UserEditTheAc(int value, string username)
        {
            var result = await this.GetById(value);
            var user = await _db.Users.SingleOrDefaultAsync(s => s.Email == username);
            result.updateuser = user.Id;
            result.updateTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return result;
        }
    }
}
