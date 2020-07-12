USE [GeneralDB]
GO

/****** Object:  StoredProcedure [dbo].[SaveStudent]    Script Date: 12/07/2020 6:45:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SaveStudent]
(
@ID INT,
@FirstName NVARCHAR(20),
@LastName NVARCHAR(20),
@DateBirth DATETIME=null,
@IsraeliID NUMERIC(9,0),
@CityID INT,
@ReturnCode NVARCHAR(20) OUTPUT
)
AS
BEGIN
	SET @ReturnCode = '200'
	IF(@ID <> 0)
	BEGIN
		IF EXISTS (SELECT 1 FROM Students WHERE IsraeliID = @IsraeliID AND ID <> @ID)
		BEGIN
			SET @ReturnCode = '301'
			RETURN
		END
	 

		UPDATE Students SET
		FirstName = @FirstName,
		LastName = @LastName,
		DateBirth = @DateBirth,
		IsraeliID = @IsraeliID,
		CityID = @CityID
		WHERE ID = @ID
			SELECT   [ID]
      ,[FirstName]
      ,[LastName]
      ,[DateBirth]
      ,[IsraeliID]
      ,s.[CityID]
	  ,c.[CityName]
  FROM [GeneralDB].[dbo].[Students] s inner join Cities c on s.CityID=c.CityID
  WHERE ID = @ID 
		SET @ReturnCode = '200'
	END
	ELSE
	BEGIN
		IF EXISTS (SELECT 1 FROM Students WHERE IsraeliID = @IsraeliID)
		BEGIN
			SET @ReturnCode = '301'
			RETURN
		END
		 

		INSERT INTO Students(FirstName,LastName,DateBirth,IsraeliID,CityID )
		VALUES (@FirstName,@LastName,@DateBirth,@IsraeliID,@CityID)
	  SELECT   [ID]
      ,[FirstName]
      ,[LastName]
      ,[DateBirth]
      ,[IsraeliID]
      ,s.[CityID]
	  ,c.[CityName]
  FROM [GeneralDB].[dbo].[Students] s inner join Cities c on s.CityID=c.CityID
  WHERE ID = (SELECT SCOPE_IDENTITY() )
		SET @ReturnCode = '200'
	END
END
GO


