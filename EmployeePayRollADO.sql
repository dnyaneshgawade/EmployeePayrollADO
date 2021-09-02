create Database EmployeePayRollADO

use EmployeePayRollADO

CREATE TABLE EmployeePayRoll (
  Id int  NOT NULL identity(1,1) primary key,
  PhoneNumber float not null,
  Address varchar(100) not null,
  Department varchar(100) not null,
  Gender varchar(10) not null, 
  Name varchar(150) NOT NULL,
  Salary varchar(20) NOT NULL,
  StartDate date NOT NULL,
  )


Insert into EmployeePayRoll (Name,PhoneNumber,Address,Gender,Department,Salary,StartDate)
values 
('Dnyanesh',8989898989,'Pune','M','Developer',30000,'2019-01-01')



select * from EmployeePayRoll

ALTER TABLE EmployeePayRoll
ALTER COLUMN Salary float;

ALTER TABLE EmployeePayRoll
ALTER COLUMN Gender varchar(1);
