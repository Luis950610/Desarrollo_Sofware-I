/*  ***************************************************************************************** 
	|						DDL(LENGUAJE DE DEFINICION DE DATOS)							| 
	***************************************************************************************** */
	USE MASTER
	GO

/*  ***************************************************************************************** 
	|						CREACION DE LA BASE DE DATOS DEL SISTEMA						|
	*****************************************************************************************  */
	CREATE DATABASE db_BDSistemaMantenimientosCCI
	GO

/*  ***************************************************************************************** 
	|						CREACION DE LAS TABLAS DEL SISTEMA								|
	*****************************************************************************************  */
	USE db_BDSistemaMantenimientosCCI

-- Crear tipos de datos para las claves primarias
	USE db_BDSistemaMantenimientosCCI
	EXEC sp_addtype TCod_Estudiante, 'varchar(6)','NOT NULL'
	EXEC sp_addtype TCod_Docente, 'varchar(10)','NOT NULL'
	EXEC sp_addtype TCod_Curso, 'varchar(8)','NOT NULL'
	EXEC sp_addtype TCod_Pago,	'varchar(7)', 'NOT NULL'
	EXEC sp_addtype TCod_DetallePago, 'varchar(7)', 'NOT NULL'
	EXEC sp_addtype TCodBoleta, 'varchar(12)','NOT NULL'
	EXEC sp_addtype TCodCursoActivo, 'varchar(12)','NOT NULL'
	exec sp_addtype TCodMatricula, 'varchar(8)','NOT NULL'

/*========================== TABLA ESTUDIANTE ==========================*/
	CREATE TABLE Estudiante
	(
		-- Lista de atributos de la tabla Estudiante
		Codigo_Estudiante TCod_Estudiante,
		Apellido_Paterno VARCHAR(40) NOT NULL,
		Apellido_Materno VARCHAR(40) NOT NULL,
		Nombres VARCHAR(20) NOT NULL,
		DNI VARCHAR(20) NOT NULL,
		Sexo VARCHAR(1) NOT NULL,
		Direccion VARCHAR(100) NOT NULL,
		Telefono VARCHAR(10) NOT NULL,
		Email VARCHAR(50) NOT NULL,
		Foto IMAGE,
		-- Definicion de claves
		PRIMARY KEY(Codigo_Estudiante)
	)
	GO

/*========================== TABLA CURSO ==========================*/
	CREATE TABLE MantenimientoCurso
	(
		-- Lista de atributos de la tabla Curso
		CodigoCurso TCod_Curso,
		Nombre VARCHAR(50) NOT NULL,
		Tipo VARCHAR(5)	NOT NULL,
		Temas VARCHAR(50) NOT NULL,
		HorasxSemana INT,
		-- Definicion de claves
		PRIMARY KEY (CodigoCurso)
	)
	GO

/*========================== TABLA DOCENTE ==========================*/
	CREATE TABLE Docentes
	(
		-- Lista de atributos de la tabla Docente
		CodDocente TCod_Docente,
		Nombre VARCHAR(30) NOT NULL,
		ApellidoP VARCHAR(20) NOT NULL,
		ApellidoM VARCHAR(20) NOT NULL,
		TipoDocentes VARCHAR(10) NOT NULL,
		Direccion VARCHAR(80) NOT NULL,
		Correo VARCHAR(50) NOT NULL,
		Celular VARCHAR(9) NOT NULL,
		Sexo VARCHAR(3)	NOT NULL,
		foto IMAGE NOT NULL,
		-- Definicion de claves
		PRIMARY KEY (CodDocente)
	)
	GO

/*========================== TABLA DETALLE PAGO ==========================*/
	CREATE TABLE Detalle_Pago
	(
		-- Lista de atributos de la tabla Detalle_Pago
		Cod_DetallePago	TCod_DetallePago,
		Importe	INTEGER,
		Metodo_Pago	VARCHAR(20) NOT NULL,
		Descripcion	VARCHAR(80) NOT NULL,
		-- Definicion de claves
		PRIMARY KEY(Cod_DetallePago)
	)
	GO

/*========================== TABLA PAGO ==========================*/
	CREATE TABLE Pago
	(
		-- Lista de atributos de la tabla Pago
		Cod_Pago		TCod_Pago,
		Codigo_Estudiante TCod_Estudiante,
		CodigoCurso		TCod_Curso,
		Cod_DetallePago	TCod_DetallePago,
		-- Definicion de claves
		PRIMARY KEY		(Cod_Pago),
		FOREIGN KEY (Codigo_Estudiante) REFERENCES Estudiante(Codigo_Estudiante),
		FOREIGN KEY (CodigoCurso) REFERENCES MantenimientoCurso(CodigoCurso),
		FOREIGN KEY (Cod_DetallePago) REFERENCES Detalle_Pago(Cod_DetallePago)
	)
	GO

