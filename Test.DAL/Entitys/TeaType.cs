using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 茶类型实体
    /// </summary>
    public class TeaType
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 茶名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string name { set; get; }

        /// <summary>
        /// 副标题
        /// </summary>
        [StringLength(100)]
        public string Subheading { set; get; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [StringLength(50)]
        public string imgurl { set; get; }

        /// <summary>
        /// 关联文章
        /// </summary>
        public ICollection<Article> Articles { set; get; }
    }
}
