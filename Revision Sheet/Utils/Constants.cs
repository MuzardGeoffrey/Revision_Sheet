using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionSheet.DataAccess.Utils
{
    class Constants
    {
        public const string DATABASE_NAME = "sheet", PASSWORD = "", DATABASE_USER = "root", IPSERVER = "127.0.0.1";

        public const string USER_TABLE_NAME = "user", USER_COLUMN_NAME_ID = "id", USER_COLUMN_NAME_FIRST_NAME = "firstName", USER_COLUMN_NAME_LAST_NAME = "lastName", USER_COLUMN_NAME_LOGIN = "login", USER_COLUMN_NAME_PASSWORD = "password";

        public const string SHEET_TABLE_NAME = "sheet", SHEET_COLUMN_NAME_ID = "id", SHEET_COLUMN_NAME_TITLE = "title", SHEET_COLUMN_NAME_CONTENT = "content", SHEET_COLUMN_NAME_CHAPTER_ID = "chapter_id";

        public const string CHAPTER_TABLE_NAME = "chapter", CHAPTER_COLUMN_NAME_ID = "id", CHAPTER_COLUMN_NAME_NAME = "name", CHAPTER_COLUMN_NAME_COURSE_ID = "course_id";

        public const string COURSE_TABLE_NAME = "course", COURSE_COLUMN_NAME_ID = "id", COURSE_COLUMN_NAME_NAME = "name", COURSE_COLUMN_NAME_USER_ID = "user_id";
    }
}
