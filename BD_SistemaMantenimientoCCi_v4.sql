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

	/*========================================================================================================*/
	/*= = = = = = = = = = = = = = = = = = = = = = PRIMER SPRINT = = = = = = = = = = = = = = = = = = = = = =*/
	/*========================================================================================================*/

	/*  ***************************************************************************************** 
	|						CREACION DE LAS TABLAS DEL SISTEMA								|
	*****************************************************************************************  */
	-- Crear tipos de datos para las claves primarias
	USE db_BDSistemaMantenimientosCCI
	EXEC  sp_addtype  TCod_Estudiante, 'varchar(6)','NOT NULL'  -- Grupo 01
	EXEC  sp_addtype  TCod_Docente, 'varchar(6)','NOT NULL'		-- Grupo 03
	EXEC  sp_addtype  TCod_Curso,	'varchar(5)', 'not null'    -- Grupo 02
	EXEC  sp_addtype  TCod_DetallePago,    'varchar(7)', 'not null' -- Grupo 04
	EXEC  sp_addtype  TCod_Pago,	'varchar(7)', 'not null'	-- Grupo 04
	EXEC  sp_addtype  TCodCursoActivo, 'varchar(5)','NOT NULL' -- Grupo 05
	EXEC  sp_addtype  TCodBoleta, 'varchar(12)','NOT NULL'		-- Grupo 05
	EXEC  sp_addtype  TCodMatricula, 'varchar(8)','NOT NULL'	-- Grupo 05

	/*========================== TABLA ESTUDIANTE - GRUPO 01 ==========================*/
	CREATE TABLE TEstudiante
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
	/*========================== TABLA CURSO  - GRUPO 02 ==========================*/
	CREATE TABLE TCurso
	(
	-- Lista de atributos de la tabla Curso
		Codigo_Curso TCod_Curso,
		Nombre_Curso VARCHAR(50) NOT NULL,
		Tipo_Curso VARCHAR(5)	NOT NULL,
		Temas VARCHAR(50) NOT NULL,
		HorasxSemana INT,
		Estado Varchar(11) default 'DESACTIVADO',
		-- Definicion de claves
		PRIMARY KEY (Codigo_Curso)
	)
	GO

	/*========================== TABLA DOCENTE  - GRUPO 03 ==========================*/
	CREATE TABLE TDocentes
	(
		-- Lista de atributos de la tabla Docente
		Codigo_Docente TCod_Docente,
		Nombres VARCHAR(30) NOT NULL,
		Apellido_Paterno VARCHAR(20) NOT NULL,
		Apellido_Materno VARCHAR(20) NOT NULL,
		TipoDocentes VARCHAR(10) NOT NULL,
		Direccion VARCHAR(80) NOT NULL,
		Correo VARCHAR(50) NOT NULL,
		Celular VARCHAR(9) NOT NULL,
		Sexo VARCHAR(3)	NOT NULL,
		Foto IMAGE NOT NULL,
		-- Definicion de claves
		PRIMARY KEY (Codigo_Docente)
	)
	GO

	/*========================== TABLA DETALLE PAGO - grupo 04 ==========================*/
	CREATE TABLE TDetalle_Pago
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

	/*========================== TABLA PAGO  - GRUPO 04 ==========================*/
	CREATE TABLE TPago
	(
		-- Lista de atributos de la tabla Pago
		Cod_Pago		TCod_Pago,
		Codigo_Estudiante TCod_Estudiante,
		Codigo_Curso		TCod_Curso,
		Cod_DetallePago	TCod_DetallePago,
		-- Definicion de claves
		PRIMARY KEY	(Cod_Pago),
		FOREIGN KEY (Codigo_Estudiante) REFERENCES TEstudiante(Codigo_Estudiante),
		FOREIGN KEY (Codigo_Curso) REFERENCES TCurso(Codigo_Curso),
		FOREIGN KEY (Cod_DetallePago) REFERENCES TDetalle_Pago(Cod_DetallePago)
	)
	GO

	/*========================== TABLA CONTROL ERRORES - GRUPO 04 ==========================*/
	create table TLogErrores
	(
		ErrorID			INT IDENTITY,
		ErrorNumbre		INT NOT NULL,
		ErrorMessage	VARCHAR(300),
		ErrorLine		INT,	
		ErrorProcedure	VARCHAR(100),
		DateTimeError	SMALLDATETIME,
		HostName		VARCHAR(75),
		DBName			VARCHAR(75)
	)
	GO

	/*========================== TABLA CURSO ACTIVO - GRUPO 05 ==========================*/
	create table TCursoActivo
	(
		-- Lista de atributos de la tabla Curso_Activo
		Codigo_CursoActivo TCodCursoActivo not null,
		Grupo VARCHAR(1),
		Nombre VARCHAR(50),
		Tema varchar(50), -- Añadido del Grupo 06
		Tipo VARCHAR(3),
		HorasxSemana int,
		Dias VARCHAR(20),
		Hora VARCHAR(5),
		Periodo VARCHAR(11),
		Año VARCHAR(4),
		-- Definicion de claves
		primary key(Codigo_CursoActivo)
	)
	GO

	/*========================== TABLA BOLETA  - GRUPO 05 ==========================*/
	create table TBoleta
	( 
		-- Lista de atributos de la tala Boleta
		Codigo_Boleta  TCodBoleta NOT NULL,
		NroSerie	 VARCHAR(10) not null,
		FechaEmision VARCHAR(50) not null,
		Costo   NUMERIC(15,2) CHECK(Costo > 0) ,
		TipoDsto  VARCHAR(15) CHECK (TipoDsto in ('DCTO1','DCTO2','DCTO3','DCTO4','DCTO5')),
		Pago    NUMERIC(15,2) CHECK(Pago > 0),
		Codigo_CursoActivo  TCodCursoActivo,
		Codigo_Estudiante TCod_Estudiante,
		Observacion   VARCHAR(50) not null
		-- Definicion de claves
		PRIMARY KEY (Codigo_Boleta),
		FOREIGN KEY (Codigo_Estudiante) REFERENCES TEstudiante(Codigo_Estudiante)
	)
	GO

	/*========================== TABLA MATRICULA  - GRUPO 05 ==========================*/
	CREATE TABLE TMatricula
	( 
		-- Lista de atributos de la tabla Matricula
		CodMatricula  TCodMatricula NOT NULL,
		Anio VARCHAR(4) not null,
		Mes VARCHAR(15) not null,
		CodCursoActivo TCodCursoActivo not null,
		CodBoleta   TCodBoleta not null,
		-- Definicion de claves
		PRIMARY KEY (CodMatricula),
		FOREIGN KEY (CodBoleta) REFERENCES TBoleta(Codigo_Boleta),
		FOREIGN KEY (CodCursoActivo) REFERENCES TCursoActivo(Codigo_CursoActivo)
	 )
	 GO

	/*========================== TABLA CARGA ACADEMICA  - GRUPO 06 ==========================*/
	CREATE TABLE TCargaAcademica
	(
		-- Lista de atributos de la tabla Carga_Academica
		CodCargAcademica INT IDENTITY(1,1) not null,
		CodCursoActivo TCodCursoActivo,
		Grupo VARCHAR(1),
		CodDocente TCod_Docente,
		Periodo VARCHAR(11),
		Año VARCHAR(4),
		-- Definicion de claves
		PRIMARY KEY(CodCargAcademica),
		FOREIGN KEY(CodCursoActivo) REFERENCES TCursoActivo,
		FOREIGN KEY(CodDocente)REFERENCES TDocentes
	)
	GO

	/*  ***************************************************************************************** 
		|				FUNCIONES Y PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS				|
		*****************************************************************************************  */
	USE db_BDSistemaMantenimientosCCI
	GO

	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMIENTO ESTUDIANTE  - GRUPO 01 ==================== */
	/* ---------------- Funcion para Generar Codigo del Estudiante ---------------*/
	CREATE FUNCTION fnGenerarCodEstudiante()
	RETURNS VARCHAR(6)
	AS
	BEGIN
			-- Declarar variables para generar codigo
			DECLARE @CodNuevo VARCHAR(6), @CodMax VARCHAR(6)
			SET @CodMax = (SELECT MAX(Codigo_Estudiante) FROM TEstudiante)
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
				INSERT INTO TEstudiante
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
		DELETE FROM TEstudiante
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
				UPDATE TEstudiante SET	Apellido_Paterno=@Apellido_Paterno,
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

	/* ---------------- Procedimiento para Buscar un Estudiante por codigo --------------- */
	CREATE PROCEDURE spbuscar_estudiante_codigo
		@codigobuscar VARCHAR(6)
	AS	
		SELECT * FROM TEstudiante
		WHERE Codigo_Estudiante like @codigobuscar + '%'
	GO

	/* ---------------- Procedimiento para Buscar un Estudiante por apellido --------------- */
	CREATE PROCEDURE spbuscar_estudiante_apellido
	@codigobuscar VARCHAR(6)
	AS	
		SELECT * FROM TEstudiante
		--WHERE Codigo_Estudiante like @codigobuscar + '%'
		WHERE Apellido_Paterno like @codigobuscar + '%'
	GO

	/* ---------------- Procedimiento para Listar Estudiantes --------------- */
	CREATE PROCEDURE spmostrar_estudiante
	AS
		SELECT  TOP 100 * FROM TEstudiante
		ORDER BY Codigo_Estudiante ASC
	GO


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMIENTO CURSO - GRUPO 02 ================== */
	/* ---------------- Procedimiento para listar Cursos --------------- */
	CREATE PROCEDURE sp_listar_mCurso
	AS
		SELECT * FROM TCurso 
		ORDER BY Codigo_Curso ASC
	GO

	/* ---------------- Procedimiento para buscar Curso --------------- */
	CREATE PROCEDURE sp_Buscar_mCurso
		@Nombre VARCHAR(50)
	AS
		SELECT * FROM TCurso
		WHERE Nombre_Curso like @Nombre+'%'
	GO

	/* ---------------- Procedimiento para Mantenimiento Curso --------------- */ --REVISION
	CREATE PROC sp_Mantenimiento_mCurso
		@CodigoCurso VARCHAR(8),
		@Nombre VARCHAR(50),
		@Tipo VARCHAR(5),
		@Temas VARCHAR(50),
		@Estado VARCHAR(11),
		@HorasxSemana int,
		@accion VARCHAR(50) OUTPUT
	AS
	IF(@accion='1')
	BEGIN TRY
	--para probar
		DECLARE @CodigoNuevo VARCHAR(8),@CodigoMax VARCHAR(8)
		SET @CodigoMax=(select max(Codigo_Curso)from TCurso)
		SET @CodigoMax=isnull(@CodigoMax,'IF000')
		SET @CodigoNuevo='IF'+RIGHT(RIGHT(@CodigoMax,3)+11001,3)
		BEGIN TRANSACTION
			INSERT INTO TCurso(Codigo_Curso,Nombre_Curso,Tipo_Curso,Temas,HorasxSemana)
			VALUES(@CodigoNuevo,@Nombre,@Tipo,@Temas,@Estado,@HorasxSemana)
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
		update TCurso SET Nombre_Curso=@Nombre,Tipo_Curso=@Tipo,Temas=@Temas,HorasxSemana=@HorasxSemana WHERE Codigo_Curso=@CodigoCurso
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
		DELETE FROM TCurso
		WHERE Codigo_Curso=@CodigoCurso
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


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO MANTENIMEINTO DOCENTE - GRUPO 03 ================== */
	/* ---------------- Procedimiento para Listar Docentes --------------- */
	Create procedure ListarDocentes
	AS
	--empesar una transaccion
	BEGIN TRY
		BEGIN TRAN
		-- Mostrar Datos
		select *
			from TDocentes
			order by Codigo_Docente ASC;
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

		INSERT INTO TDocentes(Codigo_Docente, Nombres, Apellido_Paterno, Apellido_Materno, TipoDocentes, Direccion, Correo, Celular, Sexo, foto) 
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
			update TDocentes 
			set  Nombres =@Nombre, Apellido_Paterno = @ApellidoP, Apellido_Materno = @ApellidoM, TipoDocentes = @TipoDocentes, Direccion = @Direccion, Correo = @Correo, Celular = @Celular, Sexo = @Sexo, foto = @foto
			where Codigo_Docente like @Codigo +'%'
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
				delete from TDocentes where Codigo_Docente like @Codigo +'%'
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
		select * from TDocentes
		where Codigo_Docente like @Codigo + '%'
	COMMIT
	END TRY

	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()
	END CATCH
	GO


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO ACTIVACION_CURSO  - GRUPO 04 ================== */
	/* ---------------- Procedimiento para Recuperar Datos de un Curso por Codigo --------------- */
	CREATE PROCEDURE pRecuperarCursoCodigo @Cod_Curso varchar(4)
	AS
	BEGIN
		SELECT Codigo_Curso, COUNT(Codigo_Curso) as NroAlumno
		INTO #TEMP1
		FROM TPago
		GROUP BY Codigo_Curso

		SELECT C.Codigo_Curso, C.Nombre_Curso, C.Tipo_Curso, C.Estado, C.Temas, C.HorasxSemana, T.NroAlumno
		FROM TCurso C inner join #TEMP1 T on C.Codigo_Curso = T.Codigo_Curso
		WHERE C.Codigo_Curso = @Cod_Curso
	END
	GO

	/* ---------------- Procedimiento para Recuperar Datos de un Curso por Nombre --------------- */
	create procedure pRecuperarCursoNombre 
		@Nombre_Curso varchar(80)
	as
	begin
		SELECT Codigo_Curso, COUNT(Codigo_Curso) as NroAlumno
		INTO #TEMP1
		FROM TPago
		GROUP BY Codigo_Curso
		SELECT C.Codigo_Curso, C.Nombre_Curso, C.Estado, C.HorasxSemana, T.NroAlumno
		FROM TCurso C inner join #TEMP1 T on C.Codigo_Curso = T.Codigo_Curso
		WHERE C.Nombre_Curso = @Nombre_Curso
	end
	GO

	/* ---------------- Procedimiento para Listar alumnos de un determinado curso por Codigo --------------- */
	create procedure pListaAlumnos @Cod_Curso varchar(4)
	as
	begin
		select P.Codigo_Curso, A.Codigo_Estudiante, A.Apellido_Paterno, A.Apellido_Materno, A.Nombres, A.DNI, A.Email
		from TPago P inner join TEstudiante A on P.Codigo_Estudiante = A.Codigo_Estudiante
		where Codigo_Curso = @Cod_Curso
	end;
	GO

	/* ---------------- Procedimiento para Actualizar Estado --------------- */
	create procedure pActulizarEstado @Cod_Curso varchar(4), @Estado varchar(11)
	as
	begin
		BEGIN TRY
			update TCurso
			set Estado = @Estado
			where Codigo_Curso = @Cod_Curso
		END TRY
		BEGIN CATCH
			INSERT INTO TLogErrores(ErrorNumbre,ErrorMessage,ErrorLine,ErrorProcedure,
						DateTimeError,HostName,DBName)
			SELECT	ERROR_NUMBER(),
					ERROR_MESSAGE(),
					ERROR_LINE(),
					ERROR_PROCEDURE(),
					GETDATE(),
					HOST_NAME(),
					DB_NAME()
		END CATCH
	end
	GO

	/* ---------------- Procedimiento para Listar Cursos Activados o Desactivados --------------- */
	create procedure pListarCursos 
	@Estado varchar(11)
	as
	begin
		SELECT Codigo_Curso, COUNT(Codigo_Curso) as NroAlumno
		INTO #TEMP1
		FROM TPago
		GROUP BY Codigo_Curso

		SELECT C.Codigo_Curso, C.Nombre_Curso, C.Estado, C.HorasxSemana, T.NroAlumno
		FROM TCurso C inner join #TEMP1 T on C.Codigo_Curso = T.Codigo_Curso
		WHERE C.Estado = @Estado
	end
	GO


	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO ACTIVACION_CURSO  - GRUPO 05 ================== */
	/* ---------------- Procedimiento para Buscar Estudiante Matriculado --------------- */
	create proc SP_Buscar_EstudianteMatriculado
	@Codigo varchar(50)
	AS
	BEGIN TRY
		begin tran
		select*
		from TEstudiante
		where Codigo_Estudiante like @Codigo+'%'
		commit tran
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE()
		ROLLBACK TRAN
	END CATCH
	GO

	/* ---------------- Procedimiento para Detalle de Matricula Estudiante --------------- */
	CREATE PROCEDURE SP_DetalleMatriculaEstudiante
	AS
	BEGIN
		BEGIN TRY
			begin tran
			SELECT E.Codigo_Estudiante,E.Nombres,E.Apellido_Paterno,E.Apellido_Materno,E.DNI,E.Email,
				B.NroSerie, B.Codigo_Boleta,B.Pago,B.TipoDsto,B.Costo,B.Observacion
				FROM TEstudiante E inner join TBoleta B
				ON  (E.Codigo_Estudiante = B.Codigo_Estudiante)
		   commit tran
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
			ROLLBACK TRAN
		END CATCH
	END;
	GO

	/* ---------------- Procedimiento para Mantenimiento de Estudiante Matriculado --------------- */
	-- Comprobación por el visual
	CREATE PROCEDURE SP_Mantenimiento_EstudianteMatriculado
		@CodEstudiante varchar(12),
		@Apellido_Paterno varchar(40),
		@Apellido_Materno varchar(40),
		@Nombres varchar(40),
		@DNI varchar(8),
		@Sexo VARCHAR(1),
		@Direccion VARCHAR(100),
		@Telefono VARCHAR(10),
		@Email VARCHAR(50),
		@Foto IMAGE,
		@accion varchar(50) output
	AS
	BEGIN
		IF(@accion='1')
			BEGIN TRY
				begin tran
				insert into TEstudiante(Codigo_Estudiante,Apellido_Paterno,Apellido_Materno,Nombres,DNI,Sexo,Direccion,Telefono,Email,Foto)
				values(@CodEstudiante,@Apellido_Paterno,@Apellido_Materno,@Nombres,@DNI,@Sexo,@Direccion,@Telefono,@Email,@Foto)
				set @accion='Se genero el codigo: '+@CodEstudiante
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='2')
			BEGIN TRY
				begin tran
				update TEstudiante set Nombres=@Nombres,Apellido_Paterno=@Apellido_Paterno,Apellido_Materno=@Apellido_Materno,DNI=@DNI,Sexo=@Sexo,Direccion=@Direccion,Telefono=@Telefono,Email=@Email,Foto=@Foto where Codigo_Estudiante=@CodEstudiante
				set @accion='Se modifico el codigo:' + @CodEstudiante
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='3')
			BEGIN TRY
				begin tran
				DELETE FROM TEstudiante
				WHERE Codigo_Estudiante=@CodEstudiante
				SET @accion='Se borro el codigo: '+@CodEstudiante
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
	END;
	GO

	/* ---------------- Procedimiento para Listar Estudiante Matriculado --------------- */
	CREATE PROCEDURE SP_Listar_EstudianteMatriculado
	AS
	BEGIN 
		BEGIN TRY
			begin tran
			select*
			from TEstudiante 
			order by Codigo_Estudiante
			commit tran
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
			ROLLBACK TRAN
		END CATCH
	END;
	GO

	/* ---------------- Procedimiento para Agregar Boleta Estudiante --------------- */
	CREATE PROCEDURE SP_AgregarBoletaEstudiante
		@NroBoleta varchar(12),
		@NroSerie varchar(10),
		@FechaEmision varchar(50),
		@Costo numeric,
		@TipoDcto varchar(15) ,
		@Pago numeric ,
		@CodCurso varchar(15),
		@CodEstudiante varchar(12),
		@Observacion varchar(70)
	AS
	BEGIN
		BEGIN TRY
			begin tran
			INSERT INTO TBoleta values (@NroBoleta,@NroSerie,@FechaEmision,@Costo,@TipoDcto,@Pago,@CodCurso,@CodEstudiante,@Observacion)
			commit tran
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE()
			ROLLBACK TRAN
		END CATCH

	END;
	GO

	/* ---------------- Procedimiento para Mantenimiento Boleta Estudiante --------------- */
	-- Comprobacion por el visual
	CREATE PROCEDURE SP_Mantenimiento_BoletadeMatricula
		@CodBoleta varchar(12),
		@NroSerie varchar(10),
		@FechaEmision varchar(50),
		@Costo numeric(15,2),
		@TipoDsto varchar(15),
		@Pago numeric(15,2),
		@CodCursoActivo varchar(15),
		@CodEstudiante varchar(12),
		@Observacion varchar(50),
		@accion varchar(50) output
	AS
	BEGIN
		IF(@accion='1')
			BEGIN TRY
				begin tran
				insert into TBoleta(Codigo_Boleta,NroSerie,FechaEmision,Costo,TipoDsto,Pago,CodCursoActivo,Codigo_Estudiante,Observacion)
				values(@CodBoleta,@NroSerie,@FechaEmision,@Costo,@TipoDsto,@Pago,@CodCursoActivo,@CodEstudiante,@Observacion)
				set @accion='Se genero el codigo: '+ @CodBoleta
				commit tran
			END TRY
			BEGIN CATCH
					SELECT ERROR_MESSAGE()
					ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='2')
			BEGIN TRY
				begin tran
				update TBoleta set Codigo_Boleta = @CodBoleta,NroSerie = @NroSerie, FechaEmision=@FechaEmision,Costo = @Costo,TipoDsto = @TipoDsto,
				Pago = @Pago,Codigo_CursoActivo = @CodCursoActivo,Codigo_Estudiante = @CodEstudiante,Observacion = @Observacion
				where Codigo_Boleta=@CodBoleta
				set @accion='Se modifico el codigo:' + @CodBoleta
				commit tran
			END TRY
			BEGIN CATCH
					SELECT ERROR_MESSAGE()
					ROLLBACK TRAN
			END CATCH
		ELSE IF(@accion='3')
			BEGIN TRY
				begin tran
				DELETE FROM  TBoleta
				WHERE Codigo_Boleta = @CodBoleta
				SET @accion='Se borro el codigo: '+ @CodBoleta
				commit tran
			END TRY
			BEGIN CATCH
				SELECT ERROR_MESSAGE()
				ROLLBACK TRAN
			END CATCH
	END;
	GO

	/* ---------------- Procedimiento para Descuento Matricula Estudiante --------------- */
	CREATE PROCEDURE SP_Mostrar_TipoDescuento
	AS
	BEGIN 
	BEGIN TRY 
		begin tran
		SELECT DISTINCT TipoDsto FROM tBoleta
		commit tran
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE()
		ROLLBACK TRAN
	END CATCH
	END;
	GO

	/* ---------------- Procedimiento para Curso Activo --------------- */
	CREATE PROCEDURE SP_Mostrar_CursoActivo
	AS
	BEGIN 
	BEGIN TRY 
		begin tran
		SELECT Codigo_CursoActivo,Nombre,CONCAT(Codigo_CursoActivo,' - ',Nombre) as Codigo FROM TCursoActivo
		commit tran
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE()
		ROLLBACK TRAN
	END CATCH
	END;
	GO

	/* ================== PROCEDIMIENTOS ALMACENADOS PARA EL MODULO ASIGNACIÓN-CARGA-DOCENTE - GRUPO 06 ================== */
	/* ---------------- Procedimiento para Seleccion de Curso --------------- */
	create procedure SP_SeleccionCursos
	as
		select * from TCursoActivo
	go

	/* ---------------- Procedimiento para Seleccion de Curso por Categorias --------------- */
	create procedure SP_SeleccionCursosxCategorias
		@Tipo varchar(3),
		@Periodo varchar(11),
		@Año varchar(4)
	as
		select * from TCursoActivo where Tipo=@Tipo and Periodo=@Periodo and Año=@Año
	go

	/* ---------------- Procedimiento para Buscar los cursos activos por todos los campos --------------- */
	create procedure SP_BuscarCursosxTodosLosCampos
	@cadena varchar(50)
	as
		select*
		from TCursoActivo
		where Codigo_CursoActivo like @cadena+'%' or Grupo like @cadena+'%'
		or Nombre like @cadena+'%' or Tema like @cadena+'%' or Grupo like @cadena+'%'
	go

	/* ---------------- Procedimiento para Buscar Cursos sin Carga Todos los campos --------------- */
	create procedure SP_BuscarCursosSinCargaxTodosLosCamposxCategoria
		@Tipo varchar(3),
		@Periodo varchar(11),
		@Año varchar(4),
		@cadena varchar(60)
	as
		select C.Codigo_CursoActivo,C.Grupo,Nombre,Tema,Tipo,HorasxSemana,DescripcionHorario=C.Dias+':'+C.Hora,C.Periodo,C.Año
			from viCursoSinCargaAcademica V inner join TCursoActivo C
			on V.Codigo_CursoActivo=C.Codigo_CursoActivo and C.Grupo=C.Grupo and V.Periodo=C.Periodo and C.Año=V.Año
			where (C.Codigo_CursoActivo like @cadena+'%' or C.Grupo like @cadena+'%'
				or Nombre like @cadena+'%' or Tema like @cadena+'%')and Tipo=@Tipo and C.Periodo=@Periodo and C.Año=@Año
	go

	/* ---------------- Procedimiento para Seleccionar todos los Docentes --------------- */
	create procedure SP_SeleccionDocentes
	as
		select*from TDocentes
	go

	/* ---------------- Procedimiento para Seleccionar Solo Nombre Completo del Docente --------------- */
	create procedure SP_SeleccionDocentes_SoloNombresCompletos
	as
		select Codigo_Docente,Docente=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres from TDocentes
	go

	/* ---------------- Procedimiento para Buscar Docente por Apellido/Nombres --------------- */
	create procedure SP_BuscarDocentesxApellidosNombres
	@cadena varchar(60)
	as
		select Codigo_Docente,Docente=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres
		from TDocentes
		where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	go

	/* ---------------- Procedimiento para Mostrar Docentes Disponibles --------------- */
	create procedure SP_MostrarDocentesDisponibles
		@Hora varchar(5),
		@Periodo varchar(11),
		@Año varchar(4),
		@Dias varchar(6)
	as
		select T.Codigo_Docente, Docentes_Disponibles=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres
		from (select Codigo_Docente
			from TDocentes T

		except

		select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente

	go

	/* ---------------- Procedimiento para Buscar Docentes Disponibles --------------- */
	create procedure SP_BuscarDocentesDisponibles
	@Hora varchar(5),
	@Periodo varchar(11),
	@Año varchar(4),
	@Dias varchar(7),
	@cadena varchar(100)
	as
		select T.Codigo_Docente, Docentes_Disponibles=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres
		from (select Codigo_Docente
			from TDocentes

		except

		select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente
			where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	go

	/* --- Procedimiento para Mostrar todos los docentes(DISPONIBLES y NO DISPONIBLES)para una hora, dia, periodo y año determinado ---*/
	create procedure SP_MostrarDocentesDisponiblesyNoDisponibles
	@Año varchar(4),
	@Periodo varchar(11),
	@Hora varchar(5),
	@Dias varchar(7),
	@cadena varchar(100)
	as
		select* from(select T.Codigo_Docente, Docentes=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres, Estado='SIN CARGA'
		from (select Codigo_Docente
			from TDocentes

		except

		select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente)RESULTADO 

	UNION
	select T.CodDocente, Docentes_Disponibles=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres,Estado='CON CARGA'
		from(select CodDocente
			from TCargaAcademica CA inner join TCursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.CodDocente=D.Codigo_Docente
	where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	order by Codigo_Docente asc
	go

	/* ---------------- Procedimiento para Carga Academica --------------- */
	create procedure SP_SeleccionCargaAcademica
	as
		select*from TCargaAcademica
	go

	/* ---------------- Procedimiento para Seleccion de Carga Academica por Categoria --------------- */
	create procedure SP_SeleccionCargaAcademicaxCategorias
	@Tipo varchar(3),
	@Periodo varchar(11),
	@Año varchar(4)
	as
		select C.Codigo_CursoActivo, C.Nombre, C.Grupo, Descripcion=C.Dias+':'+C.Hora,Docentes=D.Apellido_Paterno+' '+D.Apellido_Materno+' '+D.Nombres,CA.CodDocente
			from TCursoActivo C inner join TCargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
			where Tipo=@Tipo and CA.Periodo=@Periodo and CA.Año=@Año
	go

	/* ---------------- Procedimiento PARA BUSCAR CARGA ACADEMICA X TODOS LOS CAMPOS X CATEGORIAS ---------------- */
	create procedure SP_BuscarCargaAcademicaxTodosLosCamposxCategorias
	@Tipo varchar(3),
	@Periodo varchar(11),
	@Año varchar(4),
	@cadena varchar(60)
	as
		select CodCargAcademica, C.Codigo_CursoActivo, C.Nombre, C.Grupo, Descripcion=C.Dias+':'+C.Hora,Docentes=D.Apellido_Paterno+' '+D.Apellido_Materno+' '+D.Nombres,CA.CodDocente
			from TCursoActivo C inner join TCargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
			where (C.Codigo_CursoActivo like '%'+@cadena+'%' or C.Nombre like '%'+@cadena+'%'or D.Apellido_Paterno like '%'+@cadena+'%' or D.Nombres like '%'+@cadena+'%' or CA.CodDocente like '%'+@cadena+'%')
			and Tipo=@Tipo and CA.Periodo=@Periodo and CA.Año=@Año
	go

	/*---------------- Procedimiento para Agregar una carga academica ---------------- */
	create procedure SP_AgregarCargaAcademica
		@CodCurso int,
		@Grupo varchar(1),
		@CodDocente int,
		@Periodo varchar(11),
		@Año varchar(4)
	as
		insert into TCargaAcademica values (@CodCurso,@Grupo,@CodDocente,@Periodo,@Año)

	go

	/*---------------- Procedimiento para Eliminar una carga academica ---------------- */
	create procedure SP_EliminarCargaAcademica
		@CodCargaAcademica int
	as
		delete from TCargaAcademica where CodCargAcademica=@CodCargaAcademica
	go

	/*---------------- Procedimiento para Actualizar una carga academica ---------------- */
	create procedure SP_ActualizarCargaAcademica
		@CodCargaAcademica int,
		@CodCurso int,
		@Grupo varchar(1),
		@CodDocente int,
		@Periodo varchar(11),
		@Año varchar(4)
	as
		update TCargaAcademica 
			set CodDocente=@CodDocente
			where CodCargAcademica=@CodCargaAcademica;

	go

	/*	***************************************************************************************** 
		|						TRIGGERS (DISPARADORES) DE LA BASE DE DATOS						|
		*****************************************************************************************  */
	/* ================== TRIGGERS PARA LA TABLA CURSO ================== */
	/* Triggers para Actualizar Estado*/
	create trigger TActualizar
	on TCurso
	for update
	as
	if update(Estado)
		begin
				print('Actualización correcta del estado')
		end
	else
		begin
			raiserror('Actualización Incorrecta del estado',10, 1)
			rollback transaction
		end;
	go

	/*	***************************************************************************************** 
		|								VISTAS DE LA BASE DE DATOS								|
		*****************************************************************************************  */
	/* ================== VISTAS PARA LA TABLA CARGA ACADEMICA ================== */
	-- Modulos devuelven tablas 
	/* ---------------- Vistas para curso con Carga --------------- */
	CREATE VIEW viCursosConCargaAcademica
	AS
	select C.Codigo_CursoActivo, C.Nombre, C.Grupo, DescripcionHorario=C.Dias+':'+C.Hora,Docentes=D.Apellido_Paterno+' '+D.Apellido_Materno+' '+D.Nombres,CA.CodDocente, C.Año, C.Periodo
			from TCursoActivo C inner join TCargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
	go

	/* ----------------  Vista para Todos los cursos que no tienen carga academica(de todos los meses, grupos, etc*)(tipo no es clave primaria) --------------- */
	CREATE VIEW viCursoSinCargaAcademica
	AS
		select C.Codigo_CursoActivo, C.Grupo, C.Periodo, C.Año
			from TCursoActivo C
		except 
		select T.Codigo_CursoActivo, T.Grupo, T.Periodo, T.Año
			from viCursosConCargaAcademica T 
	go