using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class VisitAmountBLL : IVisitAmountBLL
    {
        private readonly MyDbContext _db;

        public VisitAmountBLL(MyDbContext db)
        {
            _db = db;
        }
    }
}
