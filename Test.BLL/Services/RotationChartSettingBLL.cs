using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RotationChartSettingBLL: IRotationChartSettingBLL
    {
        private readonly MyDbContext _db;
        public RotationChartSettingBLL(MyDbContext db)
        {
            _db = db;
        }

        public async Task<RotationChartViewModel> GetAll()
        {
            var result = new RotationChartViewModel();
            var home = _db.RotationCharts.Where(s => s.WZZModelId == 11);
            var teatype = _db.RotationCharts.Where(s => s.WZZModelId == 13);
            var story = _db.RotationCharts.Where(s => s.WZZModelId == 14);

            result.HomeRotationChart = await home.ToListAsync();
            result.TeaTypeRotationChart = await teatype.ToListAsync();
            result.StoryRotationChart = await story.ToListAsync();

            return result;
        }

        public async Task<RotationChart> GetById(RotationChartInputModel model)
        {
            if (!model.id.HasValue) return new RotationChart();
            var result = await _db.RotationCharts.SingleOrDefaultAsync(s => s.id == model.id.Value);
            if (result == null) return new RotationChart();
            return result;
        }
    }
}
