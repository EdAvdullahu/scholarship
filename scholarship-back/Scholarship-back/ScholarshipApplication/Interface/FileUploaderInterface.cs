using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface FileUploaderInterface
    {
        public DocumentList uploadApplicationFiles(List<FileUploadDto> files, int ScholarshipId, int DeadlienId, int StudentID);
    }
}
