using Cinematron.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematron.Views.ViewModels
{
    public class MovieAddViewModel
    {
        [Required]
        public string Name {get; set;}
        public string Description {get; set;}
        [Required]
        public string Duration {get; set;}
        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Title {get; set;}
        [Required]
        [AllowedExtensions(new string[] { ".avi", ".mkv", ".mp4" })]
        public IFormFile Movie {get; set;}
    }
}
