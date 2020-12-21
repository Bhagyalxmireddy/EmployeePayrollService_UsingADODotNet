using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Employee_PayRoll_Service
{
    public class EmployeePayRollOperations
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Payroll_Services;Integrated Security=True";
      
        public bool addEmployee(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployeeDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddMultipleElementToDB(List<EmployeeModel> Models)
        {
            foreach (EmployeeModel employee in Models)
            {
                Console.WriteLine("Employee being added:" + employee.Name);
                bool result = addEmployee(employee);
                Console.WriteLine("Employee Added:" + employee.Name);
                if (result == false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool AddEmployeesToDBWithThread(List<EmployeeModel> models)
        {
            bool result = false;
            models.ForEach(employee =>
            {
                Task thread = new Task(() =>
                {
                    result = addEmployee(employee);
                    Console.WriteLine("Employee added" + employee.Name);
                });
                thread.Start();
            });
            return result;

        }


        public List<EmployeeModel> listemployeeModel = new List<EmployeeModel>();
        public void AddEmployeePayroll(List<EmployeeModel> listemployeeModel)
        {
            listemployeeModel.ForEach(employeeData =>
            {
                Console.WriteLine("Employee begin: " + employeeData.Name);
                this.AddEmployee(employeeData);
                Console.WriteLine("employee Added : " + employeeData.Name);
            });
            Console.WriteLine(this.listemployeeModel.ToString());
        }

        public void AddEmployee(EmployeeModel employeeData)
        {
            listemployeeModel.Add(employeeData);
        }

        public void AddEmployeePayrollwithTheard(List<EmployeeModel> listemployeeModel)
        {
            listemployeeModel.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {

                    Console.WriteLine("Employee begin: " + employeeData.Name);
                    this.AddEmployee(employeeData);
                    Console.WriteLine("employee Added : " + employeeData.Name);
                });
                thread.Start();
            });
            Console.WriteLine(this.listemployeeModel.Count);
        }
        public bool UpdateMultipleEmployeeToDBWithThreading(List<EmployeeModel> models)
        {
            EmployeeRepo repo = new EmployeeRepo();
            bool result = false;
            models.ForEach(employee =>
            {
                Thread thread = new Thread(() =>
                {
                    result = repo.updateEmployee(employee);
                    Console.WriteLine("Employee added" + employee.Name);
                });
                thread.Start();
                thread.Join();
            });
            return result;
        }

    }
}
