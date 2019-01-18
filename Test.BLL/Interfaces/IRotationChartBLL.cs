using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Interfaces
{
    /// <summary>
    /// 轮播图接口
    /// </summary>
    public interface IRotationChartBLL
    {
        IQueryable<RotationChart> GetAll();

        RotationChart GetById(int id);

        List<RotationChart> GetAllList();
    }
}
