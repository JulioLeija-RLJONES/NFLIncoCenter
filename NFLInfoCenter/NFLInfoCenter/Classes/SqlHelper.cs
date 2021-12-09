using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using NFLInfoCenter.Classes;
using System.Configuration;

namespace NFLInfoCenter.Classes
{

    public class SqlHelper : IDisposable
    {
        protected readonly ConnectionStringManager ConnStrMgr;
        protected readonly SqlConnection Connection;

        ConnectionStringSettingsCollection settings =
        ConfigurationManager.ConnectionStrings;

        public SqlHelper(string connectionName)
        {
            ConnStrMgr = new ConnectionStringManager(connectionName);
            Connection = new SqlConnection(ConnStrMgr.ToString());
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();
        }

        public bool Open()
        {
            try
            {
           
                if (Connection != null)
                {
                    Connection.Open();
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(Exception ex)
            {
                string msg = "experiencing connection issues..";
                Console.WriteLine(msg);
                return false;
            }
        }

        public async Task OpenAsync()
        {
            if (Connection != null)
                await Connection.OpenAsync();
        }

        public List<SqlTableRow> ExecuteReader(string sql, IEnumerable<SqlParameter> parameters = null)
        {
            List<SqlTableRow> allRows = new List<SqlTableRow>();

            if (parameters == null)
                parameters = new List<SqlParameter>();

            using (var cmd = new SqlCommand(sql, Connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SqlTableRow row = new SqlTableRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // Process each column as appropriate
                        object fieldValue = reader.GetFieldValue<object>(i);
                        row.FieldValues.Add(fieldValue);
                    }
                    if (row.FieldValues.Count > 0)
                        allRows.Add(row);
                }
                reader.Close();
            }
            return allRows;
        }

        public async Task<List<SqlTableRow>>
            ExecuteReaderAsync(string sql, IEnumerable<SqlParameter> parameters = null)
        {
            List<SqlTableRow> allRows = new List<SqlTableRow>();

            if (parameters == null)
                parameters = new List<SqlParameter>();

            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(parameters.ToArray());

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    SqlTableRow row = new SqlTableRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // Process each column as appropriate
                        object fieldValue = await reader.GetFieldValueAsync<object>(i);
                        row.FieldValues.Add(fieldValue);
                    }
                    if (row.FieldValues.Count > 0)
                        allRows.Add(row);
                }
            }
            return allRows;
        }
    }

}
