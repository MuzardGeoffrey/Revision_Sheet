using System;

namespace RevisionSheet.DataAccess.Entities
{
        
    public class SheetEntities
    {
        public string Content { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public SheetEntities()
        {
        }

        public SheetEntities(string title, string content, int userId)
        {
            this.Title = title;
            this.Content = content;
        }

        public SheetEntities(int id, string title, string content, int userId)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
        }

    }
}