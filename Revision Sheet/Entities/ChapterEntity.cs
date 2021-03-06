﻿using Revision_Sheet.BusinessObject;
using Revision_Sheet.DataAccess;
using RevisionSheet.DataAccess.IDataAccess;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class ChapterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public ChapterEntity()
        {
        }

        public ChapterEntity(string name, int courseId)
        {
            this.Name = name;
            this.CourseId = courseId;
        }

        public ChapterEntity(int id, string name, int courseId)
        {
            this.Id = id;
            this.Name = name;
            this.CourseId = courseId;
        }

        public Chapter ChapterConversion()
        {
            ISheetDataAccess sheetDataAccess = new SheetDataAccess();
            List<Sheet> sheets = new List<Sheet>();
            List<SheetEntity> sheetEntities = new List<SheetEntity>();

            sheetEntities = sheetDataAccess.FindAllSheetByChapter(this.Id);

            foreach (var sheetEntity in sheetEntities)
            {
                sheets.Add(sheetEntity.SheetConversion());
            }

            return new Chapter
            {
                Id = this.Id,
                Name = this.Name,
                SheetList = sheets,
                CourseId = this.CourseId
            };
        }
    }
}