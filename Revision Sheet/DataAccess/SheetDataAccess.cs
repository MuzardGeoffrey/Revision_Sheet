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
    public class SheetDataAccess : ISheetDataAccess
    {
        public DbConnexion db = new DbConnexion();
        public SheetEntity Create(SheetEntity obj)
        {
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "INSERT INTO " + Constants.SHEET_TABLE_NAME + " (" + Constants.SHEET_COLUMN_NAME_TITLE + ", " + Constants.SHEET_COLUMN_NAME_CONTENT + ", " + Constants.SHEET_COLUMN_NAME_CHAPTER_ID + ") VALUES (@title, @content, @chapter_id)";

                cmd.Parameters.AddWithValue("@title", obj.Title);
                cmd.Parameters.AddWithValue("@content", obj.Content);
                cmd.Parameters.AddWithValue("@chapter_id", obj.ChapterId);

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

                cmd.CommandText = "DELETE FROM " + Constants.SHEET_TABLE_NAME + " WHERE " + Constants.SHEET_COLUMN_NAME_ID + " = " + id;
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
        }

        public List<SheetEntity> FindAllSheetByChapter(int chapterId)
        {
            List<SheetEntity> sheetEntities = new List<SheetEntity>();
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.SHEET_TABLE_NAME + " WHERE " + Constants.SHEET_COLUMN_NAME_CHAPTER_ID + " = " + chapterId;

                IDataReader reader = cmd.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    SheetEntity sheet = new SheetEntity();
                    while (reader.Read())
                    {
                        sheet.Id = reader.GetInt32(0);
                        sheet.ChapterId = reader.GetInt32(3);
                        sheet.Title = reader.GetString(1);
                        sheet.Content = reader.GetString(2);
                    }
                    sheetEntities.Add(sheet);
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
            return sheetEntities;
        }

        public SheetEntity FindById(int id)
        {
            SheetEntity user = new SheetEntity();
            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.SHEET_TABLE_NAME + " WHERE " + Constants.SHEET_COLUMN_NAME_ID + " = " + id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user.Id = reader.GetInt32(0);
                    user.ChapterId = reader.GetInt32(3);
                    user.Title = reader.GetString(1);
                    user.Content = reader.GetString(2);
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

        public SheetEntity Update(int id, SheetEntity obj)
        {
            SheetEntity sheet = new SheetEntity();

            try
            {
                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "UPDATE " + Constants.SHEET_TABLE_NAME + " SET '" + Constants.SHEET_COLUMN_NAME_TITLE + "' = " + obj.Title + ", '" + Constants.SHEET_COLUMN_NAME_CONTENT + "' " + obj.Content + ", " +
                  Constants.SHEET_COLUMN_NAME_CHAPTER_ID + "' " + obj.ChapterId +
                  "WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sheet.Id = reader.GetInt32(0);
                    sheet.ChapterId = reader.GetInt32(3);
                    sheet.Title = reader.GetString(1);
                    sheet.Content = reader.GetString(2);
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
            return sheet;
        }
    }
}