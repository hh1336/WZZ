﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 文章内容实体
    /// </summary>
    public class ArticleConTent
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string articleText { set; get; }

        /// <summary>
        /// 关联文章
        /// </summary>
        public virtual Article Article { set; get; }

        /// <summary>
        /// 关联文章副标题
        /// </summary>
        public virtual Subheading Subheading { set; get; }

        /// <summary>
        /// 关联文章对应的图片
        /// </summary>
        public ICollection<ArticleImage> ArticleImage { set; get; }

        /// <summary>
        /// 文章id
        /// </summary>
        [ForeignKey("Article")]
        public int? ArticleId { set; get; }

        /// <summary>
        /// 文章副标题id
        /// </summary>
        [ForeignKey("Subheading")]
        public int? Subheadingid { set; get; }
    }
}
