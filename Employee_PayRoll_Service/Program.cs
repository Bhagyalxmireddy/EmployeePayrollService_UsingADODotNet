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

            bool i = true;
            while (i)
            {
                Console.WriteLine("1.SumOfBasicSalaryByGender");
                Console.WriteLine("2.AvgOfBasicSalaryByGender");
                Console.WriteLine("3.MinOfBasicSalaryByGender");
                Console.WriteLine("4.MaxOfBasicSalaryByGender");
                Console.WriteLine("5.CountOfBasicSalaryByGender");
                Console.WriteLine("6.Exit");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            repo.sumOfsalaryByGender();
                            break;
                        case 2:
                            repo.avgOfsalaryByGender();
                            break;
                        case 3:
                            repo.MinOfsalaryByGender();
                            break;
                        case 4:
                            repo.MaxOfsalaryByGender();
                            break;
                        case 5:
                            repo.countOfsalaryByGender();
                            break;
                        case 6:
                            i = false;
                            break;
                        default:
                            Console.WriteLine("Choose proper option");
                            break;
                    }
                }
                catch(System.FormatException formatException)
                {
                    Console.WriteLine(formatException);
                }
            }
           
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            // repo.getAllEmployees();

            /* model.Name = "Akshay";
             model.Gender = "M";
             model.PhoneNumber = "7896301245";
             model.Address = "BalNagar";
             model.StartDate = new DateTime(2014,05,13);
             model.Department = "Markating";
             model.Basic_Pay = 100000;
             model.Deductions = 10000;
             model.IncomeTax = 5000;
             model.TaxablePay = 6000;
             model.NetPay = 80000;*/
            // repo.addEmployee(model);

            /* model.Name = "Akshay";
             model.Address = "Jadcharla";
             repo.updateEmployee(model);*/
            // repo.getEmployeesInRangeByDate();
            //repo.sumOfsalaryByGender();
            // repo.avgOfsalaryByGender();
            //repo.MaxOfsalaryByGender();
            //repo.MinOfsalaryByGender();
            //repo.countOfsalaryByGender();
            //repo.retreveThe_EmployeeDetails();
        }
    }
}
