using Revision_Sheet.DataAccess;
using RevisionSheet.DataAccess.DataAccess;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;

namespace Revision_Sheet.BusinessObject
{
    public class Sheet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ChapterId { get; set; }

        public Sheet()
        {
        }

        public Sheet(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public Sheet(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public SheetEntity sheetEntityConversion()
        {
            ISheetDataAccess sheetDataAccess = new SheetDataAccess();
            return new SheetEntity
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content,
                ChapterId = this.ChapterId
            };
        }
    }
}