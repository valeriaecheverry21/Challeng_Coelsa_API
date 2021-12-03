USE master
GO
IF EXISTS(select * from sys.databases where name='CoelsaDB')
DROP DATABASE CoelsaDB
GO

CREATE DATABASE CoelsaDB;
GO
USE CoelsaDB;
GO

CREATE TABLE dbo.Contacts(
		[Id]			int identity(1,1) not null Primary Key,
		[FirstName]		nvarchar(50) not null,
		[LastName]		nvarchar(50) not null,
		[Company]		nvarchar(50) not null,
		[Email]			nvarchar(50) not null,
		[PhoneNumber]	nvarchar(50) not null
);
GO



CREATE PROCEDURE dbo.InsertContactSP
	@FirstName		nvarchar(50),
	@LastName		nvarchar(50),
	@Company		nvarchar(50),
	@Email			nvarchar(50),
	@PhoneNumber	nvarchar(50)
AS BEGIN 
	INSERT INTO Contacts
		(FirstName, LastName, Company, Email, PhoneNumber)
	VALUES
		(@FirstName, @LastName, @Company, @Email, @PhoneNumber)
END
GO



CREATE PROCEDURE dbo.UpdateContactSP
	@Id				int,
	@FirstName		nvarchar(50),
	@LastName		nvarchar(50),
	@Company		nvarchar(50),
	@Email			nvarchar(50),
	@PhoneNumber	nvarchar(50)
AS BEGIN 
	UPDATE dbo.Contacts 
	SET
		FirstName = @FirstName,
		LastName = @LastName,
		Company = @Company,
		Email = @Email,
		PhoneNumber = @PhoneNumber
	WHERE Id = @Id
END
GO



Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;
Insert into Contacts Select 'Jane', 'Doe', 'CerceCircle', 'JaneDoe@email.com', 123456789;

GO

Select * from Contacts;

