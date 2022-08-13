using FinalProject.Models;

namespace FinalProject.Repository
{
    public interface IStudentRepository
    {
        Task<UploadModel> Upload(UploadModel uploadModel);
        Task<ProjectModel> Project(ProjectModel projectModel);
    }
}
