using BLL.Interfaces;
using DAL;
using DAL.Entitys;
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
        }
    }
}
