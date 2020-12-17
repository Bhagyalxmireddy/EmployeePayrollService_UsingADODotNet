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
            Model.Gender = 'F';
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
        [TestMethod]
        public void addEmployeeDetails_ReturnTrue()
        {
            Model.Name = "Priyanka";
            Model.Gender = 'F';
            Model.PhoneNumber = "9874103256";
            Model.Address = "DSNR";
            bool result = employeeRepo.AddingEmployeeDetails(Model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void addPayrollDetails_ReturnTrue()
        {
            Model.Employee_id = 4;
            Model.StartDate = new DateTime(2018, 08, 19);
            Model.Basic_Pay = 60000.00;
            Model.Deduction = 2000.00;
            Model.TaxablePay = 1243.00;
            Model.IncomeTax = 7000.00;
            Model.NetPay = 50000.00;
            bool result = employeeRepo.AddingPayRollDetails(Model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void addDepartmentDetails_ReturnTrue()
        {
            Model.Department = "HR";
            bool result = employeeRepo.AddingDepartment(Model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void addEmployeeDepartment_shouldReturnTrue()
        {
            Model.Employee_id = 5;
            Model.Department_id = 1;
            bool result = employeeRepo.AddingToEmployeeDepartment(Model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void addingDetailsToMultipleTables_WithSingleTransaction_ShouldRetrunTure()
        {
            Model.Name = "Sri Vani";
            Model.Gender = 'F';
            Model.PhoneNumber = "9630124857";
            Model.Address = "kukatpally";
            Model.Basic_Pay = 50000.00;
            Model.StartDate = new DateTime(2016, 11, 12);
            Model.Department_id = 3;
            bool result = employeeRepo.AddEmployeeDetailsToMultipleTables(Model);
            Assert.IsTrue(result);
        }
    }
}
