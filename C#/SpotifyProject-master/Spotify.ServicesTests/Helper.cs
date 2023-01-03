using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Services.Tests
{
    class Helper
    {
        public static class MySqlConnect
        {
            private static MySqlConnection _Connection;
            public static MySqlConnection Connection
            {
                get
                {
                    if (_Connection == null)
                    {
                        string csb = @"server=127.0.0.1; user id=root; password=''; database=spotify";
                        _Connection = new MySqlConnection(csb);
                    }

                    if (_Connection.State == ConnectionState.Closed)
                        try
                        {
                            _Connection.Open();
                        }
                        catch (Exception)
                        {
                            //handle your exception here
                        }
                    return _Connection;
                }
            }
        }
    }
}
