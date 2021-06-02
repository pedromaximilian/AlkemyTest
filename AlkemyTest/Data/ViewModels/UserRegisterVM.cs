using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data.ViewModels
{
    public class UserRegisterVM
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string PasswordConfirm { get; set; }
    }
}
