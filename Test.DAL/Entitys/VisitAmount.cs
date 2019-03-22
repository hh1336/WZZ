using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 记录访问量表
    /// </summary>
    public class VisitAmount
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string ipaddress { set; get; }

        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime visitDateTime { set; get; }

        /// <summary>
        /// 访问的文章
        /// </summary>
        public int? ArticleId { set; get; }
    }
}
