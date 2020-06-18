using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class ChapterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SheetEntity> Sheets { get; set; }

        public ChapterEntity()
        {
        }

        public ChapterEntity(string name, List<SheetEntity> sheets)
        {
            this.Name = name;
            this.Sheets = sheets;
        }

        public ChapterEntity(int id, string name, List<SheetEntity> sheets)
        {
            this.Id = id;
            this.Name = name;
            this.Sheets = sheets;
        }
    }
}