using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee_PayRoll_Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        public List<EmployeeModel> AddingDataToList()
        {
            List<EmployeeModel> models = new List<EmployeeModel>();

            models.Add(new EmployeeModel() { Name = "Bhagya", Gender = 'F', PhoneNumber = "8965471023",Address = "Ngkl", StartDate= new DateTime(2017, 09, 14),Department = "Fianace", Basic_Pay = 20000,Deductions = 1234,IncomeTax = 632,TaxablePay = 500,NetPay = 120});
            models.Add(new EmployeeModel() { Name = "Sravani", Gender = 'F', PhoneNumber = "8965471102", Address = "Vijayawada", StartDate = new DateTime(2017, 08, 24), Department = "Fianace", Basic_Pay = 80000, Deductions = 1234, IncomeTax = 632, TaxablePay = 500, NetPay = 120 });
            models.Add(new EmployeeModel() { Name = "Akshay", Gender = 'M', PhoneNumber = "8965471021", Address = "hyd", StartDate = new DateTime(2018, 09, 11), Department = "Fianace", Basic_Pay = 20000, Deductions = 1234, IncomeTax = 632, TaxablePay = 500, NetPay = 120 });
            models.Add(new EmployeeModel() { Name = "Teju", Gender = 'F', PhoneNumber = "8965471022", Address = "Jcl", StartDate = new DateTime(2019, 05, 19), Department = "Fianace", Basic_Pay = 40000, Deductions = 1234, IncomeTax = 632, TaxablePay = 500, NetPay = 120 });
            models.Add(new EmployeeModel() { Name = "kiran", Gender = 'm', PhoneNumber = "8965471028", Address = "Jgl", StartDate = new DateTime(2015, 01, 17), Department = "Fianace", Basic_Pay = 30000, Deductions = 1234, IncomeTax = 632, TaxablePay = 500, NetPay = 120 });
            return models;
        }
        [TestMethod]
        public void AddingToDBWithout_Threading()
        {
            List<EmployeeModel> listModel = AddingDataToList();
            bool expected = true;
            EmployeePayRollOperations payRollOperations = new EmployeePayRollOperations();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual = payRollOperations.AddMultipleElementToDB(listModel);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add to db without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddingToDBWith_Threading()
        {
            List<EmployeeModel> Models = AddingDataToList();
            bool expected = true;
            EmployeePayRollOperations payRollOperations = new EmployeePayRollOperations();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual = payRollOperations.AddEmployeesToDBWithThread(Models);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add to db without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddingToList_WithOutThearding()
        {
            List<EmployeeModel> Models = AddingDataToList();
            EmployeePayRollOperations payRollOperations = new EmployeePayRollOperations();
            DateTime startTime = DateTime.Now;
            payRollOperations.AddEmployeePayroll(Models);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration without thread ;" + (stopTime - startTime));
        }
        [TestMethod]
        public void AddingToList_WithThearding()
        {
            List<EmployeeModel> Models = AddingDataToList();
            EmployeePayRollOperations payRollOperations = new EmployeePayRollOperations();
            DateTime startTimeThread = DateTime.Now;
            payRollOperations.AddEmployeePayrollwithTheard(Models);
            DateTime stopTimethread = DateTime.Now;
            Console.WriteLine("Duration without thread ;" + (stopTimethread - startTimeThread));
        }
        public List<EmployeeModel> updateList()
        {
            List<EmployeeModel> upadateList = new List<EmployeeModel>();
            upadateList.Add(new EmployeeModel { Employee_id = 1, Address = "HYD" });
            upadateList.Add(new EmployeeModel { Employee_id = 2, Address = "MBNR" });
            upadateList.Add(new EmployeeModel { Employee_id = 3, Address = "JCL" });
            return upadateList;

        }
        [TestMethod]
        public void updateToDB_WithThreading()
        {
            List<EmployeeModel> models = updateList();
            bool expected = true;
            EmployeePayRollOperations payRollOperations = new EmployeePayRollOperations();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual = payRollOperations.UpdateMultipleEmployeeToDBWithThreading(models);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add to db without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(expected, actual);

        }
    }
}