/*========================== TABLA BOLETA ==========================*/
	create table Boleta
	( 
		-- Lista de atributos de la tala Boleta
		CodBoleta          TCodBoleta NOT NULL,
		NroSerie			VARCHAR(10) not null,
		FechaEmision		VARCHAR(50) not null,
		Costo           NUMERIC(15,2) CHECK(Costo > 0) ,
		TipoDsto      VARCHAR(15) CHECK (TipoDsto in ('DCTO1','DCTO2','DCTO3','DCTO4','DCTO5')),
		Pago           NUMERIC(15,2) CHECK(Pago > 0),
		CodCursoActivo  VARCHAR(15) Not NULL,
		Codigo_Estudiante TCod_Estudiante,
		Observacion   VARCHAR(50) not null
		-- Definicion de claves
		PRIMARY KEY (CodBoleta),
		FOREIGN KEY (Codigo_Estudiante) REFERENCES Estudiante(Codigo_Estudiante)
	)
	GO

/*========================== TABLA CURSO ACTIVO ==========================*/
	create table CursoActivo
	(
		-- Lista de atributos de la tabla Curso_Activo
		CodCursoActivo TCodCursoActivo not null,
		Grupo VARCHAR(1),
		Nombre VARCHAR(50),
		Tipo VARCHAR(3),
		HorasxSemana int,
		Dias VARCHAR(20),
		Hora VARCHAR(5),
		Periodo VARCHAR(11),
		Año VARCHAR(4),
		-- Definicion de claves
		primary key(CodCursoActivo,Grupo,Periodo,Año)
	)
	GO

/*========================== TABLA MATRICULA ==========================*/
	CREATE TABLE Matricula
	( 
		-- Lista de atributos de la tabla Matricula
		CodMatricula  TCodMatricula NOT NULL,
		Anio VARCHAR(4) not null,
		Mes VARCHAR(15) not null,
		CodCursoActivo TCodCursoActivo not null,
		CodBoleta   TCodBoleta not null,
		-- Definicion de claves
		PRIMARY KEY (CodMatricula),
		FOREIGN KEY (CodBoleta) REFERENCES Boleta(CodBoleta),
		FOREIGN KEY (CodCursoActivo) REFERENCES CursoActivo(CodCursoActivo),
	 )
	 GO

 /*========================== TABLA CARGA ACADEMICA ==========================*/
	CREATE TABLE CargaAcademica
	(
		-- Lista de atributos de la tabla Carga_Academica
		CodCargAcademica INT IDENTITY(1,1) not null,
		CodCursoActivo TCodCursoActivo,
		Grupo VARCHAR(1),
		CodDocente INT,
		Periodo VARCHAR(11),
		Año VARCHAR(4),
		-- Definicion de claves
		PRIMARY KEY(CodCargAcademica),
		FOREIGN KEY(CodCursoActivo,Grupo,Periodo,Año) REFERENCES CursoActivo,
		FOREIGN KEY(CodDocente)REFERENCES Docentes
	)
	GO

/*  ***************************************************************************************** 
	|					PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS						|
	*****************************************************************************************  */
	USE DATABASE db_BDSistemaMantenimientosCCI
	GO
/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ESTUDIANTE ================== */
/* ---------------- Funcion para Generar Codigo del Estudiante ---------------*/
	CREATE FUNCTION fnGenerarCodEstudiante()
	RETURNS VARCHAR(6)
	AS
	BEGIN
			-- Declarar variables para generar codigo
			DECLARE @CodNuevo VARCHAR(6), @CodMax VARCHAR(6)
			SET @CodMax = (SELECT MAX(Codigo_Estudiante) FROM Estudiante)
			SET @CodMax = ISNULL(@CodMax,'A00000')
			SET @CodNuevo = 'A'+RIGHT(RIGHT(@CodMax,4)+10001,4)
			RETURN @CodNuevo
	END;
	GO
