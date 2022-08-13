using FinalProject.DataFolder;
using FinalProject.Models;
using FinalProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Data _dataFolder;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(IStudentRepository studentRepository,
            IWebHostEnvironment webHostEnvironment,  Data dataFolder, UserManager<ApplicationUser> userManager) 
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
            _dataFolder = dataFolder;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Upload(UploadModel uploadModel)
        {

            if (uploadModel.fileUpload != null)
            {
                TempData["AlertMessage"] = " Document Upload Successfully";
                var folder = "UploadedDocument/";
                folder = folder+uploadModel.fileUpload.FileName;
                folder = String.Concat(folder.Where(c => !Char.IsWhiteSpace(c)));
                uploadModel.uploadUrl = "/"+ folder;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await uploadModel.fileUpload.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            var result = await _studentRepository.Upload(uploadModel);
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Fetch all files in the Folder (Directory).
        /// Copy File names to Model collection.
        /// </summary>
        /// <returns></returns>

        public IActionResult UpoladFile()
        {
           
            string[] filePaths = Directory.GetFiles(Path.Combine(_webHostEnvironment.WebRootPath, "UploadedDocument/"));

            
            List<UploadModel> files = new List<UploadModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new UploadModel { uploadUrl = Path.GetFileName(filePath) });
            }
            return View(files);
        }
        /// <summary>
        /// Build the File Path.
        /// Read the File data into Byte Array.
        /// Send the File to Download.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileResult DownloadFile(string fileName)
        {
            
            
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "UploadedDocument/") + fileName;

            
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            
            return File(bytes, "application/octet-stream", fileName);
        }

        //This Method Is the Upload the Project File
        public ActionResult UploadProject()
        {
            return View();
        }
        [Authorize(Roles = "Student Faculty")]
        /// <summary>
        /// Upload the file in any formate
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult UploadProject(ProjectModel projectModel)
        {
            if (projectModel.projectfile != null)
            {
                TempData["AlertMessage"] = "Project Upload Successfully";
                var folder = "Project/";
                
                folder= folder+projectModel.projectfile.FileName;
                folder = String.Concat(folder.Where(c => !Char.IsWhiteSpace(c)));
                projectModel.projectUrl="/"+folder;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                projectModel.projectfile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            var result = _studentRepository.Project(projectModel);
            return RedirectToAction("Index", "Home");

        }


        public IActionResult ProjectFile()
        {
            
            string[] filePaths = Directory.GetFiles(Path.Combine(_webHostEnvironment.WebRootPath, "Project/"));

            
            List<ProjectModel>files = new List<ProjectModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ProjectModel { projectUrl = Path.GetFileName(filePath) });
            }
            
            return View(files);
        }
        
        public FileResult ProjectDownloadFile(string fileName)
        {
           
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Project/") + fileName;

            
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            
            return File(bytes, "application/octet-stream", fileName);
        }

        
        
                        
    }
}
