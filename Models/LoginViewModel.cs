using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THU_FORM.Models
{
    public class LoginViewModel
    {
        public int id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "信箱帳號")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }
    }
}