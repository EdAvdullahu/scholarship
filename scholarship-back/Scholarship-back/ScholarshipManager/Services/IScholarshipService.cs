using Scholarship_back.Data;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class IScholarshipService: IScholarship
    {
        private readonly DataContext _context;
        public IScholarshipService(DataContext context)
        {
            _context = context;
        }

        public List<Criterion> getCriteriaById(int id)
        {
            List<CriterionScholarship> tempCS = _context.ScholarshipCriterias.Where(c => c.ScholarshipId == id).ToList();
            List<Criterion> tempC = _context.Criterion.ToList();
            return tempC.IntersectBy(tempCS.Select(x => x.CriterionId), x => x.Id).ToList();
        }   

        public Scholarship getScholarshipById(int id)
        {
            return _context.Scholarships.Find(id);
        }
    }
}
