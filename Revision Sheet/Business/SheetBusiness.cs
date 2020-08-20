using Revision_Sheet.BusinessObject;
using Revision_Sheet.DataAccess;
using Revision_Sheet.IBusiness;
using RevisionSheet.DataAccess.Entities;
using RevisionSheet.DataAccess.IDataAccess;
using System;
using System.Collections.Generic;

namespace Revision_Sheet.Business
{
    public class SheetBusiness : ISheetBusiness
    {
        ISheetDataAccess sheetDataAccess = new SheetDataAccess();
        public Sheet Create(Sheet sheet)
        {
            if (sheet != null)
            {
                SheetEntity sheetEntity = new SheetEntity();
                sheetEntity = sheetDataAccess.Create(sheet.sheetEntityConversion());
                return sheetEntity.SheetConversion();
            }
            return null;
        }

        public bool Delete(int id)
        {
            bool boolReturn = false;
            sheetDataAccess.Delete(id);
            return boolReturn;
        }

        public List<Sheet> FindAllSheetByChapter(int chapterId)
        {
            List<Sheet> sheets = new List<Sheet>();
            List<SheetEntity> sheetEntities = new List<SheetEntity>();

            sheetEntities = sheetDataAccess.FindAllSheetByChapter(chapterId);

            foreach (var sheetEntity in sheetEntities)
            {
                sheets.Add(sheetEntity.SheetConversion());
            }

            return sheets;
        }

        public Sheet FindById(int id)
        {
            Sheet sheet = new Sheet();
            sheet = sheetDataAccess.FindById(id).SheetConversion();
            return sheet;
        }

        public Sheet Update(int id, Sheet obj)
        {
            Sheet sheet = new Sheet();
            sheet = sheetDataAccess.Update(id, obj.sheetEntityConversion()).SheetConversion();
            return sheet;

        }
    }
}