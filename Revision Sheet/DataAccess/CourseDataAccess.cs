using MySql.Data.MySqlClient;
using Revision_Sheet.BusinessObject;
using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using RevisionSheet.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace Revision_Sheet.DataAccess
{
    public class CourseDataAccess : ICourseDataAccess
    {
        public DbConnexion db = new DbConnexion();
        public CourseEntity Create(CourseEntity obj)
        {
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = $"INSERT INTO {Constants.COURSE_TABLE_NAME } ({Constants.COURSE_COLUMN_NAME_NAME}, {Constants.COURSE_COLUMN_NAME_USER_ID}) VALUES (@name, @user_id)";

                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@user_id", obj.UserId);

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
            return obj;
            //TODO : retourner l'objet de la bdd ou l'id
        }

        public int Delete(int id)
        {
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "DELETE FROM " + Constants.COURSE_TABLE_NAME + " WHERE " + Constants.COURSE_COLUMN_NAME_ID + " = " + id;
                id = 1;
                Object test = cmd.ExecuteScalar();
                Console.WriteLine(test);
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
        }

        public List<CourseEntity> FindAllCourseByUser(int userId)
        {
            List<CourseEntity> CourseEntities = new List<CourseEntity>();

            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = $"SELECT * FROM {Constants.CHAPTER_TABLE_NAME} WHERE {Constants.COURSE_COLUMN_NAME_USER_ID} = {userId}";

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        CourseEntity courseEntity = new CourseEntity();

                        courseEntity.Id = reader.GetInt32(0);
                        courseEntity.Name = reader.GetString(1);

                        CourseEntities.Add(courseEntity);
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

            return CourseEntities;
        }

        public CourseEntity FindById(int id)
        {
            CourseEntity course = new CourseEntity();
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.USER_TABLE_NAME + " WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    course.Id = reader.GetInt32(0);
                    course.UserId = reader.GetInt32(2);
                    course.Name = reader.GetString(1);
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
            return course;
        }

        public CourseEntity Update(int id, CourseEntity obj)
        {
            CourseEntity course = new CourseEntity();
            try
            {
                // Ouverture de la connexion SQL
                

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = db.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "UPDATE " + Constants.USER_TABLE_NAME + " SET '" + Constants.USER_COLUMN_NAME_FIRST_NAME + "' = " + obj.Name + ", '" + Constants.USER_COLUMN_NAME_LAST_NAME + "' " + obj.UserId +
                  "WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + obj.Id;

                // Exécution de la commande SQL
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    course.Id = reader.GetInt32(0);
                    course.UserId = reader.GetInt32(2);
                    course.Name = reader.GetString(1);
                    
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

            return course;
        }
    }
}