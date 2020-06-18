using RevisionSheet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevisionSheet.DataAccess.IDataAccess
{
    interface ICourseDataAccess : IBaseDataAccess<CourseEntity>
    {
        public List<CourseEntity> FindAllCourseByUser(int courseId); 
    }
}
