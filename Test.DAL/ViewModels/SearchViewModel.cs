using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class SearchViewModel
    {
        /// <summary>
        /// 标识符
        /// </summary>
        public string id { set; get; }

        /// <summary>
        /// 模块id
        /// </summary>
        public int ModelId { set; get; } 

        /// <summary>
        /// 第几页
        /// </summary>
        public int page { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        public int limit { set; get; }
    }
}
