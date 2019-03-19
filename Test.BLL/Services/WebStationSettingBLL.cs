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
    public class WebStationSettingBLL : IWebStationSettingBLL
    {
        private readonly MyDbContext _db;
        public WebStationSettingBLL(MyDbContext db)
        {
            _db = db;
        }

        public async Task<WebStationSetting> GetInfoById(int id)
        {
            if (id == 0) return new WebStationSetting();
            var result = await _db.WebStationSettings.SingleOrDefaultAsync(s => s.id == id);
            return result;
        }

        public async Task<bool> Save(WebStationSetting data)
        {
            if (data.id == 0) return false;
            if (data.phone.Length != 11) return false;
            var webinfo = await _db.WebStationSettings.SingleOrDefaultAsync(s => s.id == data.id);

            if (webinfo == null) return false;
            var phone = data.phone.Trim();
            webinfo.phone = phone.Substring(0, 3) + "-" + phone.Substring(3, 4) + "-" + phone.Substring(7, 4);
            webinfo.imgurl = data.imgurl;
            webinfo.Subheading = data.Subheading;

            await _db.SaveChangesAsync();
            return true;

        }
    }
}
