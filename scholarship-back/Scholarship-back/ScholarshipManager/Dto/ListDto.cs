namespace Scholarship_back.ScholarshipManager.Dto
{
    public class ListDto
    {
        public List<int> list { get; set; }
        public int getLength()
        {
            return list.Count;
        }
        public int getByIndex(int index)
        {
            return list[index];
        }
    }
}
