CREATE PROCEDURE [dbo].[InstitucionInsertar]
	
	@Id_Institucion INT,
	@Codigo VARCHAR(250),
	@Nombre VARCHAR(250),
	@Telefono VARCHAR(250),
	@Estado BIT

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY

  INSERT INTO dbo.Institucion
  (
	Codigo	  
	, Nombre
	, Telefono
	, Estado  
  )
  VALUES
  (
     @Codigo	  
	, @Nombre
	, @Telefono
	, @Estado  
  )

  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError

  END TRY

	  BEGIN CATCH
		SELECT 
			   ERROR_NUMBER() AS CodError,
			   ERROR_MESSAGE() AS MsgError

	  ROLLBACK TRANSACTION TRASA
  
  END CATCH

  END 


