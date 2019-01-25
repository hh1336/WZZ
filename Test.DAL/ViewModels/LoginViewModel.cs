using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="邮箱不能为空")]
        public string email { set; get; }

        [Required(ErrorMessage ="密码不能为空")]
        public string pwd { set; get; }
    }
}
