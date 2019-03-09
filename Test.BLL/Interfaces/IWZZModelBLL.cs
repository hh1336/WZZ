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
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        IQueryable<WZZModel> GetAll();

        /// <summary>
        /// 根据id获取主模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WZZModel> GetById(int id);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        List<WZZModel> GetAllList();

        /// <summary>
        /// 根据pid获取对应的上级模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<WZZModel> GetModelByPid(int? id);

        /// <summary>
        /// 获取所有主模块
        /// </summary>
        /// <returns></returns>
        Task<List<WZZModel>> GetAllModal();
    }
}
