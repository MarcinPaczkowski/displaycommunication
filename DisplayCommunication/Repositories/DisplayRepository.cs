using System;
using DisplayCommon.Utils;
using DisplayExtensions.Models;
using Npgsql;

namespace DisplayCommunication.Repositories
{
    internal class DisplayRepository
    {
        internal Display SelectDisplayMessage(int signId)
        {
            var display = new Display();
            var selectQuery = GetSelectQuery();
            using (var command = new NpgsqlCommand(selectQuery))
            {
                command.Parameters.AddWithValue("@SignId", signId);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    if (!dr.Read())
                        throw new Exception(String.Format("Nie znaleziono znaku o id {0}.", signId));

                    display.DisplayId = signId;
                    display.SerialPortName = dr["SerialPort"].ToString();
                    display.DisplayAddress = 0x20;
                }
            }

            return display;
        }

        internal void InserResult(int displayId, string result)
        {
            var insertQuery = GetInsertQuery();
            using (var command = new NpgsqlCommand(insertQuery))
            {
                command.Parameters.AddWithValue("@DisplayId", displayId);
                command.Parameters.AddWithValue("@Result", result);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();
                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                SELECT  config as SerialPort
                  FROM  signs
                 WHERE  id_sign = @SignId";
            return query;
        }

        private static string GetInsertQuery()
        {
            const string query = @"
                INSERT INTO signsrx
                     (id_sign 
                     ,dtime
                     ,reply)
                VALUES 
                     (@DisplayId
                     ,NOW()
                     ,@Result)";
            return query;
        }
    }
}
