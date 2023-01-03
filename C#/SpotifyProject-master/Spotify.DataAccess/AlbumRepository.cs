using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Spotify.Services;
using MySql.Data.MySqlClient;

namespace Spotify.DataAccess
{


    public class AlbumDAL : AlbumDALInterface
    {
        public List<Album> GetAll()
        {
            List<Album> albums = new List<Album>();

            using (MySqlConnection con = Helper.MySqlConnect.Connection)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "SELECT id, title, artist, link, created FROM albums";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;

                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            int id = sdr["id"].GetHashCode();
                            string title = sdr["title"].ToString();
                            string artist = sdr["artist"].ToString();
                            string link = sdr["link"].ToString();
                            DateTime created = (DateTime)sdr["created"];
                            Album album = new Album(id, title, artist, link, created);
                            albums.Add(album);


                        }
                    }

                    con.Close();
                }
                return albums;
            }
        }

        public void AddAlbum(string title, string artist, string link, DateTime created)
        {
            using (MySqlConnection con = Helper.MySqlConnect.Connection)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO albums (title, artist, link, created) VALUES (@title, @artist, @link, @created)"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@artist", artist);
                        cmd.Parameters.AddWithValue("@link", link);
                        cmd.Parameters.AddWithValue("@created", created);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return;
            }
        }

        //GET Edit
        public List<Album> EditAlbum(int id)
        {
            List<Album> albums = new List<Album>();
            using (MySqlConnection con = Helper.MySqlConnect.Connection)
            {
                string query = "SELECT id, title, artist, link, created FROM albums WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query))
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = con;
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            
                            string title = sdr["title"].ToString();
                            string artist = sdr["artist"].ToString();
                            string link = sdr["link"].ToString();
                            DateTime created = (DateTime)sdr["created"];
                            Album album = new Album(id, title, artist, link, created);
                            albums.Add(album);
                        }
                    }
                    con.Close();
                }

                return albums;
            }

        }

        //POST Edit
        public void UpdateAlbum(int id, string title, string artist, string link)
        {
            using (MySqlConnection con = Helper.MySqlConnect.Connection)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE albums SET title = @title, artist = @artist, link = @link WHERE id = @id"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@artist", artist);
                            cmd.Parameters.AddWithValue("@link", link);
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            return;
        }

        public void DeleteAlbum(int id)
        {
            using (MySqlConnection con = Helper.MySqlConnect.Connection)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int result = con.Execute("delete from albums where id = @id", new { id = id }, commandType: CommandType.Text);
                return;
            }
        }
    }

}