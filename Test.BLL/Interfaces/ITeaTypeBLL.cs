using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    /// <summary>
    /// 茶类型接口
    /// </summary>
    public interface ITeaTypeBLL
    {
        IQueryable<TeaType> GetAll();

        TeaType GetById(int id);

        List<TeaType> GetAllList();

        List<TeaTypeAndArticlesViewModel> GetTeaTypeAndArticle();
    }
}
