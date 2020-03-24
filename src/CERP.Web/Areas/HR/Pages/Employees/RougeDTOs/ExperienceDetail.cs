using CERP.App;
using Newtonsoft.Json;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class ExperienceDetail
    {
        public ExperienceDetail() { }

        public ExperienceDetail(IList<Experience> experiences)
        {
            Experiences = experiences;
        }

        public IList<Experience> Experiences { get; set; }
    }

    public class Experience
    {
        public Experience()
        {

        }

        public int Id { get; set; }
        public string GetExpPlace
        {
            get; set;
        }
        public string GetExpDescription
        {
            get; set;
        }

        public string FromDate { get; set; }
        public string FromHDate { get; set; }
        public string ToDate { get; set; }
        public string ToHDate { get; set; }
    }
}