using Autofac;
using Spotify.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Services
{
    public class AlbumService
    {
        static IContainer _container;
        static AlbumService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();
            _container = builder.Build();
        }



        public class AlbumLogic
        {
            Album.AlbumDALInterface albumDAL;

            public AlbumLogic(Album.AlbumDALInterface albumDAL)
            {
                this.albumDAL = albumDAL; 
            }


            public Album AddAlbum(int id, string title, string artist, string link, DateTime created)
            {
                
                var album = new Album(id, title, artist, link, created);
                albumDAL.AddAlbum(id, title, artist, link, created);
                return album;
            }

        }
    

        public static bool Delete(int id)
        {
            return _container.Resolve<IAlbumRepository>().Delete(id);
        }

        public static List<Album> GetAll()
        {
            return _container.Resolve<IAlbumRepository>().GetAll();
        }


        public static Album Save(Album obj)
        {
                obj.id = _container.Resolve<IAlbumRepository>().Insert(obj);
            return obj;
        }

        public static Album Update(Album obj)
        {
                _container.Resolve<IAlbumRepository>().Update(obj);
            return obj;
        }

        public static List<Album> Edit(Album obj)
        {
            return _container.Resolve<IAlbumRepository>().Edit(obj);
        }

    }
}
