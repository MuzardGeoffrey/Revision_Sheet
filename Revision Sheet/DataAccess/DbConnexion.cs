using MySql.Data.MySqlClient;
using RevisionSheet.DataAccess.Utils;
using System;

namespace RevisionSheet.DataAccess.DataAccess
{
    public class DbConnexion
    {
        protected MySqlConnection connection;

        private string conf = "SERVER=" + Constants.IPSERVER + ";DATABASE=" + Constants.DATABASE_NAME + ";UID=" + Constants.DATABASE_USER + ";PASSWORD=" + Constants.PASSWORD;

        protected DbConnexion()
        {
            InitConnexion();
        }

        private void InitConnexion()
        {
            try
            {
                this.connection = new MySqlConnection(conf);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}