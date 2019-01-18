using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    /// <summary>
    /// 文章接口
    /// </summary>
    public interface IArticleBLL
    {
        IQueryable<Article> GetAll();

        Article GetById(int id);

        List<Article> GetAllList();
    }
}
