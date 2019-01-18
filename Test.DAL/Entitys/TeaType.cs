using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entitys
{
    public class TeaType
    {
        [Key]
        public int id { set; get; }

        [Required]
        [StringLength(20)]
        public string name { set; get; }

        [StringLength(100)]
        public string Subheading { set; get; }

        [StringLength(50)]
        public string imgurl { set; get; }
    }
}
