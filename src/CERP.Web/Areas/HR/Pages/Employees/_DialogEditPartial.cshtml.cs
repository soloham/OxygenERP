using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CERP.Web.Areas.HR.Pages.Employees
{
    public class _DialogEditPartialModel
    {
        [Required]
        public int? OrderID { get; set; }
        [Required, MinLength(3)]
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime? OrderDate { get; set; }

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }

        public DateTime? ShippedDate { get; set; }
        public string ShipAddress { get; set; }

        public void OnGet()
        {
        }
    }
}
