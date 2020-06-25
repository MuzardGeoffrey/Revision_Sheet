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
                return null;
            }
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sheet> FindAll()
        {
            throw new NotImplementedException();
        }

        public Sheet FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Sheet Update(int id, Sheet obj)
        {
            throw new NotImplementedException();
        }
    }
}