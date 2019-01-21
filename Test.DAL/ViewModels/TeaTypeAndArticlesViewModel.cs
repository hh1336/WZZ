using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class TeaTypeAndArticlesViewModel
    {
        public TeaType teaType { set; get; }
        public List<Article> articles { set; get; }
    }
}
