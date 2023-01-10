using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace FinalProject
{
    class GetSetData
    {
        MYDB db = new MYDB();

        FileStream file;

        public void saveFile(int id)
        {
            file = new FileStream("data.txt", FileMode.OpenOrCreate);

            StreamWriter write = new StreamWriter(file);
            write.WriteLine(id);

            write.Close();
            file.Close();
        }

        public int getFile()
        {
            file = new FileStream("data.txt", FileMode.OpenOrCreate);

            int tempGetFile;
            StreamReader read = new StreamReader(file);
            tempGetFile = Int32.Parse(read.ReadLine());

            read.Close();
            file.Close();

            return tempGetFile;
        }

        public int getId(string username)
        {
            string query = "SELECT id_users FROM users WHERE username = @usn";
            string column = "id_users";
            int tempId;

            MySqlParameter[] parameters = new MySqlParameter[1];

            parameters[0] = new MySqlParameter("@usn", MySqlDbType.VarChar);
            parameters[0].Value = username;

            tempId = Int32.Parse(db.readData(query, column, parameters));

            return tempId;
        }

        public int getTime(int id)
        {
            string query = "SELECT time FROM users WHERE id_users = @id";
            string column = "time";
            int tempTime;

            MySqlParameter[] parameters = new MySqlParameter[1];

            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id;

            tempTime = Int32.Parse(db.readData(query, column, parameters));

            return tempTime;
        }

        public string getUsername(int id)
        {
            string query = "SELECT username FROM users WHERE id_users = @id";
            string column = "username";
 
            MySqlParameter[] parameters = new MySqlParameter[1];

            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id;

            return db.readData(query, column, parameters);
        }

        public DataTable cekProfileData(string username, string password)
        {
            string query = "SELECT * FROM `users` WHERE `username` = @usn AND `password`= @pass";

            MySqlParameter[] parameters = new MySqlParameter[2];

            parameters[0] = new MySqlParameter("@usn", MySqlDbType.VarChar);
            parameters[0].Value = username;

            parameters[1] = new MySqlParameter("@pass", MySqlDbType.VarChar);
            parameters[1].Value = password;

            DataTable table = new DataTable();
            table = db.getData(query, parameters);

            return table;
        }

        public Boolean addProfile(string username, string password)
        {
            string query = "INSERT INTO `users`(`username`, `password`, `time`) VALUES (@usn, @pass, 0)";

            MySqlParameter[] parameters = new MySqlParameter[2];

            parameters[0] = new MySqlParameter("@usn", MySqlDbType.VarChar);
            parameters[0].Value = username;

            parameters[1] = new MySqlParameter("@pass", MySqlDbType.VarChar);
            parameters[1].Value = password;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean updateTime(int id, int times)
        {
            string query = "UPDATE users SET time = @tme WHERE id_users = @id";

            MySqlParameter[] parameters = new MySqlParameter[2];

            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id;

            parameters[1] = new MySqlParameter("@tme", MySqlDbType.Int32);
            parameters[1].Value = times;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable getOdr(int id_us, string name)
        {
            string query = "SELECT * FROM `odr` WHERE `id_users` = @id AND `odr_name`= @name";

            MySqlParameter[] parameters = new MySqlParameter[2];

            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id_us;

            parameters[1] = new MySqlParameter("@name", MySqlDbType.VarChar);
            parameters[1].Value = name;

            DataTable table = new DataTable();
            table = db.getData(query, parameters);

            return table;
        }

        public int getTotal(int id_us, string name)
        {
            string query = "SELECT total FROM odr WHERE id_users = @id AND odr_name = @name";
            string column = "total";
            int tempTtl;

            MySqlParameter[] parameters = new MySqlParameter[2];

            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id_us;

            parameters[1] = new MySqlParameter("@name", MySqlDbType.VarChar);
            parameters[1].Value = name;

            tempTtl = Int32.Parse(db.readData(query, column, parameters));

            return tempTtl;
        }

        public Boolean updateOdr(int id_us, string name, int total, int price)
        {
            string query = "UPDATE `odr` SET `total` = @ttl, `total_price`= @ttlp WHERE `id_users` = @id AND `odr_name`= @name";

            MySqlParameter[] parameters = new MySqlParameter[4];
            int newTotal = total + getTotal(id_us, name);
            int total_p = newTotal * price;

            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id_us;

            parameters[1] = new MySqlParameter("@name", MySqlDbType.VarChar);
            parameters[1].Value = name;

            parameters[2] = new MySqlParameter("@ttl", MySqlDbType.Int32);
            parameters[2].Value = newTotal;

            parameters[3] = new MySqlParameter("@ttlp", MySqlDbType.Int32);
            parameters[3].Value = total_p;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean insertOdr(int id_us, string name, int total, int price)
        {
            string query = "INSERT INTO `odr`(`odr_name`, `total`, `price`, `total_price`, `id_users`) VALUES (@name, @ttl, @prc, @ttlp, @id)";

            MySqlParameter[] parameters = new MySqlParameter[5];

            int total_p = total * price;

            parameters[0] = new MySqlParameter("@name", MySqlDbType.VarChar);
            parameters[0].Value = name;

            parameters[1] = new MySqlParameter("@ttl", MySqlDbType.Int32);
            parameters[1].Value = total;

            parameters[2] = new MySqlParameter("@prc", MySqlDbType.Int32);
            parameters[2].Value = price;

            parameters[3] = new MySqlParameter("@ttlp", MySqlDbType.Int32);
            parameters[3].Value = total_p;

            parameters[4] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[4].Value = id_us;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean UpAndInsOdr(int id_us, string name, int total, int price)
        {
            DataTable table = new DataTable();

            table = getOdr(id_us, name);

            if (table.Rows.Count > 0)
            {
                if(updateOdr(id_us, name, total, price))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if(insertOdr(id_us, name, total, price))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
