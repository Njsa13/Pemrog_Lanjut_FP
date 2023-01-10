using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using MySql.Data.MySqlClient;

namespace FinalProject
{
    public class MYDB : DbContext
    {
        public MYDB()
           : base("name=MYDB")
        {
        }

        private MySqlConnection connection =
            new MySqlConnection("server=localhost;port=3306;username=root;password=;database=final_project");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public DataTable getData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public string readData(string query, string column, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            openConnection();

            string dataTemp = "No Data";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                dataTemp = reader[column].ToString();              
            }

            closeConnection();

            return dataTemp;
        }

        public int setData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            openConnection();

            int commandState = command.ExecuteNonQuery();

            closeConnection();

            return commandState;
        }
    }
}