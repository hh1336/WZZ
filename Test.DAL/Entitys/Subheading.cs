using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 文章副标题实体
    /// </summary>
    public class Subheading
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 副标题名
        /// </summary>
        public string head { set; get; }

        /// <summary>
        /// 关联文章实体
        /// </summary>
        public Article Article { set; get; }

        /// <summary>
        /// 文章id
        /// </summary>
        public int Articleid { set; get; }

        /// <summary>
        /// 关联文章内容
        /// </summary>
        public ICollection<ArticleConTent> ArticleConTents { set; get; }
    }
}
