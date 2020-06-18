using System.Collections.Generic;

namespace Revision_Sheet.BusinessObject
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sheet> SheetList { get; set; }
    }
}