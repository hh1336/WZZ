using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class DelArticleResultModel
    {
        /// <summary>
        /// 处理结果
        /// </summary>
        public bool code { set; get; }

        /// <summary>
        /// 所有文章的对应的url
        /// </summary>
        public List<string> list { set; get; }
    }
}
