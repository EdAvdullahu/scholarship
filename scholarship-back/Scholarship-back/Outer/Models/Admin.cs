namespace Scholarship_back.Outer.Models
{
    public class Admin: User
    {
        public University? University { get; set; }
        public int UniversityId { get; set; }
    }
}
