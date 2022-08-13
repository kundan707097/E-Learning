using FinalProject.DataFolder;
using FinalProject.Models;

namespace FinalProject.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly Data _dataFolder;

        public StudentRepository(Data dataFolder)
        {
            _dataFolder = dataFolder;
        }
        public async Task<UploadModel> Upload(UploadModel uploadModel)
        {

            await _dataFolder.UploadModels.AddAsync(uploadModel);
            await _dataFolder.SaveChangesAsync();
            return null;
        }
        public async Task<ProjectModel> Project(ProjectModel projectModel)
        {
            await _dataFolder.ProjectModels.AddAsync(projectModel);
            await _dataFolder.SaveChangesAsync();
            return null;
        }
    }
}