/* ---------------- Procedimiento para Insertar un nuevo Estudiante --------------- */
	CREATE PROCEDURE spInsertarEstudiante	
		@Codigo_Estudiante VARCHAR(6),
		@Apellido_Paterno VARCHAR(40),
		@Apellido_Materno VARCHAR(40),
		@Nombres VARCHAR(20),
		@DNI VARCHAR(20),
		@Sexo VARCHAR(1),
		@Direccion VARCHAR(100),
		@Telefono VARCHAR(10),
		@Email VARCHAR(50),
		@Foto IMAGE
	AS
	BEGIN
		begin try
			begin tran
				-- Insertar estudiante en la tabla de Estudiante
				INSERT INTO Estudiante
					VALUES (DBO.fnGenerarCodEstudiante(),@Apellido_Paterno,@Apellido_Materno,@Nombres, @DNI, @Sexo, @Direccion, @Telefono, @Email, @Foto)
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch

	END;
	GO

	/* ---------------- Procedimiento para Eliminar un Estudiante --------------- */
	CREATE PROCEDURE speliminar_estudiante
		@Codigo_Estudiante VARCHAR(6)
	AS
		-- Eliminar estudiante de la tabla
		DELETE FROM Estudiante
		-- Parametro de comparacion
		WHERE Codigo_Estudiante=@Codigo_Estudiante
	GO
	/* ---------------- Procedimiento para Editar un Estudiante --------------- */
	CREATE PROCEDURE speditar_estudiante
		@Codigo_Estudiante VARCHAR(6),
		@Apellido_Paterno VARCHAR(40),
		@Apellido_Materno VARCHAR(40),
		@Nombres VARCHAR(20),
		@DNI VARCHAR(20),
		@Sexo VARCHAR(1),
		@Direccion VARCHAR(100),
		@Telefono VARCHAR(10),
		@Email VARCHAR(50),
		@Foto IMAGE
	AS
	BEGIN
		begin try
			begin tran
				-- Editar estudiante en la tabla de Estudiante
				UPDATE Estudiante SET	Apellido_Paterno=@Apellido_Paterno,
										Apellido_Materno=@Apellido_Materno,
										Nombres=@Nombres,
										DNI=@DNI,
										Sexo=@Sexo,
										Direccion=@Direccion,
										Telefono=@Telefono,
										Email=@Email,
										Foto=@Foto
										-- Parametro de comparación
				WHERE Codigo_Estudiante=@Codigo_Estudiante
				commit tran
		end try
		begin catch
				select ERROR_MESSAGE()
				rollback tran
		end catch
	END;
	GO

	/* ---------------- Procedimiento para Buscar un Estudiante --------------- */
	CREATE PROCEDURE spbuscar_estudiante_codigo
		@codigobuscar VARCHAR(6)
	AS	
		SELECT * FROM Estudiante
		WHERE Codigo_Estudiante like @codigobuscar + '%'
	GO

	/* ---------------- Procedimiento para Listar Estudiantes --------------- */
	CREATE PROCEDURE spmostrar_estudiante
	AS
		SELECT  TOP 100 * FROM Estudiante
		ORDER BY Codigo_Estudiante ASC
	GO

/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA CURSO ================== */
	/* ---------------- Procedimiento para listar Cursos --------------- */
	CREATE PROCEDURE sp_listar_mCurso
	AS
		SELECT * FROM MantenimientoCurso 
		ORDER BY CodigoCurso ASC
	GO

	/* ---------------- Procedimiento para buscar Curso --------------- */
	CREATE PROCEDURE sp_Buscar_mCurso
		@Nombre VARCHAR(50)
	AS
		SELECT * FROM MantenimientoCurso
		WHERE Nombre like @Nombre+'%'
	GO

	/* ---------------- Procedimiento para Mantenimiento Curso --------------- */
	CREATE PROC sp_Mantenimiento_mCurso
		@CodigoCurso VARCHAR(8),
		@Nombre VARCHAR(50),
		@Tipo VARCHAR(5),
		@Temas VARCHAR(50),
		@HorasxSemana int,
		@accion VARCHAR(50) OUTPUT
	AS
	IF(@accion='1')
	BEGIN TRY
	--para probar
		DECLARE @CodigoNuevo VARCHAR(8),@CodigoMax VARCHAR(8)
		SET @CodigoMax=(select max(CodigoCurso)from MantenimientoCurso)
		SET @CodigoMax=isnull(@CodigoMax,'IF000')
		SET @CodigoNuevo='IF'+RIGHT(RIGHT(@CodigoMax,3)+11001,3)
		BEGIN TRANSACTION
		INSERT INTO MantenimientoCurso(CodigoCurso,Nombre,Tipo,Temas,HorasxSemana)
		VALUES(@CodigoNuevo,@Nombre,@Tipo,@Temas,@HorasxSemana)
		COMMIT TRANSACTION
		SET @accion='Se genero el codigo: '+@CodigoNuevo
	END TRY

	BEGIN CATCH
		--ejecutar si ocurre un error
		PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
		PRINT'Error Message : '+ERROR_MESSAGE();
		PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
		PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
		PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
		PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
		ROLLBACK TRANSACTION;
	END CATCH

	ELSE IF(@accion='2')
	BEGIN TRY
		BEGIN TRANSACTION
		update MantenimientoCurso SET Nombre=@Nombre,Tipo=@Tipo,Temas=@Temas,HorasxSemana=@HorasxSemana WHERE CodigoCurso=@CodigoCurso
		COMMIT TRANSACTION
		SET @accion='Se modifico el codigo:' + @CodigoCurso
	END TRY
	BEGIN CATCH
		--ejecutar si ocurre un error
		PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
		PRINT'Error Message : '+ERROR_MESSAGE();
		PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
		PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
		PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
		PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
		ROLLBACK TRANSACTION;
	END CATCH
	ELSE IF(@accion='3')
	BEGIN TRY
		BEGIN TRANSACTION
		DELETE FROM MantenimientoCurso
		WHERE CodigoCurso=@CodigoCurso
		COMMIT TRANSACTION
		SET @accion='Se borro el codigo: '+@CodigoCurso
	END TRY
	BEGIN CATCH
		--ejecutar si ocurre un error
		PRINT'Error Number : '+CAST(ERROR_NUMBER()AS VARCHAR(10));
		PRINT'Error Message : '+ERROR_MESSAGE();
		PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS VARCHAR(10));
		PRINT'Error State : '+CAST(ERROR_STATE()AS VARCHAR(10));
		PRINT'Error Line : '+CAST(ERROR_LINE()AS VARCHAR(10));
		PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
		ROLLBACK TRANSACTION;
	END CATCH
	GO
