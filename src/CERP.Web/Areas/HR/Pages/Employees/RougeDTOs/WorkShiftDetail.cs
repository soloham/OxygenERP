using CERP.App;
using CERP.HR.Workshifts;
using Newtonsoft.Json;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class WorkShiftDetail
    {
        public WorkShiftDetail(IList<WorkShiftRDto> workShifts)
        {
            this.workShifts = workShifts;
        }

        public IList<WorkShiftRDto> workShifts { get; set; }

        internal void Initialize(IRepository<WorkShift, int> workShiftsProxy)
        {
            workShifts.ForEach(x => x.WorkShiftsProxy = workShiftsProxy);
        }
    }

    public class WorkShiftRDto
    {
        [JsonIgnore]
        public IRepository<WorkShift, int> WorkShiftsProxy;

        public WorkShiftRDto()
        {

        }

        [JsonIgnore]
        private string workShiftName;
        public string GetWorkShiftName
        {
            get
            {
                try
                {
                    if (WorkShiftId >= 0)
                    {
                        workShiftName = WorkShiftsProxy.First(x => x.Id == WorkShiftId).Title;
                    }
                }
                catch { }

                return workShiftName;
            }
            set { workShiftName = value; }
        }
        public int WorkShiftId { get; set; }

        private string startHour;
        public string GetStartHour 
        { 
            get 
            {
                try
                {
                    startHour = WorkShiftsProxy.First(x => x.Id == WorkShiftId).StartHour.ToString();
                }
                catch {  }

                return startHour;
            }
            set { startHour = value; }
        }
        private string endHour;
        public string GetEndHour 
        {
            get 
            {
                try
                {
                    endHour = WorkShiftsProxy.First(x => x.Id == WorkShiftId).EndHour.ToString();
                }
                catch { }

                return endHour;
            } 
            set { endHour = value; }
        }

        public string FromDate { get; set; }
        public string FromHDate { get; set; }
        public string ToDate { get; set; }
        public string ToHDate { get; set; }
    }
}
