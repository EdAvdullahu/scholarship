﻿namespace Scholarship_back.Outer.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public Subject? Subject { get; set; }    
        public int SubjectId { get; set; }
        public int Value { get; set; }
    }
}
