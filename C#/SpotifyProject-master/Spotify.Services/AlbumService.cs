using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spotify.Services
{
    public class AlbumService
    {

        public class AlbumLogic
        {
            AlbumDALInterface albumDAL;

            public AlbumLogic(AlbumDALInterface albumDAL)
            {
                this.albumDAL = albumDAL;
            }

            public List<Album> GetAll()
            {
                List<Album> albums = albumDAL.GetAll();
                return albums;
            }

            public Album AddAlbum(int id, string title, string artist, string link, DateTime created)
            {
                albumDAL.AddAlbum(title, artist, link, created);
                return null;
            }

            public List<Album> EditAlbum(int id)
            {
                var album = albumDAL.EditAlbum(id);
                return album;
            }

            public Album UpdateAlbum(int id, string title, string artist, string link, DateTime created)
            {
                albumDAL.UpdateAlbum(id, title, artist, link);
                return null;
            }

            public Album DeleteAlbum(int id)
            {
                albumDAL.DeleteAlbum(id);
                return null;
            }

        }
    }
}
