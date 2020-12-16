using System;

namespace Employee_PayRoll_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WelCome to EmployeePayroll");
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel();

            repo.getAllEmployees();

            model.Name = "Akshay";
            model.Gender = "M";
            model.PhoneNumber = "7896301245";
            model.Address = "BalNagar";
            model.StartDate = new DateTime(2014,05,13);
            model.Department = "Markating";
            model.Basic_Pay = 100000;
            model.Deductions = 10000;
            model.IncomeTax = 5000;
            model.TaxablePay = 6000;
            model.NetPay = 80000;
          // repo.addEmployee(model);

        }
    }
}
