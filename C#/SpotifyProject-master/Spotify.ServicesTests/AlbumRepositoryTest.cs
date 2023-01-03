using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Spotify.Business;
using MySql.Data.MySqlClient;

namespace Spotify.Services.Tests
{
    public class AlbumRepositoryTest : IAlbumRepository
    {
        public bool Delete(int id)
        {
            using (MySqlConnection con = Helper.MySqlConnect.Connection)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int result = con.Execute("delete from albums where id = @id", new { id = id }, commandType: CommandType.Text);
                return result != 0;
            }
        }

        public List<Album> GetAll()
        {
            List<Album> albums = new List<Album>();

            //    using (MySqlConnection con = Helper.MySqlConnect.Connection)
            //    {
            //        if (con.State == ConnectionState.Closed)
            //            con.Open();
            //        string query = "SELECT id, title, artist, link FROM albums";
            //        using (MySqlCommand cmd = new MySqlCommand(query))
            //        {
            //            cmd.Connection = con;

            //            using (MySqlDataReader sdr = cmd.ExecuteReader())
            //            {
            //                while (sdr.Read())
            //                {

            //                    albums.Add(new Album
            //                    {
            //                        id = sdr["id"].GetHashCode(),
            //                        title = sdr["title"].ToString(),
            //                        artist = sdr["artist"].ToString(),
            //                        link = sdr["link"].ToString()
            //                    });
            //                }
            //            }
            //            con.Close();
            //        }
            //    }
            return albums;
        }


        public int Insert(Album obj)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.AddDynamicParams(new { obj.title, obj.artist, obj.link, obj.created });
            return obj.id;

        }

        public int Update(Album obj)
        {
            DynamicParameters p = new DynamicParameters();
            obj.id = 2;
            p.AddDynamicParams(new { obj.id });
            return obj.id;

        }

        public List<Album> Edit(Album obj)
        {
            List<Album> albums = new List<Album>();
            //    using (MySqlConnection con = Helper.MySqlConnect.Connection)
            //    {
            //        string query = "SELECT * FROM albums WHERE id = @id";
            //        using (MySqlCommand cmd = new MySqlCommand(query))
            //        using (MySqlDataAdapter sda = new MySqlDataAdapter())
            //        {
            //            cmd.Parameters.AddWithValue("@id", obj.id);
            //            cmd.Connection = con;
            //            using (MySqlDataReader sdr = cmd.ExecuteReader())
            //            {
            //                while (sdr.Read())
            //                {
            //                    albums.Add(new Album
            //                    {
            //                        title = sdr["title"].ToString(),
            //                        artist = sdr["artist"].ToString(),
            //                        link = sdr["link"].ToString()

            //                    });
            //                }
            //            }
            //            con.Close();
            //        }

            return albums;
        }

    }
}
