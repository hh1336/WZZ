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

        /// <summary>
        /// 获取所有的文章
        /// </summary>
        /// <returns></returns>
        Task<List<Article>> GetArticles();

        /// <summary>
        /// 根据模块获取轮播图
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<List<RotationChart>> GetAllByWzzId(int wzzid);

        /// <summary>
        /// 新增轮播图
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> AddRotationChart(List<RotationChart> data);

        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelRotationChart(int id);
    }
}
