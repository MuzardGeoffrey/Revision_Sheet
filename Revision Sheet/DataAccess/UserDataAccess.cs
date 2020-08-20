using MySql.Data.MySqlClient;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using RevisionSheet.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace RevisionSheet.DataAccess.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        public DbConnexion db = new DbConnexion();
        public UserEntity Create(UserEntity userEntity)
        {
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "INSERT INTO " + Constants.USER_TABLE_NAME + " (" + Constants.USER_COLUMN_NAME_LOGIN + ", " + Constants.USER_COLUMN_NAME_PASSWORD + ") VALUES (@login, @password)";

                cmd.Parameters.AddWithValue("@login", userEntity.Login);
                cmd.Parameters.AddWithValue("@password", userEntity.Password);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                db.connection.Close();
            }
            return userEntity;

            //TODO : retourner l'objet de la bdd ou l'id
        }

        public int Delete(int id)
        {
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = $"DELETE FROM {Constants.USER_TABLE_NAME} WHERE {Constants.USER_COLUMN_NAME_ID} = {id}";
                id = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                db.connection.Close();
            }

            return id;

            //TODO : retourner l'id de l'element supprimer ou un bool
        }

        public List<UserEntity> FindAllUser()
        {
            List<UserEntity> usersEntities = new List<UserEntity>();

            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = $"SELECT * FROM {Constants.USER_TABLE_NAME}";

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        UserEntity userEntities = new UserEntity();
                        
                        userEntities.Id = reader.GetInt32(0);
                        userEntities.Login = reader.GetString(1);

                        usersEntities.Add(userEntities);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                db.connection.Close();
            }

            return usersEntities;
        }

        public UserEntity FindById(int id)
        {
            UserEntity userEntity = new UserEntity();
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.USER_TABLE_NAME + " WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userEntity.Id =  reader.GetInt32(0);
                    userEntity.Login = reader.GetString(1);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                db.connection.Close();
            }
            return userEntity;
        }

        public bool Login(UserEntity userEntity)
        {
            bool log = false;
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = $"SELECT {Constants.USER_COLUMN_NAME_LOGIN} FROM {Constants.USER_TABLE_NAME} WHERE {Constants.USER_COLUMN_NAME_LOGIN} = '{userEntity.Login}' AND {Constants.USER_COLUMN_NAME_PASSWORD} = '{userEntity.Password}'";

                IDataReader reader = cmd.ExecuteReader();

                if (reader.FieldCount > 0)
                {
                    log = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                db.connection.Close();
            }

            return log;
        }

        public UserEntity Update(int id, UserEntity userEntity)
        {
            UserEntity user = new UserEntity();
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "UPDATE " + Constants.USER_TABLE_NAME + " SET '" + Constants.USER_COLUMN_NAME_LOGIN + "' " + userEntity.Login + ", " +
                  Constants.USER_COLUMN_NAME_PASSWORD + "' " + userEntity.Password + ", " +
                  "WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;

                // Exécution de la commande SQL
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            user.Id = Int32.Parse(reader.GetString(0));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        user.Login = reader.GetString(1);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                db.connection.Close();
            }

            return user;
        }
    }
}