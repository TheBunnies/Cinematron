using Cinematron.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cinematron.DAL.Models
{
    public class Show : DbObject, IWatchable
    {
        public string Title {get; set;}
        public string Description {get; set;}
        public string Duration {get; set;}
        public string ThumbnailUrl {get; set;}
        [JsonIgnore]
        public List<Episode> Episodes {get; set;}
    }
}
