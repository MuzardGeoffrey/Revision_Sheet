using MySql.Data.MySqlClient;
using RevisionSheet.DataAccess.Utils;
using System;
using System.Data;

namespace RevisionSheet.DataAccess.DataAccess
{
    public class DbConnexion
    {
        public MySqlConnection connection;

        private string conf = "SERVER=" + Constants.IPSERVER + ";DATABASE=" + Constants.DATABASE_NAME + ";UID=" + Constants.DATABASE_USER + ";PASSWORD=" + Constants.PASSWORD;

        public DbConnexion()
        {
            if (connection.State == ConnectionState.Open)
            {
                InitConnexion();
            }
        }

        private void InitConnexion()
        {
            try
            {
                this.connection = new MySqlConnection(conf);
                this.connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}