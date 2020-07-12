USE [GeneralDB]
GO

/****** Object:  StoredProcedure [dbo].[GetCities]    Script Date: 12/07/2020 6:46:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCities]
	-- Add the parameters for the stored procedure here
		 @CityID INT=NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 
	SELECT  [CityID],
	  [CityName]
  FROM [GeneralDB].[dbo].[Cities] 
  WHERE CityID = @CityID OR @CityID IS NULL;
   

END
GO


