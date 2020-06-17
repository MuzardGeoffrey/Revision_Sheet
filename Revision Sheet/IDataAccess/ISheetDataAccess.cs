using RevisionSheet.DataAccess.Entities;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.IDataAccess
{
    internal interface ISheetDataAccess : IBaseDataAccess<SheetEntities>
    {
        public List<SheetEntities> FindAllSheetByChapter();
    }
}