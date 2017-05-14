using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace Killer_App.Helpers.DAL.Contexts
{
    internal class ContextBase
    {
        private static readonly string ConnectionString = "xd";
        
        public static DataTable GetData(string query)
        {
            using (var adapter = new SqlDataAdapter(query, ConnectionString))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static Song CreateSong(DataRow row)
        {
            return row == null ? null : new Song((int)row["SongPk"], (string)row["Name"], (TimeSpan)row["Duration"]);
        }

        public static Album CreateAlbum(DataRow row)
        {
            return row == null ? null : new Album((int) row["AlbumPk"], (string) row["Name"]);
        }

        public static User CreateUser(DataRow row)
        {
            
        }

        public static Artist CreateArtist(DataRow row)
        {
            return  row == null ? null : new Artist((int) row["ArtistPk"], )
        }

        public static List<T> CreateList<T>(DataTable table, Func<DataRow, T> function)
        {
            return (from DataRow tableRow in table.Rows select function(tableRow)).ToList();
        }
    }
}