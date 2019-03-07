using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entitys;
using DAL.ViewModels;

namespace BLL.Interfaces
{
    public interface IRotationChartSettingBLL
    {
        /// <summary>
        /// 获取所有轮播图图片
        /// </summary>
        /// <returns></returns>
        Task<RotationChartViewModel> GetAll();

        /// <summary>
        /// 根据id获取轮播图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<RotationChart> GetById(RotationChartInputModel model);
    }
}
