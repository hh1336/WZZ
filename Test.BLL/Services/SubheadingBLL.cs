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
    public class SubheadingBLL : ISubheadingBLL
    {
        private readonly MyDbContext _db;

        public SubheadingBLL(MyDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<int> AddOrUpdate(Subheading data)
        {
            if(data.id == 0)
            {
                await _db.Subheadings.AddAsync(data);
                await _db.SaveChangesAsync();
                return data.id;
            }
            else
            {
                var shead = await _db.Subheadings.SingleOrDefaultAsync(s => s.id == data.id);
                if (shead == null) return 0;
                shead.head = data.head;
                await _db.SaveChangesAsync();
                return data.id;
            }
        }
    }
}
