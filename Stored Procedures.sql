
Create or Alter procedure spGetAllEmployeeDetails
as 
begin try
select * from EmployeePayRoll
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH      


Create or Alter procedure spInsertEmployeeDetails
(
	@Name varchar(150),
	@Gender varchar(1),
	@PhoneNumber float,
	@Address varchar(100),
	@Department varchar(100),
	@Salary float,
	@StartDate date
)
as 
begin try
insert into EmployeePayRoll (Name,Gender,PhoneNumber,Address,Department,Salary,StartDate)
values
(@Name,@Gender,@PhoneNumber,@Address,@Department,@Salary,@StartDate)
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH      




Create or Alter procedure spDeleteEmployeeDetails
(
	@Id int
)
as 
begin try
DELETE FROM EmployeePayRoll WHERE  Id = @Id
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

Create or Alter procedure spUpdateEmployeeDetails
(
	@Name varchar(150),
	@Salary float
)
as 
begin try
UPDATE EmployeePayRoll SET Salary = @Salary WHERE Name=@Name
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  


Create or Alter procedure spSumOfSalary
(
	@Gender varchar(1)
)
As 
Begin try
Select SUM(Salary) From EmployeePayRoll 
Where Gender=@Gender Group by Gender
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH


Create or Alter procedure spMaximumSalary
(
	@Gender varchar(1)
)
As 
Begin try
Select Max(Salary) From EmployeePayRoll 
Where Gender=@Gender Group by Gender
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH


Create or Alter procedure spMinimumSalary
(
	@Gender varchar(1)
)
As 
Begin try
Select Min(Salary) From EmployeePayRoll 
Where Gender=@Gender Group by Gender
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH



Create or Alter procedure spAverageSalary
(
	@Gender varchar(1)
)
As 
Begin try
Select Avg(Salary) From EmployeePayRoll 
Where Gender=@Gender Group by Gender
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH



Create or Alter procedure spCountOfEmployee
(
	@Gender varchar(1)
)
As 
Begin try
Select Count(Salary) From EmployeePayRoll 
Where Gender=@Gender Group by Gender
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH