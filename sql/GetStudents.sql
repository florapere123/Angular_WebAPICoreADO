USE [GeneralDB]
GO

/****** Object:  StoredProcedure [dbo].[GetStudents]    Script Date: 12/07/2020 6:46:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStudents]
	-- Add the parameters for the stored procedure here
	 @ID INT=NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 
	SELECT   [ID]
      ,[FirstName]
      ,[LastName]
      ,[DateBirth]
      ,[IsraeliID]
      ,s.[CityID]
	  ,c.[CityName]
  FROM [GeneralDB].[dbo].[Students] s inner join Cities c on s.CityID=c.CityID
  WHERE ID = @ID OR @ID IS NULL;
   

END
GO


