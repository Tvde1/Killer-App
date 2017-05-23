﻿using System;
using System.Data.SqlClient;
using Killer_App.App_Data.DAL;

namespace Killer_App.App_Data.Providers
{
    public class Provider
    {
        public string ConnectionString { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Killer-App.mdf;Integrated Security=True";

        public ArtistProvider ArtistProvider { get; }
        public SongProvider SongProvider { get; }
        public AlbumProvider AlbumProvider { get; }
        public UserProvider UserProvider { get; }

        internal Provider()
        {
            var contextBase = new ContextBase(ConnectionString);

            UserProvider = new UserProvider(this, contextBase);
            ArtistProvider = new ArtistProvider(this, contextBase);
            SongProvider = new SongProvider(this, contextBase);
            AlbumProvider = new AlbumProvider(this, contextBase);
        }

        public Exception TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open(); // throws if connection string is invalid
                    conn.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}