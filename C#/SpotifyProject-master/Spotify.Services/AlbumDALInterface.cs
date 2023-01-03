using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Services
{
    public interface AlbumDALInterface
    {
            void AddAlbum(string title, string artist, string link, DateTime created);
            void UpdateAlbum(int id, string title, string artist, string link);
            List<Album> EditAlbum(int id);
            void DeleteAlbum(int id);
            List<Album> GetAll();
        
    }
}
