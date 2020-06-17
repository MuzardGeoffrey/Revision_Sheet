using MySql.Data.MySqlClient;
using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using RevisionSheet.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Revision_Sheet.DataAccess
{
    public class CourseDataAccess : DbConnexion, ICourseDataAccess
    {
        public CourseEntities Create(CourseEntities obj)
        {
            try
            {
                this.connection.Open();

                MySqlCommand cmd = this.connection.CreateCommand();

                cmd.CommandText = "INSERT INTO" + Constants.COURSE_TABLE_NAME + " (" + Constants.COURSE_COLUMN_NAME_NAME + ", " + Constants.COURSE_COLUMN_NAME_USER_ID + ") VALUES (@name, @user_id)";

                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@user_id", obj.UserId);

                cmd.ExecuteNonQuery();

            }
            catch(Exception e) 
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
                this.connection.Close();
            }

            return id;
        }

        public List<CourseEntities> FindAllChaptersByCourse(int courseId)
        {
            List<CourseEntities> coursesEntities = new List<CourseEntities>();

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
                        CourseEntities courseEntities = new CourseEntities();
                        try
                        {

                            courseEntities.Id = Int32.Parse(String.Format("{0}", reader[0]));
                            courseEntities.UserId = Int32.Parse(String.Format("{0}", reader[2]));
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        courseEntities.Name = String.Format("{0}", reader[1]);
                        

                        coursesEntities.Add(courseEntities);
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

            return coursesEntities;
        }

        public CourseEntities FindById(int id)
        {
            CourseEntities course = new CourseEntities();
            try
            {
                this.connection.Open();


                MySqlCommand cmd = this.connection.CreateCommand();


                cmd.CommandText = "SELECT * FROM " + Constants.USER_TABLE_NAME + " WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;


                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            course.Id = Int32.Parse(String.Format("{0}", reader[0]));
                            course.UserId = Int32.Parse(String.Format("{0}", reader[2]));
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        course.Name = String.Format("{0}", reader[1]);
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
            return course;
        }

        public CourseEntities Update(int id, CourseEntities obj)
        {
            CourseEntities course = new CourseEntities();
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "UPDATE " + Constants.USER_TABLE_NAME + " SET '" + Constants.USER_COLUMN_NAME_FIRST_NAME + "' = " + obj.Name + ", '" + Constants.USER_COLUMN_NAME_LAST_NAME + "' " + obj.UserId +
                  "WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + obj.Id;

                // Exécution de la commande SQL
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            course.Id = Int32.Parse(String.Format("{0}", reader[0]));
                            course.UserId = Int32.Parse(String.Format("{0}", reader[2]));
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        course.Name = String.Format("{0}", reader[1]);
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

            return course;
        }
    }
}
