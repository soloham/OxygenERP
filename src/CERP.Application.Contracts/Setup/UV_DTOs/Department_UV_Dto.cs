using CERP.FM.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.Setup.DTOs
{
    public class Department_UV_Dto : AuditedEntityDto<Guid>
    {
        public Department_UV_Dto()
        {

        }
        public Department_UV_Dto(Guid id)
        {
            Id = id;
        }

        public Company_Dto Company { get; set; }
        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Position_Dto> Positions { get; set; }
    }
}
