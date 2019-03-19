using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IWebStationSettingBLL
    {
        /// <summary>
        /// 获取网站信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WebStationSetting> GetInfoById(int id);

        /// <summary>
        /// 保存网站信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> Save(WebStationSetting data);
    }
}
