using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entitys
{
    public class WebStationSetting
    {
        [Key]
        public int id { set; get; }
        public string imgurl { set; get; }
        public string phone { set; get; }
        public string Subheading { set; get; }
    }
}
