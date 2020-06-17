using System;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class ChapterEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SheetEntities> Sheets { get; set; }

        public ChapterEntities()
        {
        }

        public ChapterEntities(string name, List<SheetEntities> sheets)
        {
            this.Name = name;
            this.Sheets = sheets;
        }

        public ChapterEntities(int id, string name, List<SheetEntities> sheets)
        {
            this.Id = id;
            this.Name = name;
            this.Sheets = sheets;
        }
    }
}