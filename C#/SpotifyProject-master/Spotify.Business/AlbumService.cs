using Autofac;
using Spotify.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify.DataAccess;

namespace Spotify.Services
{
    public class AlbumService
    {

        public class AlbumLogic
        {
            Album.AlbumDALInterface albumDAL;

            public AlbumLogic(Album.AlbumDALInterface albumDAL)
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

                var album = new Album(id, title, artist, link, created);
                albumDAL.AddAlbum(title, artist, link, created);
                return album;
            }

            public List<Album> EditAlbum(int id)
            {
                var albums = albumDAL.EditAlbum(id);
                return albums;
            }

            public Album UpdateAlbum(int id, string title, string artist, string link, DateTime created)
            {
                var album = new Album(id, title, artist, link, created);
                albumDAL.UpdateAlbum(id, title, artist, link);
                return album;
            }

            public Album DeleteAlbum(int id)
            {
                albumDAL.DeleteAlbum(id);
                return null;
            }

        }
    }
}
