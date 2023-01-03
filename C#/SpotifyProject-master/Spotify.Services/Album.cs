using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Services
{

    public class Album
    {
        public Album(int id, string title, string artist, string link, DateTime created)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
            this.link = link;
            this.created = created;
        }



        public int id { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string link { get; set; }
        public DateTime created { get; set; }
        
    }
}
