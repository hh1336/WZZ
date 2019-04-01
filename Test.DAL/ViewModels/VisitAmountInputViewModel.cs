using DAL.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class VisitAmountInputViewModel
    {
        public DateTime? startTime { set; get; }
        public DateTime? endTime { set; get; }

        public VisitAountEnum visitAountEnum { set; get; }
    }
}
