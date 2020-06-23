using CERP.App.Helpers;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.OrganizationalManagement.PayrollStruture
{
    public class FileColumns
    {
        string[] v;
        public FileColumns()
        {
            v = EnumExtensions.GetDescriptions(typeof(PS_PaymentFileEmployeeColumn));
            for (int i = 0; i < v.Length; i++)
            {
                PaymentFileEmployeeColumns.Add(new FileColumn<PS_PaymentFileEmployeeColumn>(i, v[i]));
            }
            v = EnumExtensions.GetDescriptions(typeof(PS_PaymentFilePayrollColumn));
            for (int i = 0; i < v.Length; i++)
            {
                PaymentFilePayrollColumns.Add(new FileColumn<PS_PaymentFilePayrollColumn>(i, v[i]));
            }
            v = EnumExtensions.GetDescriptions(typeof(PS_PaymentFileBankColumn));
            for (int i = 0; i < v.Length; i++)
            {
                PaymentFileBankColumns.Add(new FileColumn<PS_PaymentFileBankColumn>(i, v[i]));
            }
        }

        public List<FileColumn<PS_PaymentFileEmployeeColumn>> PaymentFileEmployeeColumns { get; set; } = new List<FileColumn<PS_PaymentFileEmployeeColumn>>();
        public List<FileColumn<PS_PaymentFilePayrollColumn>> PaymentFilePayrollColumns { get; set; } = new List<FileColumn<PS_PaymentFilePayrollColumn>>();
        public List<FileColumn<PS_PaymentFileBankColumn>> PaymentFileBankColumns { get; set; } = new List<FileColumn<PS_PaymentFileBankColumn>>();

        public class FileColumn<T>
        {
            public FileColumn(int id)
            {
                Id = id;
                Description = EnumExtensions.GetDescriptions(typeof(T))[id];
                Type = EnumExtensions.GetValueFromDescription<T>(Description);
            }
            public FileColumn(int id, string description = "")
            {
                Id = id;
                Description = description;
                Type = EnumExtensions.GetValueFromDescription<T>(description);
            }

            public int Id { get; set; }
            public string Description { get; set; }
            public T Type { get; set; }
        }
    }
}
