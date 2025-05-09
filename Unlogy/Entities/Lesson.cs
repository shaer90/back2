﻿namespace Unlogy.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string VideoUrl { get; set; }
        public int Order { get; set; }        
        public TimeSpan Duration { get; set; }
        public bool IsDeleted { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
