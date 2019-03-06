using BLL.Commons;
using DAL.Entitys;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    /// <summary>
    /// 回收站接口
    /// </summary>
    public interface IRecoveryServiceBLL
    {
        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<Article>> GetAll();

        /// <summary>
        /// 将文章数据转换为Ipagelist形式
        /// </summary>
        /// <param name="data">数据源</param>
        /// <returns></returns>
        Task<IPageList<Article>> GetAllToPage(SearchViewModel data);

        /// <summary>
        /// 恢复数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> BackData(int id);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DelArticleResultModel> DelData(int id);

        /// <summary>
        /// 清空回收站数据
        /// </summary>
        /// <returns></returns>
        Task<List<string>> Clear();
    }
}
