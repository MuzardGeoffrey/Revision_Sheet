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
                db.connection.Open();

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
                db.connection.Open();

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
                db.connection.Open();

                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.SHEET_TABLE_NAME + " WHERE " + Constants.SHEET_COLUMN_NAME_CHAPTER_ID + " = " + chapterId;

                IDataReader reader = cmd.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    SheetEntity sheet = new SheetEntity();
                    while (reader.Read())
                    {
                        for (int k = 0; k < reader.FieldCount; k++)
                        {
                            try
                            {
                                sheet.Id = Int32.Parse(String.Format("{0}", reader[0]));
                                sheet.ChapterId = Int32.Parse(String.Format("{0}", reader[3]));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            sheet.Title = String.Format("{0}", reader[1]);
                            sheet.Content = String.Format("{0}", reader[2]);
                        }
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
                db.connection.Open();

                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM " + Constants.SHEET_TABLE_NAME + " WHERE " + Constants.SHEET_COLUMN_NAME_ID + " = " + id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            user.Id = Int32.Parse(String.Format("{0}", reader[0]));
                            user.ChapterId = Int32.Parse(String.Format("{0}", reader[3]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        user.Title = String.Format("{0}", reader[1]);
                        user.Content = String.Format("{0}", reader[2]);
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

        public SheetEntity Update(int id, SheetEntity obj)
        {
            SheetEntity sheet = new SheetEntity();

            try
            {
                db.connection.Open();

                MySqlCommand cmd = db.connection.CreateCommand();

                cmd.CommandText = "UPDATE " + Constants.SHEET_TABLE_NAME + " SET '" + Constants.SHEET_COLUMN_NAME_TITLE + "' = " + obj.Title + ", '" + Constants.SHEET_COLUMN_NAME_CONTENT + "' " + obj.Content + ", " +
                  Constants.SHEET_COLUMN_NAME_CHAPTER_ID + "' " + obj.ChapterId +
                  "WHERE " + Constants.USER_COLUMN_NAME_ID + " = " + id;

                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            sheet.Id = Int32.Parse(String.Format("{0}", reader[0]));
                            sheet.ChapterId = Int32.Parse(String.Format("{0}", reader[3]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        sheet.Title = String.Format("{0}", reader[1]);
                        sheet.Content = String.Format("{0}", reader[2]);
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

            return sheet;
        }
    }
}