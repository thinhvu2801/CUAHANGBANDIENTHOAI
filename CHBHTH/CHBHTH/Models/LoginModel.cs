using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CHBHDT63131330.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Email")]
        public string userMail { get; set; }
        [Display(Name = "Mật khẩu")]
        public string password { get; set; }
    }
}