using RevisionSheet.DataAccess.Entities;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.IDataAccess
{
    internal interface ISheetDataAccess : IBaseDataAccess<SheetEntity>
    {
        public List<SheetEntity> FindAllSheetByChapter(int chapterId);
    }
}