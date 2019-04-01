using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class VisitamountNewDataViewModal
    {
        /// <summary>
        /// 今天的浏览量
        /// </summary>
        public int ToDayVisi { set; get; }

        /// <summary>
        /// 本周的浏览量
        /// </summary>
        public int ToWeekVisi { set; get; }

        /// <summary>
        /// 周一的时间
        /// </summary>
        public DateTime ToWeek { set; get; }

        /// <summary>
        /// 周日的时间
        /// </summary>
        public DateTime LastWeekDay { set; get; }

        /// <summary>
        /// 本月的浏览量
        /// </summary>
        public int ToMonthVisi { set; get; }

        /// <summary>
        /// 本月一号
        /// </summary>
        public DateTime ToMonthFirst { set; get; }

        /// <summary>
        /// 本月的月末时间
        /// </summary>
        public DateTime ToMonthLast { set; get; }

        /// <summary>
        /// 点击量最高的文章
        /// </summary>
        public Article HotArticle { set; get; }
    }
}
