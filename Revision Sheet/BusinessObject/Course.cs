﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revision_Sheet.BusinessObject
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Chapter> ChapterList { get; set; }
    }
}
