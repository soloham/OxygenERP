using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.DepartmentService;
using CERP.AppServices.HR.EmployeeService;
using CERP.CERP.HR.Documents;
using CERP.HR.Documents;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Grids;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Json;

namespace CERP.Web.Areas.HR.Pages.Documents
{
    public class ListModel : CERPPageModel
    {
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo;
        public IWebHostEnvironment webHostEnvironment { get; set; }

        public IGuidGenerator guidGenerator { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }

        public documentAppService documentAppService { get; set; }
        public EmployeeAppService employeeAppService { get; set; }


        public ListModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, documentAppService documentAppService, IGuidGenerator guidGenerator, EmployeeAppService employeeAppService, IJsonSerializer jsonSerializer)
        {
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.documentAppService = documentAppService;
            this.guidGenerator = guidGenerator;
            this.employeeAppService = employeeAppService;
            JsonSerializer = jsonSerializer;
        }

        public async Task OnDeleteDocument()
        {
            List<Document_Dto> documents = JsonSerializer.Deserialize<List<Document_Dto>>(Request.Form["documents"]);
            for (int i = 0; i < documents.Count; i++)
            {
                Document_Dto document = documents[i];

                await documentAppService.DeleteAsync(document.Id);

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                string filePath = Path.Combine(uploadsFolder, document.FileName);

                if (!string.IsNullOrEmpty(document.FileName) && System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }
        }

        public void OnGet()
        {
            List<Document_Dto> documents = documentAppService.GetAllDocuments();
            ViewData["Documents_DS"] = JsonSerializer.Serialize(documents);
        }
        public IActionResult OnGetOwners(string ownerType)
        {
            int docCount = documentAppService.Repository.Count();
            if (ownerType == "Employee")
            {
                var employees = employeeAppService.GetAllEmployees();
                List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
                for (int i = 0; i < employees.Count; i++)
                {
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(employees[i].Id, employees[i].Name));
                }

                return new JsonResult(new { owners = keyValuePairs, totalDocs = docCount });
            }
            return NoContent();
        }

        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "View", buttonOption = new { iconCss = "e-icons zmdi zmdi-search", cssClass = "e-flat" } });
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });
            commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat" } });
            commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "300", HeaderText = "Actions", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }
        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "referenceNo", HeaderText = "Ref #", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "name", HeaderText = "Name", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "nameLocalized", HeaderText = "Name in AR", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "description", HeaderText = "Description", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "ownerType.value", HeaderText = "Owner Type", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "documentType.value", HeaderText = "Doc Type", TextAlign=TextAlign.Center,  MinWidth="10"  },
                //new GridColumn { Field = "owner.name", HeaderText = "Owner Name", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "issuedFrom.value", Visible = false, HeaderText = "Issued From", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "issueDate", Visible = false, HeaderText = "Issue Date", Type="Date", Format="E, MMMM d, y", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "expiryDate", HeaderText = "Expiry Date", Type="Date", Format="E, MMMM d, y", TextAlign=TextAlign.Center,  MinWidth="10"  },
            };

            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var formData = Request.Form;

                    DocumentViewModel generalInfo = new DocumentViewModel();
                    generalInfo = JsonSerializer.Deserialize<DocumentViewModel>(formData["info"].ToString());

                    var files = formData.Files;
                    if (files.Count > 0)
                    {
                        IFormFile document = files[0];
                        generalInfo.File = document;
                    }

                    if (generalInfo.IsEditing)
                    {
                        Document documentToEdit = await documentAppService.Repository.GetAsync(generalInfo.Document.Id);
                        documentToEdit.ReferenceNo = generalInfo.Document.ReferenceNo;
                        documentToEdit.OwnerTypeId = generalInfo.Document.OwnerTypeId;
                        documentToEdit.DocumentTypeId = generalInfo.Document.DocumentTypeId;
                        documentToEdit.OwnerId = generalInfo.Document.OwnerId;
                        documentToEdit.Name = generalInfo.Document.Name;
                        documentToEdit.NameLocalized = generalInfo.Document.NameLocalized;
                        documentToEdit.Description = generalInfo.Document.Description;
                        documentToEdit.IssueDate = generalInfo.Document.IssueDate;
                        documentToEdit.ExpiryDate = generalInfo.Document.ExpiryDate;

                        if(generalInfo.File != null)
                        {
                            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                            string filePath = Path.Combine(uploadsFolder, documentToEdit.FileName);

                            if (!string.IsNullOrEmpty(documentToEdit.FileName) && System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);

                            string uploadedFileName = UploadedFile(generalInfo.File);
                            documentToEdit.FileName = uploadedFileName;
                        }

                        Document documentEdited = await documentAppService.Repository.UpdateAsync(documentToEdit);
                        Document_Dto documentEditedDto = ObjectMapper.Map<Document, Document_Dto>(documentAppService.Repository.WithDetails().First(x => x.Id == documentEdited.Id));
                        return new JsonResult(documentEditedDto);
                    }
                    else
                    {
                        Document_Dto documentDto = new Document_Dto(guidGenerator.Create());
                        documentDto.ReferenceNo = generalInfo.Document.ReferenceNo;
                        documentDto.OwnerTypeId = generalInfo.Document.OwnerTypeId;
                        documentDto.DocumentTypeId = generalInfo.Document.DocumentTypeId;
                        documentDto.OwnerId = generalInfo.Document.OwnerId;
                        documentDto.Name = generalInfo.Document.Name;
                        documentDto.NameLocalized = generalInfo.Document.NameLocalized;
                        documentDto.Description = generalInfo.Document.Description;
                        documentDto.IssuedFromId = generalInfo.Document.IssuedFromId;
                        documentDto.IssueDate = generalInfo.Document.IssueDate;
                        documentDto.ExpiryDate = generalInfo.Document.ExpiryDate;

                        string uploadedFileName = UploadedFile(generalInfo.File);
                        documentDto.FileName = uploadedFileName;

                        Document_Dto addedDoc = await documentAppService.CreateAsync(documentDto);
                        addedDoc = ObjectMapper.Map<Document, Document_Dto>(documentAppService.Repository.WithDetails().First(x => x.Id == addedDoc.Id));
                        return new JsonResult(addedDoc);
                    }
                }
                catch(Exception ex)
                {
                    return StatusCode(500);
                }
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
                uniqueFileName = ((new Random()).Next(1, 9) * 564654).ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public class DocumentViewModel
        {
            public DocumentViewModel()
            {
                IsEditing = false;
                Document = new Document_Dto();
                File = null;
            }

            public bool IsEditing { get; set; }
            public Document_Dto Document { get; set; }
            public IFormFile File { get; set; }
        }
    }
}
