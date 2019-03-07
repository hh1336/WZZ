using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    /// <summary>
    /// 用于接收轮播图信息
    /// </summary>
    public class RotationChartInputModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? id { set; get; }

        /// <summary>
        /// 轮播图标题描述
        /// </summary>
        public string title { set; get; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string imgurl { set; get; }

        /// <summary>
        /// 模块的id
        /// </summary>
        public int? WZZModelId { set; get; }

        /// <summary>
        /// 对应的文章id
        /// </summary>
        public int? ArticleId { set; get; }

    }
}
