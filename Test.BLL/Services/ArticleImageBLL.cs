using BLL.Interfaces;
using DAL;
using DAL.Entitys;
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
