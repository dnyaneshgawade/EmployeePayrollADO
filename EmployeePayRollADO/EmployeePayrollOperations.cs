﻿using java.sql;
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
            try
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
                            Startdate = Convert.ToDateTime(dr["Startdate"]),
                            Salary = Convert.ToDouble(dr["Salary"]),
                        }
                        );
                }
                return EmpList;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        public void Display()
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
        public void AddEmployee()
        {
            try
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public int UpdateEmployee()
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE EmployeePayRoll SET Salary = @Salary WHERE Name=@Name", sqlConnection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Name", "Teressa");
                command.Parameters.AddWithValue("@Salary", "3000000");

                sqlConnection.Open();
                int i = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (i >= 1)
                {
                    Console.WriteLine("Data Updated sucessfully...");
                }
                else
                {
                    Console.WriteLine("Something went wrong... ");
                }
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int UpdateEmployeeUsingStoredProcedure()
        {
            try
            {
                SqlCommand command = new SqlCommand("spUpdateEmployeeDetails", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", "Teressa");
                command.Parameters.AddWithValue("@Salary", "3000000");

                sqlConnection.Open();
                int i = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (i >= 1)
                {
                    Console.WriteLine("Data Updated sucessfully...");
                }
                else
                {
                    Console.WriteLine("Something went wrong... ");
                }
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }





        public void DeleteEmployee()
        {
            try
            {
                SqlCommand command = new SqlCommand("spDeleteEmployeeDetails", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", 3);

                sqlConnection.Open();
                int i = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (i >= 1)
                {
                    Console.WriteLine("Data Deleted sucessfully...");
                }
                else
                {
                    Console.WriteLine("Something went wrong... ");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        
        public void EmpDetails()
        {

            while (choice != 10)
            {
                Console.WriteLine("\n Enter 1 for Display all records\n Enter 2 for Insert records\n Enter 3 for Update records\n Enter 4 for Update records from table\n Enter 5 for Update records using stored procedure\n Enter 10 for exit ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        GetAllEmployees();
                        if ((EmpList.Count) > 0)
                        {
                            Display();
                        }
                        else
                        {
                            Console.WriteLine("Table Has no records...please add records first");
                        }
                        break;
                    case 2:
                        AddEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        UpdateEmployeeUsingStoredProcedure();
                        break;
                    default:
                        Console.WriteLine("Enter wrong input");
                        break;
                }
            }
        }
    }
}
 