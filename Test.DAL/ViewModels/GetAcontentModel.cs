using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.ViewModels
{
    public class GetAcontentModel
    {
        /// <summary>
        /// 没有小节标题的文章
        /// </summary>
        public List<ArticleConTent> nullheadAc { set; get; }

        /// <summary>
        /// 小节标题和对应的内容
        /// </summary>
        public List<Subheading> Subheadings { set; get; }

    }
}
