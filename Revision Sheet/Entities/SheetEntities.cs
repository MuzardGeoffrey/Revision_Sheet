using System;

namespace RevisionSheet.DataAccess.Entities
{
        
    public class SheetEntities
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ChapterId { get; set; }

        public SheetEntities()
        {
        }

        public SheetEntities(string title, string content, int chapterId)
        {
            this.Title = title;
            this.Content = content;
            this.ChapterId = chapterId;
        }

        public SheetEntities(int id, string title, string content, int chapterId)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.ChapterId = chapterId;
        }

    }
}