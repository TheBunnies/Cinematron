using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematron.Views.ViewModels
{
    public class ShowAddViewModel
    {
        [Required]
        public string Name {get; set;}
        public string Description {get; set;}
        [Required]
        public string AverageDuration {get; set;}
        [Required]
        public IFormFile Title {get; set;}
        [Required]
        public IFormFileCollection Episodes {get; set;}
    }
}
