CREATE PROCEDURE [dbo].[InstitucionObtener]
@Id_Institucion INT = NULL

AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	       Id_Institucion
		 , Codigo
		 , Nombre
		 , Telefono
		 , Estado
		 
	FROM
	    dbo.Institucion
	WHERE
	    (@Id_Institucion IS NULL OR Id_Institucion=@Id_Institucion)
	      

END

