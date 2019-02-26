using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Entitys
{
    /// <summary>
    /// 模块表实体
    /// </summary>
    public class WZZModel
    {
        /// <summary>
        /// 模块id
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 模块名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { set; get; }

        /// <summary>
        /// 模块的副标题
        /// </summary>
        [StringLength(50)]
        public string Subheading { set; get; }

        /// <summary>
        /// 自关联id
        /// </summary>
        public int? Pid { set; get; }

        /// <summary>
        /// 文章图标
        /// </summary>
        public string icon { set; get; }

        /// <summary>
        /// 关联文章
        /// </summary>
        public ICollection<Article> Articles { set; get; }
    }
}