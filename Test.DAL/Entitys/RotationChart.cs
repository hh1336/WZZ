using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 轮播图实体
    /// </summary>
    public class RotationChart
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 轮播图标题描述
        /// </summary>
        [StringLength(50)]
        public string title { set; get; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [StringLength(50)]
        public string imgurl { set; get; }

        /// <summary>
        /// 关联模块
        /// </summary>
        public virtual WZZModel WZZModel { set; get; }

        /// <summary>
        /// 模块的id
        /// </summary>
        [ForeignKey("WZZModel")]
        public int? WZZModelId { set; get; }

        /// <summary>
        /// 对应的文章id
        /// </summary>
        public int? ArticleId { set; get; }

        /// <summary>
        /// 关联文章
        /// </summary>
        public Article Article { set; get; }
    }
}
