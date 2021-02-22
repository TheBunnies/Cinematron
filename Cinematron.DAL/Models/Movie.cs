using Cinematron.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematron.DAL.Models
{
    public class Movie : DbObject, IWatchable
    {
        public string Title {get; set;}
        public string Description {get; set;}
        public string Duration {get; set;}
        public string ThumbnailUrl {get; set;}
        public string VideoUrl {get ;set;}
    }
}
