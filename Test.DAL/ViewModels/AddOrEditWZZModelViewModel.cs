using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
    public class AddOrEditWZZModelViewModel
    {
        /// <summary>
        /// 用来接收模块id
        /// </summary>
        public int? id { set; get; }

        /// <summary>
        /// 用来接收pid
        /// </summary>
        public int? pid { set; get; }
    }
}
