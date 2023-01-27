using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class FacultyScholarshipBuilder
    {
        private Scholarship _scholarship;
        public void buildCategory()
        {
            /*
             to implement in the future
             */
        }

        public void buildCriterion(ListDto list)
        {
            for (int i = 0; i < list.getLength(); i++)
            {
                _scholarship.setCriteria(list.getByIndex(i));
            }
        }

        public void buildFaculty(FacultyInfo faculty)
        {
            _scholarship.setFaculty(faculty);
        }

        public void buildType()
        {
            /**
             * Scholarship.setType();
             * TO DO change logic
             */
            _scholarship.setType(0);
        }
        public void buildDescription(string description)
        {
            _scholarship.setDescription(description);
        }
        public void buildValue(double value)
        {
            _scholarship.setValue(value);
        }
        public Scholarship getScholarship()
        {
            return _scholarship;
        }
    }
}
