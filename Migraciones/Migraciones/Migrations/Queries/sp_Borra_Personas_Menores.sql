CREATE PROCEDURE sp_Borra_Personas_Menores
AS
BEGIN
	SET NOCOUNT ON;
	DELETE	Personas
	where Edad<18
END