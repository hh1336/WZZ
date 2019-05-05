using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;
using DAL.ViewModels;

namespace BLL.Interfaces
{
    public interface IVisitAmountBLL
    {
        /// <summary>
        /// 根据IP地址判断用户今天是否浏览
        /// </summary>
        /// <param name="userHostAddress"></param>
        /// <returns></returns>
        bool IsAddress(string userHostAddress);

        /// <summary>
        /// 保存IP地址
        /// </summary>
        /// <param name="visitinfo"></param>
        /// <returns></returns>
        Task SaveAddress(VisitAmount visitinfo);

        /// <summary>
        /// 判断用户是否浏览过文章
        /// </summary>
        /// <param name="userHostAddress"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> IsVisitAc(string userHostAddress, int acid);

        /// <summary>
        /// 根据传入的时间来获取对应时间的数据
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        Task<VisitamountOutViewModel> GetVisiByTime(VisitAmountInputViewModel data);

        /// <summary>
        /// 获取当天，当周，当月的浏览总量，以及一篇点击量最高的文章
        /// </summary>
        /// <returns></returns>
        Task<VisitamountNewDataViewModal> LoadNewData();

        /// <summary>
        /// 根据文章id获取对应浏览量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> GetVisitByArcId(int id);
    }
}
