using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CERP.App.CustomEntityHistorySystem;
using CERP.HR.EmployeeCentral.DTOs.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;

namespace CERP.Web.Areas.HR.Pages.EmployeeCentral
{
    [Authorize]
    public class EmployeeModel : AbpPageModel
    {
        public EmployeeModel(IWebHostEnvironment webHostEnvironment, IAuditingManager auditingManager, IRepository<CustomEntityChange> customEntityChangesRepo, IJsonSerializer jsonSerializer)
        {
            this.webHostEnvironment = webHostEnvironment;
            AuditingManager = auditingManager;
            CustomEntityChangesRepo = customEntityChangesRepo;
            JsonSerializer = jsonSerializer;
        }

        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IAuditingManager AuditingManager { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var FormData = Request.Form;

            var changes = await CustomEntityChangesRepo.GetListAsync();
            try 
            {
                //dynamic employeeData = JsonSerializer.Deserialize<dynamic>(FormData["employeeData"].ToString());

                Employee_Dto employee = JsonSerializer.Deserialize<Employee_Dto>(FormData["general"].ToString());

                if (FormData.Files.Count > 0 && FormData.Files.Any(x => x.Name == "ProfilePicture"))
                {
                    IFormFile formFile = FormData.Files.First(x => x.Name == "ProfilePicture");

                    string uploadedFileName = UploadedFile(formFile);
                    //employee.ProfilePic = uploadedFileName;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = ((new Random()).Next(1, 9) * (new Random()).Next(10000, 900000)).ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
