using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematron.DAL.Models
{
    public class Episode : DbObject
    {
        public string VideoUrl {get; set;}
        [Required]
        public Show Show {get; set;}
    }
}
