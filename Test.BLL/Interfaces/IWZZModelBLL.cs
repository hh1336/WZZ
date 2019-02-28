using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// 模块服务接口
    /// </summary>
    public interface IWZZModelBLL
    {
        IQueryable<WZZModel> GetAll();

        Task<WZZModel> GetById(int id);

        List<WZZModel> GetAllList();

        List<WZZModel> GetModelByPid(int? id);

    }
}