/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA DOCENTE ================== */
	/* ---------------- Procedimiento para Listar Docentes --------------- */
	Create procedure ListarDocentes
	AS
	--empesar una transaccion
	BEGIN TRY
	BEGIN TRAN
	-- Mostrar Datos
	select *
		from Docentes
		order by CodDocente ASC;
	-- Aceptar una transaccion | validar una transaccion
	COMMIT
	END TRY

	BEGIN CATCH
	--- Cancelar una trans accion
	ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH -- deteccion de errores
	GO
	/* ---------------- Procedimiento para Insertar Docentes --------------- */
	CREATE PROCEDURE AgregarDocente 
		@Codigo varchar(10), 
		@Nombre varchar(30), 
		@ApellidoP varchar(20),
		@ApellidoM varchar(20), 
		@TipoDocentes varchar(10), 
		@Direccion varchar(80), 
		@Correo varchar(50), 
		@Celular varchar(9),
		@Sexo varchar(3), 
		@foto image
	AS
	BEGIN TRY
	BEGIN TRAN

		INSERT INTO Docentes(CodDocente, Nombre, ApellidoP, ApellidoM, TipoDocentes, Direccion, Correo, Celular, Sexo, foto) 
		VALUES(@Codigo, @Nombre, @ApellidoP, @ApellidoM, @TipoDocentes, @Direccion, @Correo, @Celular, @Sexo, @foto)
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO
	/* ---------------- Procedimiento para Editar Docentes --------------- */
	CREATE PROCEDURE EditarDocente 
		@Codigo varchar(10), 
		@Nombre varchar(30), 
		@ApellidoP varchar(20), 
		@ApellidoM varchar(20), 
		@TipoDocentes varchar(10), 
		@Direccion varchar(80), 
		@Correo varchar(50), 
		@Celular varchar(9), 
		@Sexo varchar(3), 
		@foto image
	AS
	BEGIN TRY
		BEGIN TRAN
			update Docentes 
			set  Nombre =@Nombre, ApellidoP = @ApellidoP, ApellidoM = @ApellidoM, TipoDocentes = @TipoDocentes, Direccion = @Direccion, Correo = @Correo, Celular = @Celular, Sexo = @Sexo, foto = @foto
			where CodDocente like @Codigo +'%'
		COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

	/* ---------------- Procedimiento para Eliminar Docentes --------------- */
	CREATE PROCEDURE EliminarDocente
		@Codigo varchar(10)
	AS
		BEGIN TRY
			BEGIN TRAN
				delete from Docentes where CodDocente like @Codigo +'%'
			COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK
			PRINT ERROR_MESSAGE()
		END CATCH
	GO

	/* ---------------- Procedimiento para Buscar Docentes por Codigo --------------- */
	CREATE PROCEDURE BuscarDocente @Codigo varchar(10)
	AS
	BEGIN TRY
		BEGIN TRAN
		select * from Docentes
		where CodDocente like @Codigo + '%'
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO

/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA MATRICULA ================== */
	/* ---------------- Procedimiento para Recuperar Datos de un Curso por Codigo --------------- */

/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA CARGA ACADEMICA ================== */
/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA BOLETA ================== */