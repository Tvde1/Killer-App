using System;
using System.Data;
using System.Data.SqlClient;

namespace Killer_App.App_Data.Helpers.DAL
{
    public class ContextBase
    {
        private readonly string _connectionString;

        public ContextBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetData(string query)
        {
            try
            {
                using (var adapter = new SqlDataAdapter(query, _connectionString))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                //throw;
                return null;
            }
        }

        public DataTable GetData(SqlCommand command)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    command.Connection = conn;
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
                return null;
            }
        }
    }
}