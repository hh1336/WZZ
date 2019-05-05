using BLL.Interfaces;
using DAL;
using DAL.Entitys;
using DAL.enums;
using DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VisitAmountBLL : IVisitAmountBLL
    {
        private readonly MyDbContext _db;

        public VisitAmountBLL(MyDbContext db)
        {
            _db = db;
        }


        public async Task<VisitamountOutViewModel> GetVisiByTime(VisitAmountInputViewModel data)
        {
            if (!data.startTime.HasValue) data.startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (!data.endTime.HasValue) data.endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            VisitamountOutViewModel result = new VisitamountOutViewModel();
            //得到访问情况
            var query = from visi in _db.VisitAmounts
                        where visi.visitDateTime >= data.startTime.Value && visi.visitDateTime <= data.endTime.Value
                        group visi by new { time = visi.visitDateTime, ipaddress = visi.ipaddress };

            if (data.visitAountEnum == VisitAountEnum.Week)
            {
                var week = new Dictionary<string, int>();
                week.Add("Monday", 0);
                week.Add("Tuesday", 0);
                week.Add("Wednesday", 0);
                week.Add("Thursday", 0);
                week.Add("Friday", 0);
                week.Add("Saturday", 0);
                week.Add("Sunday", 0);
                result.data = week;

                foreach (var item in query)
                {
                    result.data[item.Key.time.DayOfWeek.ToString()]++;
                }


            }
            else if (data.visitAountEnum == VisitAountEnum.Month)
            {
                var week = new Dictionary<string, int>();
                for (int i = 1; i <= DateTime.DaysInMonth(data.endTime.Value.Year, data.endTime.Value.Month); i++)
                {
                    week.Add(i + "号", 0);
                }
                foreach (var item in query)
                {
                    week[item.Key.time.Day + "号"]++;
                }
                result.data = week;
            }
            else if (data.visitAountEnum == VisitAountEnum.Year)
            {
                var week = new Dictionary<string, int>();
                for (int i = 1; i <= 12; i++)
                {
                    week.Add(i + "月", 0);
                }
                foreach (var item in query)
                {
                    week[item.Key.time.Month + "月"]++;
                }
                result.data = week;
            }
            else if (data.visitAountEnum == VisitAountEnum.Day)
            {
                var week = new Dictionary<string, int>();
                foreach (var item in query)
                {
                    if (!week.ContainsKey(item.Key.time.ToString("yyyy-MM-dd"))) week.Add(item.Key.time.ToString("yyyy-MM-dd"), 0);
                    week[item.Key.time.ToString("yyyy-MM-dd")]++;
                }
                result.data = week;
            }


            return result;
        }

        public async Task<int> GetVisitByArcId(int id)
        {
            var number = await _db.VisitAmounts.Where(s => s.ArticleId == id).CountAsync();
            return number;
        }

        public bool IsAddress(string userHostAddress)
        {
            var result = _db.VisitAmounts.Where(v => v.ipaddress == userHostAddress && v.visitDateTime == DateTime.Now.Date);
            if (result.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsVisitAc(string userHostAddress, int acid)
        {
            var visit = await _db.VisitAmounts.SingleOrDefaultAsync(v => v.ipaddress == userHostAddress && v.visitDateTime == DateTime.Now.Date && v.ArticleId == acid);
            if (visit != null) return true;
            return false;
        }

        public async Task<VisitamountNewDataViewModal> LoadNewData()
        {
            var result = new VisitamountNewDataViewModal();
            //得到当天点击量
            var toDayVisi = _db.VisitAmounts.Where(s => s.visitDateTime >= DateTime.Now.Date && s.visitDateTime <= DateTime.Now.Date.AddDays(1)).GroupBy(s => s.ipaddress).Count();

            var week = DateTime.Now.DayOfWeek;
            //得到本周周一和周末
            DateTime toWeek, lastWeekDay;
            switch (week.ToString())
            {
                case "Monday":
                    toWeek = DateTime.Now.Date;
                    lastWeekDay = DateTime.Now.Date.AddDays(7);
                    break;
                case "Tuesday":
                    toWeek = DateTime.Now.Date.AddDays(-1);
                    lastWeekDay = DateTime.Now.Date.AddDays(6);
                    break;
                case "Wednesday":
                    toWeek = DateTime.Now.Date.AddDays(-2);
                    lastWeekDay = DateTime.Now.Date.AddDays(5);
                    break;
                case "Thursday":
                    toWeek = DateTime.Now.Date.AddDays(-3);
                    lastWeekDay = DateTime.Now.Date.AddDays(4);
                    break;
                case "Friday":
                    toWeek = DateTime.Now.Date.AddDays(-4);
                    lastWeekDay = DateTime.Now.Date.AddDays(3);
                    break;
                case "Saturday":
                    toWeek = DateTime.Now.Date.AddDays(-5);
                    lastWeekDay = DateTime.Now.Date.AddDays(2);
                    break;
                default:
                    toWeek = DateTime.Now.Date.AddDays(-6);
                    lastWeekDay = DateTime.Now.Date;
                    break;
            }
            //得到本周浏览量
            var toWeekVisi = _db.VisitAmounts.Where(s => s.visitDateTime >= toWeek && s.visitDateTime <= lastWeekDay).GroupBy(s => new { time = s.visitDateTime,ip = s.ipaddress }).Count();

            //这个月的一号
            var toMonthFirst = DateTime.Now.Date.AddDays(-(DateTime.Now.Day - 1));
            //这个月的最后一天
            var toMonthLast = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            //这个月的浏览量
            var toMonthVisi = _db.VisitAmounts.Where(s => s.visitDateTime >= toMonthFirst && s.visitDateTime <= toMonthLast).GroupBy(s => new { time = s.visitDateTime, ip = s.ipaddress }).Count();

            var query = (from item in
                            (from visi in _db.VisitAmounts
                             where visi.ArticleId != null
                             group visi by visi.ArticleId into v
                             select new
                             {
                                 result = v.Key,
                                 number = v.Count()
                             }
                             )
                         orderby item.number descending
                         select item.result).First();
            if (query.HasValue)
            {
                var hotArticle = await _db.Articles.SingleOrDefaultAsync(s => s.id == query.Value);
                result.HotArticle = hotArticle;
            }


            result.LastWeekDay = lastWeekDay;
            result.ToDayVisi = toDayVisi;
            result.ToMonthFirst = toMonthFirst;
            result.ToMonthLast = toMonthLast;
            result.ToMonthVisi = toMonthVisi;
            result.ToWeek = toWeek;
            result.ToWeekVisi = toWeekVisi;


            return result;
        }

        public async Task SaveAddress(VisitAmount visitinfo)
        {
            await _db.VisitAmounts.AddAsync(visitinfo);
            await _db.SaveChangesAsync();
        }
    }
}
