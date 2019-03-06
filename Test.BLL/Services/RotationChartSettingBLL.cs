using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RotationChartSettingBLL: IRotationChartSettingBLL
    {
        private readonly MyDbContext _db;
        public RotationChartSettingBLL(MyDbContext db)
        {
            _db = db;
        }

    }
}
