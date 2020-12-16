using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee_PayRoll_Service;
using System;

namespace Employee_Payroll_Test
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepo employeeRepo = new EmployeeRepo();
        EmployeeModel Model = new EmployeeModel();
        [TestMethod]
        public void AddingEmployeeDetails_ShouldReturnTrue()
        {
            Model.Name = "Pravalika";
            Model.Gender = "F";
            Model.PhoneNumber = "8741023659";
            Model.Address = "Ngkl";
            Model.StartDate = new DateTime(2019, 02, 09);
            Model.Department = "CustomerService";
            Model.Basic_Pay = 60000;
            Model.Deductions = 2000;
            Model.IncomeTax = 7000;
            Model.TaxablePay = 1243;
            Model.NetPay = 50000;
            bool result = employeeRepo.addEmployee(Model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateEmployeDetails_ShouldReturnTrue()
        {
            Model.Name = "Pravalika";
            Model.Address = "Dsnr";
            bool result = employeeRepo.updateEmployee(Model);
            Assert.IsTrue(result);
        }
    }
}
