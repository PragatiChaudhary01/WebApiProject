CREATE DATABASE STOREDB_DEV
CREATE TABLE Stores (
	Id int primary key IDENTITY,
	[Name] VARCHAR(100),
	City VARCHAR(100),
	[State] VARCHAR(100),
	Phone BIGINT
)
CREATE PROCEDURE usp_CreateStore
	@Name VARCHAR(100),
	@City VARCHAR(100),
	@State VARCHAR(100),
	@Phone BIGINT
	AS
	BEGIN 
		DECLARE @ID INT

		INSERT INTO Stores(Name,City,State,Phone)
		VALUES (@Name,@City,@State,@Phone)

		SELECT @ID = MAX(Id) FROM Stores

		SELECT Id, Name,City,State,Phone FROM Stores Where Id = @ID
	END
EXECUTE usp_CreateStore "Dmart", "HYD", "Telangana", "1234567890"
EXECUTE usp_CreateStore "Dmart2", "HYD", "Telangana", "1234567890"
EXECUTE usp_CreateStore "Dmart3", "HYD", "Telangana", "1234567890"
EXECUTE usp_CreateStore "Dmart4", "HYD", "Telangana", "1234567890"
