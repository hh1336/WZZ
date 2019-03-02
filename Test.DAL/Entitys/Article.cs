using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entitys
{
    /// <summary>
    /// 文章表实体
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(50)]
        public string title { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime createTime { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? updateTime { set; get; }

        /// <summary>
        /// 作者
        /// </summary>
        [StringLength(30)]
        public string author { set; get; }

        /// <summary>
        /// 来源
        /// </summary>
        public string source { set; get; }

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
        /// 茶类型id
        /// </summary>
        public int? TeaTypeId { set; get; }


        /// <summary>
        /// 是否可显示
        /// </summary>
        public int isShow { set; get; }

        /// <summary>
        /// 关联小节段落
        /// </summary>
        public ICollection<Subheading> Subheadings { set; get; }

        /// <summary>
        /// 关联文章内容
        /// </summary>
        public ICollection<ArticleConTent> ArticleConTents { set; get; }

        /// <summary>
        /// 关联轮播图
        /// </summary>
        public ICollection<RotationChart> RotationCharts { set; get; }



    }
}
