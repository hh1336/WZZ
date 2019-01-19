using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    /// <summary>
    /// 每个模块的文章和模块信息
    /// </summary>
    public class ModelArticle
    {
        /// <summary>
        /// 存放模块信息
        /// </summary>
        public WZZModel WZZModel { set; get; }

        /// <summary>
        /// 存放对应模块下的文章信息
        /// </summary>
        public List<Article> Articles { set; get; }
    }
}
