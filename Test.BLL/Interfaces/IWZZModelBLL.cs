using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    /// <summary>
    /// 模块服务接口
    /// </summary>
    public interface IWZZModelBLL
    {
        IQueryable<WZZModel> GetAll();

        WZZModel GetById(int id);

        List<WZZModel> GetAllList();

        List<WZZModel> GetModelByPid(int? id);

    }
}
