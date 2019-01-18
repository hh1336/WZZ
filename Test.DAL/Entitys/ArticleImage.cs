using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 文章图片实体
    /// </summary>
    public class ArticleImage
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 图片描述
        /// </summary>
        [StringLength(50)]
        public string title { set; get; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string url { set; get; }

        /// <summary>
        /// 关联文章内容
        /// </summary>
        public ArticleConTent ArticleConTent { set; get; }

        /// <summary>
        /// 文章内容id
        /// </summary>
        public int ArticleConTentId { set; get; }
    }
}
