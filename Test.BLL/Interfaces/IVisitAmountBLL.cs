using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;

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
    }
}
