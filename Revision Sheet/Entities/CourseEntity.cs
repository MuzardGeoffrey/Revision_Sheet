using System;
using System.Collections.Generic;

namespace RevisionSheet.DataAccess.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public CourseEntity()
        {
        }

        public CourseEntity(string name, int userId)
        {
            this.Name = name;
            this.UserId = userId;
        }

        public CourseEntity(int id, string name, int userId)
        {
            this.Id = id;
            this.Name = name;
            this.UserId = userId;
        }
    }
}