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

        /// <summary>
        /// 排序名称
        /// </summary>
        public string field { set; get; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public string order { set; get; }

        /// <summary>
        /// 筛选的标题
        /// </summary>
        public string title { set; get; }

        /// <summary>
        /// 筛选发布时间
        /// </summary>
        public DateTime? actiontime { set; get; }

        /// <summary>
        /// 筛选发布时间
        /// </summary>
        public DateTime? endtime { set; get; }
    }
}
