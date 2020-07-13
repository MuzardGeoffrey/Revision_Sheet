using MySql.Data.MySqlClient;
using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using RevisionSheet.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace Revision_Sheet.DataAccess
{
    public class ChapterDataAccess : IChapterDataAccess
    {
        public DbConnexion db = new DbConnexion();
        public ChapterEntity Create(ChapterEntity obj)
        {
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "INSERT INTO " + Constants.CHAPTER_TABLE_NAME + " (" + Constants.CHAPTER_COLUMN_NAME_NAME + ", " + Constants.CHAPTER_COLUMN_NAME_COURSE_ID + ") VALUES (@name, @user_id)";

                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@user_id", obj.CourseId);

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
        }

        public int Delete(int id)
        {
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = $"DELETE FROM {Constants.CHAPTER_TABLE_NAME} WHERE {Constants.CHAPTER_COLUMN_NAME_ID} = {id}";
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

        public List<ChapterEntity> FindAllChapterByCourse(int CourseId)
        {
            List<ChapterEntity> chapterEntities = new List<ChapterEntity>();

            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = $"SELECT * FROM {Constants.CHAPTER_TABLE_NAME} WHERE {Constants.CHAPTER_COLUMN_NAME_COURSE_ID} = {CourseId}";

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        ChapterEntity chapterEntity = new ChapterEntity();

                        chapterEntity.Id = reader.GetInt32(0);
                        chapterEntity.Name = reader.GetString(1);

                        chapterEntities.Add(chapterEntity);
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

            return chapterEntities;
        }

        public ChapterEntity FindById(int id)
        {
            ChapterEntity chapter = new ChapterEntity();
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.USER_TABLE_NAME + " WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    chapter.Id = reader.GetInt32(0);
                    chapter.CourseId = reader.GetInt32(2);
                    chapter.Name = reader.GetString(1);   
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
            return chapter;
        }

        public ChapterEntity Update(int id, ChapterEntity obj)
        {
            ChapterEntity chapter = new ChapterEntity();
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "UPDATE " + Constants.USER_TABLE_NAME + " SET '" + Constants.USER_COLUMN_NAME_FIRST_NAME + "' = " + obj.Name + ", '" + Constants.USER_COLUMN_NAME_LAST_NAME + "' " + obj.CourseId +
                  "WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + obj.Id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    chapter.Id = reader.GetInt32(0);
                    chapter.CourseId = reader.GetInt32(2);
                    chapter.Name = reader.GetString(1);
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

            return chapter;
        }
    }
}