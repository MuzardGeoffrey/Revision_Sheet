using Revision_Sheet.BusinessObject;

namespace RevisionSheet.DataAccess.Entities
{
    public class SheetEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ChapterId { get; set; }

        public SheetEntity()
        {
        }

        public SheetEntity(string title, string content, int chapterId)
        {
            this.Title = title;
            this.Content = content;
            this.ChapterId = chapterId;
        }

        public SheetEntity(int id, string title, string content, int chapterId)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.ChapterId = chapterId;
        }

        public Sheet SheetConversion()
        {
            return new Sheet
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content,
                ChapterId = this.ChapterId
            };
        }
    }
}