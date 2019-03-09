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
    public class RotationChartSettingBLL : IRotationChartSettingBLL
    {
        private readonly MyDbContext _db;
        public RotationChartSettingBLL(MyDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddRotationChart(List<RotationChart> data)
        {
            try
            {
                await _db.RotationCharts.AddRangeAsync(data);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> DelRotationChart(int id)
        {
            if (id == 0) return false;
            var rotationChart = await _db.RotationCharts.SingleOrDefaultAsync(s => s.id == id);
            if (rotationChart == null)
            {
                return false;
            }
            else
            {
                _db.RotationCharts.Remove(rotationChart);
                await _db.SaveChangesAsync();
                return true;
            }
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

        public async Task<List<RotationChart>> GetAllByWzzId(int wzzid)
        {
            var result = _db.RotationCharts.Include(i => i.Article).Where(s => s.WZZModelId == wzzid);
            return await result.ToListAsync();

        }

        public async Task<List<Article>> GetArticles()
        {
            var result = _db.Articles.Where(s => s.isShow > 0);
            return await result.ToListAsync();
        }

        public async Task<RotationChart> GetById(int id)
        {
            if (id <= 0) return new RotationChart();
            var result = await _db.RotationCharts.Include(a => a.Article).SingleOrDefaultAsync(s => s.id == id);
            if (result == null) return new RotationChart();
            return result;
        }

        public async Task<bool> UpData(RotationChartInputModel data)
        {
            if (data.id <= 0) return false;
            var rotationchart = await _db.RotationCharts.SingleOrDefaultAsync(s => s.id == data.id);
            if (rotationchart == null) return false;
            if (data.ArticleId.HasValue)
            {
                if (await _db.Articles.SingleOrDefaultAsync(s => s.id == data.ArticleId) == null) return false;
            }
            if (data.WZZModelId.HasValue)
            {
                if (await _db.WZZModels.SingleOrDefaultAsync(s => s.id == data.WZZModelId) == null) return false;
            }

            rotationchart.imgurl = data.imgurl;
            rotationchart.title = data.title;
            rotationchart.WZZModelId = data.WZZModelId;
            rotationchart.ArticleId = data.ArticleId;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
