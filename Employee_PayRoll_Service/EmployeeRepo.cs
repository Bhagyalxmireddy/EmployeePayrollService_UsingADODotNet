using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Employee_PayRoll_Service
{
    public class EmployeeRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Payroll_Services;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void getAllEmployees()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT Employee_ID,Name,Gender,PhoneNumber,Address,StartDate,Department,
                                    Basic_Pay,Deductions,TaxablePay,IncomeTax,NetPay
                                    FROM Employee_payroll";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.Employee_ID = dataReader.GetInt32(0);
                            model.Name = dataReader.GetString(1);
                            model.Gender = dataReader.GetString(2);
                            model.PhoneNumber = dataReader.GetString(3);
                            model.Address = dataReader.GetString(4);
                            model.StartDate = dataReader.GetDateTime(5);
                            model.Department = dataReader.GetString(6);                          
                            model.Basic_Pay = dataReader.GetDouble(7);
                            model.Deductions = dataReader.GetDouble(8);
                            model.TaxablePay = dataReader.GetDouble(9);
                            model.IncomeTax = dataReader.GetDouble(10);
                            model.NetPay = dataReader.GetDouble(11);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                                model.Employee_ID, model.Name, model.Gender,
                                model.PhoneNumber, model.Address,model.StartDate, model.Department,model.Basic_Pay,
                                model.Deductions,model.TaxablePay,model.IncomeTax,model.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    dataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool addEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployeeDetails", this.connection);
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
          
                    this.connection.Open();
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
                this.connection.Close();
            }
        }
    }
}
