using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRollADO
{
    public class EmployeePayrollOperations
    {
        public static int choice;
        public static List<Employee> EmpList = new List<Employee>();
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayRollADO";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        

        public List<Employee> GetAllEmployees()
        {
            SqlCommand com = new SqlCommand("spGetAllEmployeeDetails", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            da.Fill(dt);
            sqlConnection.Close();    
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new Employee
                    {

                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        PhoneNumber = Convert.ToDouble(dr["PhoneNumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Department = Convert.ToString(dr["Department"]),
                        Startdate= Convert.ToDateTime(dr["Startdate"]),
                        Salary = Convert.ToDouble(dr["Salary"]),
                    }
                    );
            }

            return EmpList;
        }


        public void AddEmployee()
        {
            SqlCommand command = new SqlCommand("spInsertEmployeeDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", "Teressa");
            command.Parameters.AddWithValue("@Gender", "F");
            command.Parameters.AddWithValue("@PhoneNumber", "8989787878");
            command.Parameters.AddWithValue("@Address", "Mumbai");
            command.Parameters.AddWithValue("@Department", "Salse");
            command.Parameters.AddWithValue("@Salary", 300000);
            command.Parameters.AddWithValue("@StartDate", "2017-01-01");

            sqlConnection.Open();
            int i = command.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
            {

                Console.WriteLine("Data inserted sucessfully...");

            }
            else
            {

                Console.WriteLine("Something went wrong... ");
            }


        }
        public void EmpDetails()
        {

            while (choice != 10)
            {
                Console.WriteLine("\n Enter 1 for Display all records\n Enter 2 for Insert records\n Enter 10 for exit ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        GetAllEmployees();
                        if ((EmpList.Count) > 0)
                        {
                            foreach (Employee emp in EmpList)
                            {
                                Console.WriteLine("First name :" + emp.Id);
                                Console.WriteLine("Last name :" + emp.Name);
                                Console.WriteLine("Address :" + emp.Address);
                                Console.WriteLine("PhoneNumber :" + emp.PhoneNumber);
                                Console.WriteLine("Gender :" + emp.Gender);
                                Console.WriteLine("Department :" + emp.Department);
                                Console.WriteLine("Salary :" + emp.Salary);
                                Console.WriteLine("Startdate :" + emp.Startdate);
                                Console.WriteLine("_________________________________\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Table Has no records...please add records first");
                        }
                        break;
                    case 2:
                        AddEmployee();
                        break;

                    default:
                        Console.WriteLine("Enter wrong input");
                        break;
                }
            }
        }
    }
}
