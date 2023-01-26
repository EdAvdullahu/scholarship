namespace Scholarship_back.Outer.Models
{
    public class Faculty
    {

        public int Id { get; set; }
        public string FacultyName { get; set; } = string.Empty;
        public string FacultyDescription { get; set; } = string.Empty; 
        public University? University { get; set; }
        public int UniversityId { get; set; }
        public FacultyType? FacultyType { get; set; }    
        public int FacultyTypeId { get; set; }
    }
}
