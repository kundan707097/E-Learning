using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DataFolder
{
    public class Data: IdentityDbContext<ApplicationUser>
    {
        public Data(DbContextOptions<Data> options) : base(options)
        {

        }
        
        public DbSet<FinalProject.Models.Knowledges> Knowledges { get; set; }
        public DbSet<FinalProject.Models.UploadModel> UploadModels { get; set; }
        public DbSet<FinalProject.Models.ChatModel> ChatModels { get; set; }
        public DbSet<FinalProject.Models.ProjectModel> ProjectModels { get; set; }
    }
}
