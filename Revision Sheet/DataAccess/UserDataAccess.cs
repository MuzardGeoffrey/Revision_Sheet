﻿using MySql.Data.MySqlClient;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using RevisionSheet.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace RevisionSheet.DataAccess.DataAccess
{
    public class UserDataAccess : DbConnexion, IUserDataAccess
    {
        public UserEntities Create(UserEntities obj)
        {
            try
            {
                this.connection.Open();

                MySqlCommand cmd = this.connection.CreateCommand();

                cmd.CommandText = "INSERT INTO " + Constants.USER_TABLE_NAME + " (" + Constants.USER_COLUMN_NAME_FIRST_NAME+ ", " + Constants.USER_COLUMN_NAME_LAST_NAME + ", " + Constants.USER_COLUMN_NAME_LOGIN + ", " + Constants.USER_COLUMN_NAME_PASSWORD + ") VALUES (@firstName, @lastName, @login, @password)";

                cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
                cmd.Parameters.AddWithValue("@lastName", obj.LastName);
                cmd.Parameters.AddWithValue("@login", obj.Login);
                cmd.Parameters.AddWithValue("@password", obj.Password);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return obj;

            //TODO : retourner l'objet de la bdd ou l'id
        }

        public int Delete(int id)
        {
            try
            {
                this.connection.Open();

                MySqlCommand cmd = this.connection.CreateCommand();

                cmd.CommandText = "DELETE FROM " + Constants.USER_TABLE_NAME +" WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;
                id = cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

            return id;

            //TODO : retourner l'id de l'element supprimer ou un bool
        }

        public List<UserEntities> FindAllUser()
        {
            List<UserEntities> usersEntities = new List<UserEntities>();

            try
            {
                this.connection.Open();

                MySqlCommand cmd = this.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.USER_TABLE_NAME;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        UserEntities userEntities = new UserEntities();
                        try
                        {
                            
                            userEntities.Id = Int32.Parse(String.Format("{0}", reader[0]));
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        userEntities.FirstName = String.Format("{0}", reader[1]);
                        userEntities.LastName = String.Format("{0}", reader[2]);
                        userEntities.Login = String.Format("{0}", reader[3]);

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
                this.connection.Close();
            }

            return usersEntities;
        }

        public UserEntities FindById(int id)
        {
            UserEntities user = new UserEntities();
            try
            {
                this.connection.Open();


                MySqlCommand cmd = this.connection.CreateCommand();

             
                cmd.CommandText = "SELECT * FROM "+ Constants.USER_TABLE_NAME +" WHERE "+ Constants.USER_COLUMN_NAME_ID + " = " + id;

                
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            user.Id = Int32.Parse(String.Format("{0}", reader[0]));
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        user.FirstName = String.Format("{0}", reader[1]);
                        user.LastName = String.Format("{0}", reader[2]);
                        user.Login = String.Format("{0}", reader[3]);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally 
            {
                this.connection.Close();
            }
            return user;
        }

        public UserEntities Update(int id, UserEntities obj)
        {
            UserEntities user = new UserEntities();
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "UPDATE " + Constants.USER_TABLE_NAME + " SET '" + Constants.USER_COLUMN_NAME_FIRST_NAME + "' = " + obj.FirstName + ", '" + Constants.USER_COLUMN_NAME_LAST_NAME + "' " + obj.LastName + ", " +
                  Constants.USER_COLUMN_NAME_LOGIN + "' " + obj.Login + ", " +
                  Constants.USER_COLUMN_NAME_PASSWORD + "' " + obj.Password + ", " +
                  "WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;

                // Exécution de la commande SQL
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            user.Id = Int32.Parse(String.Format("{0}", reader[0]));
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        user.FirstName = String.Format("{0}", reader[1]);
                        user.LastName = String.Format("{0}", reader[2]);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

            return user;
        }
    }
}