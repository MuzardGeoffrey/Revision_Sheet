using RevisionSheet.DataAccess.Entities;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.IDataAccess
{
    internal interface ICourseDataAccess : IBaseDataAccess<CourseEntity>
    {
        public List<CourseEntity> FindAllCourseByUser(int courseId);
    }
}