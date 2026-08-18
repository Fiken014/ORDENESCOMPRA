USE ORDENESCOMPRA_DESAPPULTGEN
GO

DECLARE @SU_CORREO VARCHAR(100) = 'kendallabm0013@gmail.com'
DECLARE @SU_NOMBRE VARCHAR(100) = 'Kendall'
DECLARE @SU_APELLIDO1 VARCHAR(100) = 'Bonilla'
DECLARE @SU_APELLIDO2 VARCHAR(100) = 'Miranda'



IF (
	@SU_CORREO='' OR @SU_NOMBRE='' OR @SU_APELLIDO1='' OR @SU_APELLIDO2=''
   )
BEGIN 
	SELECT 'ERROR!!!! DEFINA SUS DATOS PERSONALES' AS ERROR_DATOS_NO_VALIDOS
END
ELSE
BEGIN
	-----------------------INSERTA REGISTROS BASICOS
	INSERT INTO Usuarios
	(
	Correo, Nombre, Prim_Apellido, Seg_Apellido, Estado, Password
	)
	SELECT 
	@SU_CORREO,@SU_NOMBRE,@SU_APELLIDO1,@SU_APELLIDO2,'A','123'

	INSERT INTO Usuarios
	(
	Correo, Nombre, Prim_Apellido, Seg_Apellido, Estado, Password
	)
	SELECT 
	'kevin.montes@uamcr.net','Kevin','Montes','Varela','A','123'

	INSERT INTO Modulos
	(
	Modulo, ClaseCSS, Enlace
	)
	SELECT 
	'Proveedores','fa fa-users','frmConsultaProveedores.aspx'

	INSERT INTO Modulos
	(
	Modulo, ClaseCSS, Enlace
	)
	SELECT 
	'Órdenes de Compra','fa fa-book','frmConsultaOrdenes.aspx'

	INSERT INTO Modulos
	(
	Modulo, ClaseCSS, Enlace
	)
	SELECT 
	'Auditoria','fa fa-folder-open','frmConsultaAuditoria.aspx'

	INSERT INTO Modulos_X_Usuario 
	(
	Id_Usuario, Id_Modulo
	)
	SELECT 
	1, Id_Modulo
	FROM Modulos

	INSERT INTO Modulos_X_Usuario 
	(
	Id_Usuario, Id_Modulo
	)
	SELECT 
	2, Id_Modulo
	FROM Modulos

	INSERT INTO Productos
	(
	Descripcion, Estado
	)
	SELECT 
	'Computadora DELL Latitude', 'A'

	INSERT INTO Productos
	(
	Descripcion, Estado
	)
	SELECT 
	'Computadora DELL Vostro', 'A'

	INSERT INTO Productos
	(
	Descripcion, Estado
	)
	SELECT 
	'Monitor Samsung 32', 'A'

	INSERT INTO Productos
	(
	Descripcion, Estado
	)
	SELECT 
	'Monitor DELL 32', 'A'

	INSERT INTO Productos
	(
	Descripcion, Estado
	)
	SELECT 
	'Teléfono Grandstream', 'A'

	SET DATEFORMAT DMY
	INSERT INTO Proveedores
	(
	[Proveedor], [Telefono], [Correo], [Pais], [Direccion], [Estado]
	)
	SELECT 
	'TECNOSYS', '22830101', 'tecnosys@dominio.com', 'ALE', 'Frankfurt, Alemania','A'

	SET DATEFORMAT DMY
	INSERT INTO Proveedores
	(
	[Proveedor], [Telefono], [Correo], [Pais], [Direccion], [Estado]
	)
	SELECT 
	'COMPUTEC', '22830202', 'computec@dominio.com', 'ALE', 'Munich, Alemania','A'

	SET DATEFORMAT DMY
	INSERT INTO Proveedores
	(
	[Proveedor], [Telefono], [Correo], [Pais], [Direccion], [Estado]
	)
	SELECT 
	'INNOVATEC', '22830303', 'innovatec@dominio.com', 'CHI', 'Beijin, China','A'

	SET DATEFORMAT DMY
	INSERT INTO Ordenes
	(
	[Solicitante], [DiasCredito], [Fecha_Orden], [Id_Proveedor], [TipoOrden], [Descripcion], [Estado]
	)
	SELECT 
	'Luis Fernando Salas Rojas', '30', '21-06-2024', '1','C','Suministros de oficina', 'A'

	SET DATEFORMAT DMY
	INSERT INTO Ordenes
	(
	[Solicitante], [DiasCredito], [Fecha_Orden], [Id_Proveedor], [TipoOrden], [Descripcion], [Estado]
	)
	SELECT 
	'Fiorella Castro Oviedo', '60', '21-06-2024', '1','C','Suministros de TI', 'A'

	SET DATEFORMAT DMY
	INSERT INTO Ordenes
	(
	[Solicitante], [DiasCredito], [Fecha_Orden], [Id_Proveedor], [TipoOrden], [Descripcion], [Estado]
	)
	SELECT 
	'Alicia Redondo Trejos', '32', '21-06-2024', '1','F','Suministros de Contabilidad', 'A'

	SET DATEFORMAT DMY
	INSERT INTO Ordenes
	(
	[Solicitante], [DiasCredito], [Fecha_Orden], [Id_Proveedor], [TipoOrden], [Descripcion], [Estado]
	)
	SELECT 
	'Paola Navarrate Allón', '32', '21-06-2024', '2','F','Suministros de RRHH', 'A'

	SET DATEFORMAT DMY
	INSERT INTO Ordenes
	(
	[Solicitante], [DiasCredito], [Fecha_Orden], [Id_Proveedor], [TipoOrden], [Descripcion], [Estado]
	)
	SELECT 
	'Daniel Fuentes Cepeda', '60', '21-06-2024', '3','F','Suministros de Finanzas', 'A'

	SET DATEFORMAT DMY
	INSERT INTO Ordenes
	(
	[Solicitante], [DiasCredito], [Fecha_Orden], [Id_Proveedor], [TipoOrden], [Descripcion], [Estado]
	)
	SELECT 
	'Adrián Chichilla Lazo', '30', '21-06-2024', '3','F','Suministros de Gerencia', 'A'


	INSERT INTO Productos_X_Orden
	(
	Id_Producto, Id_Orden
	)
	SELECT Id_Producto, 1
	FROM Productos

	INSERT INTO Productos_X_Orden
	(
	Id_Producto, Id_Orden
	)
	SELECT Id_Producto, 2
	FROM Productos

END
GO

SELECT * FROM Usuarios