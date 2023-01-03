using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    public class AlbumsModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string link { get; set; }
        public DateTime created { get; set; }
}
}
