using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematron.Views.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName {get; set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [Required]
        public IFormFile Avatar {get; set;}
    }
}
