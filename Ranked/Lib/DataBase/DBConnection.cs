using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Smod2;

namespace rank.Lib.DataBase
{
    class DBConnection
    {
        public MySqlConnection connection;
        public string ipaddress = ConfigManager.Manager.Config.GetStringValue("rank_sql_ipaddress", "127.0.0.1").Trim(' ');
        public string username = ConfigManager.Manager.Config.GetStringValue("rank_sql_username", "root").Trim(' ');
        public string password = ConfigManager.Manager.Config.GetStringValue("rank_sql_password", string.Empty).Trim(' ');
        public string database = ConfigManager.Manager.Config.GetStringValue("rank_sql_database", "scpsl").Trim(' ');

        public string table = ConfigManager.Manager.Config.GetStringValue("rank_sql_table", "rp").Trim(' ');

        public Plugin plugin;

        public DBConnection(Plugin plugin)
        {
            this.InitConnection();
            this.plugin = plugin;
        }

        public void InitConnection()
        {
            string connectionString = $"Server={ipaddress};Database={database};Uid={username};Password={password}";
            this.connection = new MySqlConnection(connectionString);
        }

        public void AddPoint(string steamid, int number)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"UPDATE {table} SET point=point+{number} WHERE steamid = '{steamid}'";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                plugin.Error("Exception detected.");
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetPoint(string steamid)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT `point` FROM `{table}` WHERE steamid = '{steamid}'";
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       return dr.GetInt32(0);
                    }
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                plugin.Error("Exception detected.");
                return 0;

            }
            finally
            {
                connection.Close();
            }
        }

        public void AddPlayer(string steamid)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"INSERT IGNORE INTO {table} (steamid) VALUES (@steamid)";
                cmd.Parameters.AddWithValue("@steamid", steamid);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                plugin.Error("Exception detected.");
            }
            finally
            {
                connection.Close();

            }
        }

        public void AddTable()
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"CREATE TABLE IF NOT EXISTS `{table}` (`steamid` VARCHAR(17) NOT NULL,`point` INT(11) NOT NULL DEFAULT '0',PRIMARY KEY(`steamid`))ENGINE = InnoDB;";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                plugin.Error("Exception detected.");
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
