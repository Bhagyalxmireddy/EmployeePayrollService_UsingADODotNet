using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_PayRoll_Service
{
    public class EmployeeModel
    {
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Gender { get; set; }
        public string Basic_Pay { get; set; }
        public string Deductions { get; set; }
        public string Taxable_Pay { get; set; }
        public string Tax { get; set; }
        public int NetPay { get; set; }
        public string StartDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
