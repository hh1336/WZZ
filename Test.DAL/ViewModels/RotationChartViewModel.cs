using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class RotationChartViewModel
    {
        /// <summary>
        /// 首页的轮播图
        /// </summary>
        public List<RotationChart> HomeRotationChart { set; get; }

        /// <summary>
        /// 茶类型的轮播图
        /// </summary>
        public List<RotationChart> TeaTypeRotationChart { set; get; }

        /// <summary>
        /// 茶故事的轮播图
        /// </summary>
        public List<RotationChart> StoryRotationChart { set; get; }
    }
}
