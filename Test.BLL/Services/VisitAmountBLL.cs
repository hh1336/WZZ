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
            var result = new VisitamountOutViewModel();
            var query = from visi in _db.VisitAmounts
                        where visi.visitDateTime > data.startTime.Value && visi.visitDateTime <= data.endTime.Value
                        select visi;
            var ipGroup = query.GroupBy(s => s.ipaddress);
            foreach (var item in ipGroup)
            {
                result.categories.Add(item.Key);
            }

            //result.categories = iplist;

            return result;
            ;
        }

        public bool IsAddress(string userHostAddress)
        {
            var result = _db.VisitAmounts.Where(v => v.ipaddress == userHostAddress && v.visitDateTime > DateTime.Today);
            if (result.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsVisitAc(string userHostAddress, int acid)
        {
            var visit = await _db.VisitAmounts.SingleOrDefaultAsync(v => v.ipaddress == userHostAddress && v.visitDateTime >= DateTime.Today && v.ArticleId == acid);
            if (visit != null) return true;
            return false;
        }

        public async Task SaveAddress(VisitAmount visitinfo)
        {
            await _db.VisitAmounts.AddAsync(visitinfo);
            await _db.SaveChangesAsync();
        }
    }
}
