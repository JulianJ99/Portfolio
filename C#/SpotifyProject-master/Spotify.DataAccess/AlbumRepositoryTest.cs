using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;
using Spotify.Services;

namespace Spotify.DataAccess
{
        public class AlbumTestDAL : AlbumDALInterface
        {
            AlbumDALInterface albumTestDAL;
            private int id;
            private string title;
            private string artist;
            private string link;
            private DateTime created;

            public string getTitle()
            {
                return title;
            }
            public int getID()
            {
                return id;
            }
            public string getArtist()
            {
                return artist;
            }
            public string getLink()
            {
                return link;
            }
            public DateTime getCreated()
            {
                return created;
            }



        public void AddAlbum(string title, string artist, string link, DateTime created)
            {
                this.title = title;
                this.artist = artist;
                this.link = link;
                this.created = created;
            }

        public void UpdateAlbum(int id, string title, string artist, string link)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
            this.link = link;
        }

        public List<Album> GetAll()
        {
            List<Album> albums = albumTestDAL.GetAll();
            return albums;
        }

        public List<Album> EditAlbum(int id)
        {
            List<Album> albums = new List<Album>();
            return albums;
        }

        public void DeleteAlbum(int id)
        {
            return;
        }
    }
 }
