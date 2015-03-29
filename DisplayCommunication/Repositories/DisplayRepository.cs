using System;
using DisplayCommon.Utils;
using DisplayExtensions.Models;
using Npgsql;

namespace DisplayCommunication.Repositories
{
    internal class DisplayRepository
    {
        internal Display SelectDisplayMessage(int messageId)
        {
            var display = new Display();
            var selectQuery = GetSelectQuery();
            using (var command = new NpgsqlCommand(selectQuery))
            {
                command.Parameters.AddWithValue("@MessageId", messageId);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    if (!dr.Read()) 
                        throw new Exception(String.Format("Nie znaleziono wpisu w bazie o id {0}.", messageId));

                    display.DisplayId = Convert.ToInt32(dr["Id"]);
                    display.Command = dr["Command"].ToString();
                    display.SerialPortName = dr["SerialPort"].ToString();
                    display.DisplayAddress = 0x20;
                }
            }

            return display;
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                SELECT 
	                S.id_sign Id,
	                S.config SerialPort,
	                SS.cmd Command
                FROM signs S
                JOIN signstx SS ON S.id_sign = SS.id_sign
                WHERE SS.index = @MessageId";
            return query;
        }
    }
}
