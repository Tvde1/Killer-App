using System;
using System.Data;
using System.Data.SqlClient;

namespace Killer_App.Helpers.DAL
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

        public bool ExecuteQuery(string query)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    using (var comm = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExecuteQuery(SqlCommand query)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    query.Connection = conn;
                    conn.Open();
                    query.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}