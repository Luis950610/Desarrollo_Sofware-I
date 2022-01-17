/*  ***************************************************************************************** 
	|						DDL(LENGUAJE DE DEFINICION DE DATOS)							| 
	***************************************************************************************** */
	USE MASTER
	GO

/*  ***************************************************************************************** 
	|						CREACION DE LA BASE DE DATOS DEL SISTEMA						|
	*****************************************************************************************  */
	CREATE DATABASE BDMantenimiento2021_II
	GO


/*  ***************************************************************************************** 
	|						CREACION DE LAS TABLAS DEL SISTEMA								|
	*****************************************************************************************  */
	USE BDMantenimiento2021_II
	go
	-- Crear tipos de datos para las claves primarias
	EXEC  sp_addtype  TCod_Estudiante, 'varchar(6)','NOT NULL'  -- Grupo 01
	EXEC  sp_addtype  TCod_Docente, 'varchar(6)','NOT NULL'		-- Grupo 03
	EXEC  sp_addtype  TCod_Curso,	'varchar(8)', 'not null'    -- Grupo 02
	EXEC  sp_addtype  TCod_DetallePago,    'varchar(7)', 'not null' -- Grupo 04
	EXEC  sp_addtype  TCod_Pago,	'varchar(7)', 'not null'	-- Grupo 04
	EXEC  sp_addtype  TCodCursoActivo, 'varchar(5)','NOT NULL' -- Grupo 05
	EXEC  sp_addtype  TCodBoleta, 'varchar(12)','NOT NULL'		-- Grupo 05
	EXEC  sp_addtype  TCodMatricula, 'varchar(8)','NOT NULL'	-- Grupo 05
	GO


	/*  ***************************************************************************************** 
	|						                    TABLAS 
	*****************************************************************************************  */
	/*========================== TABLA ESTUDIANTE ==========================*/
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


	/*========================== TABLA DOCENTE ==========================*/
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



	/*========================== TABLA CURSO ==========================*/
	
	CREATE TABLE TCurso
	(
		-- Lista de atributos de la tabla Curso
		Codigo_Curso TCod_Curso,
		Nombre_Curso VARCHAR(50) NOT NULL,
		Tipo_Curso VARCHAR(5)	NOT NULL,
		Temas VARCHAR(50) NOT NULL,
		Grupo VARCHAR(10) not null,				  -- Añadido del Grupo04				
		Estado VARCHAR(11) DEFAULT 'DESACTIVADO', -- Añadido del Grupo04
		Horas INT,
		Horario VARCHAR(20) NOT NULL,
		-- Definicion de claves
		PRIMARY KEY (Codigo_Curso)
	)
	GO
	
	




	/*========================== TABLA ACTIVACION ==========================*/

	
	create table CursoActivo
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
		Codigo_Curso		TCod_Curso,
		Cod_DetallePago	TCod_DetallePago,
		-- Definicion de claves
		PRIMARY KEY	(Cod_Pago),
		FOREIGN KEY (Codigo_Estudiante) REFERENCES TEstudiante(Codigo_Estudiante),
		FOREIGN KEY (Codigo_Curso) REFERENCES TCurso(Codigo_Curso),
		FOREIGN KEY (Cod_DetallePago) REFERENCES Detalle_Pago(Cod_DetallePago)
	)
	GO
	


	-- ===================================================================================
	-- ===================================================================================
	-- ===================================================================================
	-- ===================================================================================

	/*========================== TABLA BOLETA ==========================*/
	create table Boleta
	( 
		-- Lista de atributos de la tala Boleta
		Codigo_Boleta  TCodBoleta NOT NULL,
		NroSerie	 VARCHAR(10) not null,
		FechaEmision VARCHAR(50) not null,
		Costo   NUMERIC(15,2) CHECK(Costo > 0) ,
		TipoDsto  VARCHAR(15) CHECK (TipoDsto in ('DCTO1','DCTO2','DCTO3','DCTO4','DCTO5')),
		Pago    NUMERIC(15,2) CHECK(Pago > 0),
		CodCursoActivo  VARCHAR(15) Not NULL,
		Codigo_Estudiante TCod_Estudiante,
		Observacion   VARCHAR(50) not null
		-- Definicion de claves
		PRIMARY KEY (Codigo_Boleta),
		FOREIGN KEY (Codigo_Estudiante) REFERENCES TEstudiante(Codigo_Estudiante)
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
		FOREIGN KEY (CodBoleta) REFERENCES Boleta(Codigo_Boleta),
		FOREIGN KEY (CodCursoActivo) REFERENCES CursoActivo(Codigo_CursoActivo)
	 )
	 GO
	 --DROP TABLE Matricula
	 
	/*========================== TABLA CARGA ACADEMICA ==========================*/
	CREATE TABLE CargaAcademica
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
		FOREIGN KEY(CodCursoActivo) REFERENCES CursoActivo,
		FOREIGN KEY(CodDocente)REFERENCES TDocentes
	)
	GO
	--DROP TABLE CargaAcademica
	/*========================== TABLA CONTROL ERRORES ==========================*/
	create table LogErrores
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

	/*	***************************************************************************************** 
	|				FUNCIONES Y PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS				|
	*****************************************************************************************  */
	--USE db_BDSistemaMantenimientosCCI
	--GO
	/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA ESTUDIANTE ================== */
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

	/* ---------------- Procedimiento para Buscar un Estudiante --------------- */
	CREATE PROCEDURE spbuscar_estudiante_codigo
		@codigobuscar VARCHAR(6)
	AS	
		SELECT * FROM TEstudiante
		WHERE Codigo_Estudiante like @codigobuscar + '%'
	GO

	/* ---------------- Procedimiento para Listar Estudiantes --------------- */
	CREATE PROCEDURE spmostrar_estudiante
	AS
		SELECT  TOP 100 * FROM TEstudiante
		ORDER BY Codigo_Estudiante ASC
	GO





		/*	***************************************************************************************** 
	|				FUNCIONES Y PROCEDIMIENTOS ALMACENADOS DE LA BASE DE DATOS				|
	*****************************************************************************************  */
	--USE db_BDSistemaMantenimientosCCI
	--GO
	/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA DOCENTES ================== */

	/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA DOCENTE ================== */
/* ---------------- Funcion para Generar Codigo del Estudiante ---------------*/

	CREATE FUNCTION GenerarCodDocente()
	RETURNS VARCHAR(6)
	AS
	BEGIN
			-- Declarar variables para generar codigo
			DECLARE @Codigo VARCHAR(6), @CodMax1 VARCHAR(6)
			SET @CodMax1 = (SELECT MAX(Codigo_Docente) FROM TDocentes)
			SET @CodMax1 = ISNULL(@CodMax1,'D00000')
			SET @Codigo = 'D'+RIGHT(RIGHT(@CodMax1,4)+10001,4)
			RETURN @Codigo
	END;
	GO
/* ---------------- Procedimiento para Listar Docentes --------------- */
	Create procedure ListarDocentes
	AS
		select *
			from TDocentes
	GO

	/* ---------------- Procedimiento para Insertar Docentes --------------- */
	   	 

	CREATE PROCEDURE AgregarDocente 
		@Codigo varchar(6), 
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
		INSERT INTO TDocentes
		VALUES (DBO.GenerarCodDocente(), @Nombre, @ApellidoP, @ApellidoM, @TipoDocentes, @Direccion, @Correo, @Celular, @Sexo, @foto)
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


--:::::::::::::::  :::::::::::::::::::::::::::
--:::::::::::::::                               :::::::::::::::::::::::::::
--:::::::::::::::                               :::::::::::::::::::::::::::
--::::::::::::::: PROCEDURE DE COMPEÑERO GUERRA :::::::::::::::::::::::::::


create procedure pRecuperarCursoCodigo @Cod_Curso varchar(6)
	as
	begin
		SELECT Codigo_Curso, COUNT(Codigo_Curso) as NroAlumno
		INTO #TEMP1
		FROM Pago
		GROUP BY Codigo_Curso

		SELECT C.Codigo_Curso, C.Nombre_Curso, C.Tipo_Curso,C.Grupo, C.Horario, C.Estado, C.Horas, C.Temas,T.NroAlumno
		FROM TCurso C inner join #TEMP1 T on C.Codigo_Curso = T.Codigo_Curso
		WHERE C.Codigo_Curso = @Cod_Curso
	end
	GO

	create procedure pRecuperarCursoNombre 
		@Nombre_Curso varchar(80), 
		@Grupo varchar(10)
	as
	begin
		SELECT Codigo_Curso, COUNT(Codigo_Curso) as NroAlumno
		INTO #TEMP1
		FROM Pago
		GROUP BY Codigo_Curso
		SELECT C.Codigo_Curso, C.Nombre_Curso, C.Tipo_Curso, C.Grupo, C.Horario, C.Estado, C.Horas, C.Temas, T.NroAlumno
		FROM TCurso C inner join #TEMP1 T on C.Codigo_Curso = T.Codigo_Curso
		WHERE C.Nombre_Curso = @Nombre_Curso and C.Grupo = @Grupo
	end
	GO

	create procedure pListaAlumnos @Cod_Curso varchar(6)
	as
	begin
		select P.Codigo_Curso, A.Codigo_Estudiante, A.Apellido_Paterno, A.Apellido_Materno, A.Nombres, A.DNI, A.Email
		from Pago P inner join TEstudiante A on P.Codigo_Estudiante = A.Codigo_Estudiante
		where Codigo_Curso = @Cod_Curso
	end;
	GO

	create procedure pActulizarEstado @Cod_Curso varchar(6), @Estado varchar(11)
	as
	begin
		BEGIN TRY
			update TCurso
			set Estado = @Estado
			where Codigo_Curso = @Cod_Curso
		END TRY
		BEGIN CATCH
			INSERT INTO LogErrores(ErrorNumbre,ErrorMessage,ErrorLine,ErrorProcedure,
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

	create procedure pListarCursos 
		@Estado varchar(11)
	as
	begin
		SELECT Codigo_Curso, COUNT(Codigo_Curso) as NroAlumno
		INTO #TEMP1
		FROM Pago
		GROUP BY Codigo_Curso

		SELECT C.Codigo_Curso, C.Nombre_Curso, C.Grupo, C.Horario, C.Estado, C.Horas, T.NroAlumno
		FROM TCurso C inner join #TEMP1 T on C.Codigo_Curso = T.Codigo_Curso
		WHERE C.Estado = @Estado
	end
	GO

	







--:::::::::::::PROCEDURE DE JERY ::::::::::::::::::::::::::



	create proc sp_listar_mCurso
	as
	select Codigo_Curso, Nombre_Curso, Tipo_Curso, Temas, Horas
	from TCurso
	order by Codigo_Curso
	go


-- Buscar curso por sus atributos: Codigo, Nombre, Tema y tipo
create proc sp_Buscar_mCurso
@Nombre varchar(50)
as
select Codigo_Curso, Nombre_Curso, Tipo_Curso, Temas, Horas
	from TCurso
	where (Codigo_Curso like @Nombre+'%')
		or (Nombre_Curso like @Nombre+'%')
		or (Temas like @Nombre+'%')
		or (Tipo_Curso like @Nombre+'%')
go



create proc sp_Mantenimiento_mCurso
@CodigoCurso varchar(8),
@Nombre varchar(50),
@Tipo varchar(5),
@Temas varchar(50),
@HorasxSemana int,
@accion varchar(50) output
as
--- GUARDAR DATOS
if(@accion='1')
begin try
--para probar
	declare @CodigoNuevo varchar(8),@CodigoMax varchar(8)
	set @CodigoMax=(select max(Codigo_Curso)from TCurso)
	set @CodigoMax=isnull(@CodigoMax,'IF000')
	set @CodigoNuevo='IF'+RIGHT(RIGHT(@CodigoMax,3)+11001,3)
	begin transaction
	insert into TCurso(Codigo_Curso,Nombre_Curso,Tipo_Curso,Temas,Grupo,Estado,Horas,Horario)
	values(@CodigoNuevo,@Nombre,@Tipo,@Temas,'','',@HorasxSemana,'')
	commit transaction
	set @accion='Se genero el codigo: '+@CodigoNuevo
end try

begin catch
--ejecutar si ocurre un error
PRINT'Error Number : '+CAST(ERROR_NUMBER()AS varchar(10));
PRINT'Error Message : '+ERROR_MESSAGE();
PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS varchar(10));
PRINT'Error State : '+CAST(ERROR_STATE()AS varchar(10));
PRINT'Error Line : '+CAST(ERROR_LINE()AS varchar(10));
PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
ROLLBACK TRANSACTION;

end catch
---- MODIFICAR CURSO
else if(@accion='2')
begin try
	begin transaction
	update TCurso set Nombre_Curso=@Nombre,Tipo_Curso=@Tipo,Temas=@Temas,Horas=@HorasxSemana where Codigo_Curso=@CodigoCurso
	commit transaction
	set @accion='Se modifico el codigo:' + @CodigoCurso
end try
begin catch
--ejecutar si ocurre un error
PRINT'Error Number : '+CAST(ERROR_NUMBER()AS varchar(10));
PRINT'Error Message : '+ERROR_MESSAGE();
PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS varchar(10));
PRINT'Error State : '+CAST(ERROR_STATE()AS varchar(10));
PRINT'Error Line : '+CAST(ERROR_LINE()AS varchar(10));
PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
ROLLBACK TRANSACTION;
end catch
else if(@accion='3')
begin try
	begin transaction
	delete from TCurso
	where Codigo_Curso=@CodigoCurso
	commit transaction
	set @accion='Se borro el codigo: '+@CodigoCurso
end try
begin catch
--ejecutar si ocurre un error
PRINT'Error Number : '+CAST(ERROR_NUMBER()AS varchar(10));
PRINT'Error Message : '+ERROR_MESSAGE();
PRINT'Error Severity : '+CAST(ERROR_SEVERITY()AS varchar(10));
PRINT'Error State : '+CAST(ERROR_STATE()AS varchar(10));
PRINT'Error Line : '+CAST(ERROR_LINE()AS varchar(10));
PRINT'Error Proc: '+COALESCE(ERROR_PROCEDURE(),'Not within procedure')
ROLLBACK TRANSACTION;
end catch
go

---:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
---:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
---:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
/* ================== PROCEDIMIENTOS ALMACENADOS PARA LA TABLA CURSOS ACTIVOS ================== */
	/* ---------------- Procedimiento para Seleccion de Curso --------------- */
	create procedure SP_SeleccionCursos
	as
		select * from CursoActivo
	go

	/* ---------------- Procedimiento para Seleccion de Curso por Categorias --------------- */
	create procedure SP_SeleccionCursosxCategorias
		@Tipo varchar(3),
		@Periodo varchar(11),
		@Año varchar(4)
	as
		select*from CursoActivo where Tipo=@Tipo and Periodo=@Periodo and Año=@Año
	go

	/* ---------------- Procedimiento para Buscar los cursos activos por todos los campos --------------- */
	create procedure SP_BuscarCursosxTodosLosCampos
		@cadena varchar(50)
	as
		select*
		from CursoActivo
		where Codigo_CursoActivo like @cadena+'%' or Grupo like @cadena+'%'
		or Nombre like @cadena+'%' or Tema like @cadena+'%' or Grupo like @cadena+'%'
	go

	/* ---------------- Procedimiento para Buscar Cursos sin Carga Todos los campos --------------- */
	create procedure SP_BuscarCursosSinCargaxTodosLosCamposxCategorias
		@Tipo varchar(3),
		@Periodo varchar(11),
		@Año varchar(4),
		@cadena varchar(60)
	as
		select C.Codigo_CursoActivo,C.Grupo,Nombre,Tema,Tipo,HorasxSemana,DescripcionHorario=C.Dias+':'+C.Hora,C.Periodo,C.Año
			from viCursoSinCargaAcademica V inner join CursoActivo C
			on V.Codigo_CursoActivo=C.Codigo_CursoActivo and C.Grupo=C.Grupo and V.Periodo=C.Periodo and C.Año=V.Año
			where (C.Codigo_CursoActivo like @cadena+'%' or C.Grupo like @cadena+'%'
				or Nombre like @cadena+'%' or Tema like @cadena+'%')and Tipo=@Tipo and C.Periodo=@Periodo and C.Año=@Año

	go

	/* ---------------- Procedimiento para Seleccionar todos los Docentes --------------- */
	create procedure SP_SeleccionDocentes
	as
		select*
		from TDocentes
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
			from CargaAcademica CA inner join CursoActivo C 
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
			from CargaAcademica CA inner join CursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente
			where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	go

	/* ---Procedimiento para Mostrar todos los docentes(DISPONIBLES y NO DISPONIBLES)para una hora, dia, periodo y año determinado ---*/
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
			from CargaAcademica CA inner join CursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.Codigo_Docente=D.Codigo_Docente)RESULTADO 

	UNION
	select T.CodDocente, Docentes_Disponibles=Apellido_Paterno+' '+Apellido_Materno+' '+Nombres,Estado='CON CARGA'
		from(select CodDocente
			from CargaAcademica CA inner join CursoActivo C 
			on CA.CodCursoActivo=C.Codigo_CursoActivo and CA.Grupo=C.Grupo and CA.Periodo=C.Periodo and CA.Año=C.Año
			where CA.Periodo=@Periodo and C.Año=@Año and Hora=@Hora and Dias=@Dias)T inner join TDocentes D
			on T.CodDocente=D.Codigo_Docente
	where Nombres like '%'+@cadena+'%' or Apellido_Paterno like '%'+@cadena+'%' or Apellido_Materno like '%'+@cadena+'%'
	order by Codigo_Docente asc
	go

	/* ---------------- Procedimiento para Carga Academica --------------- */
	create procedure SP_SeleccionCargaAcademica
	as
		select*from CargaAcademica
	go

	/* ---------------- Procedimiento para Seleccion de Carga Academica por Categoria --------------- */
	create procedure SP_SeleccionCargaAcademicaxCategorias
	@Tipo varchar(3),
	@Periodo varchar(11),
	@Año varchar(4)
	as
		select C.Codigo_CursoActivo, C.Nombre, C.Grupo, Descripcion=C.Dias+':'+C.Hora,Docentes=D.Apellido_Paterno+' '+D.Apellido_Materno+' '+D.Nombres,CA.CodDocente
			from CursoActivo C inner join CargaAcademica CA
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
			from CursoActivo C inner join CargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
			where (C.Codigo_CursoActivo like '%'+@cadena+'%' or C.Nombre like '%'+@cadena+'%'or D.Apellido_Paterno like '%'+@cadena+'%' or D.Nombres like '%'+@cadena+'%' or CA.CodDocente like '%'+@cadena+'%')
			and Tipo=@Tipo and CA.Periodo=@Periodo and CA.Año=@Año
	go

	/*---------------- Procedimiento para Agregar una carga academica ---------------- */
	create procedure SP_AgregarCargaAcademica
		@CodCurso varchar(5),
		@Grupo varchar(1),
		@CodDocente varchar(6),
		@Periodo varchar(11),
		@Año varchar(4)
	as
		insert into CargaAcademica values (@CodCurso,@Grupo,@CodDocente,@Periodo,@Año)

	go

	/*---------------- Procedimiento para Eliminar una carga academica ---------------- */
	create procedure SP_EliminarCargaAcademica
		@CodCargaAcademica int
	as
		delete from CargaAcademica where CodCargAcademica=@CodCargaAcademica
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
		update CargaAcademica 
			set CodDocente=@CodDocente
			where CodCargAcademica=@CodCargaAcademica;

	go



---:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
---:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
	/* ---------------- Procedimiento para Mantenimiento de Estudiante Matriculado --------------- */
	-- Comprobación por el visual
	CREATE PROCEDURE SP_Mantenimiento_EstudianteMatriculado
		@CodEstudiante varchar(12),
		@Nombre varchar(40),
		@AppPaterno varchar(40),
		@AppMaterno varchar(40),
		@DNI varchar(8),
		@Email varchar(50),
		@accion varchar(50) output
	AS
	BEGIN
		IF(@accion='1')
			BEGIN TRY
				begin tran
				insert into TEstudiante(Codigo_Estudiante,Nombres,Apellido_Paterno,Apellido_Materno,DNI,Email)
				values(@CodEstudiante,@Nombre,@AppPaterno,@AppMaterno,@DNI,@Email)
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
				update TEstudiante set Nombres=@Nombre,Apellido_Paterno=@AppPaterno,Apellido_Materno=@AppMaterno,DNI=@DNI,Email=@Email where Codigo_Estudiante=@CodEstudiante
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
			INSERT INTO Boleta values (@NroBoleta,@NroSerie,@FechaEmision,@Costo,@TipoDcto,@Pago,@CodCurso,@CodEstudiante,@Observacion)
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
				insert into Boleta(Codigo_Boleta,NroSerie,FechaEmision,Costo,TipoDsto,Pago,CodCursoActivo,Codigo_Estudiante,Observacion)
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
				update Boleta set Codigo_Boleta = @CodBoleta,NroSerie = @NroSerie, FechaEmision=@FechaEmision,Costo = @Costo,TipoDsto = @TipoDsto,
				Pago = @Pago,CodCursoActivo = @CodCursoActivo,Codigo_Estudiante = @CodEstudiante,Observacion = @Observacion
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
				DELETE FROM  Boleta
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
		SELECT DISTINCT TipoDsto FROM Boleta
		commit tran
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE()
		ROLLBACK TRAN
	END CATCH
	END;
	GO

	---------------------------------------------------------------------------------
--PROCEDIMIENTO ALMACENADO PARA BUSCAR ESTUDIANTE MATRICULADO 
-------------------------------------------------------------------------------
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

--================ PROCEDIMIENTO ALMACENADO PARA "CURSO ACTIVO"===================================\
CREATE PROCEDURE SP_Mostrar_CursoActivo
AS
BEGIN 
BEGIN TRY 
	begin tran
	SELECT Codigo_CursoActivo,Nombre,CONCAT(Codigo_CursoActivo,' - ',Nombre) as Codigo FROM CursoActivo
	commit tran
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE()
	ROLLBACK TRAN
END CATCH
END;
GO

---::::::::::::::::::::::::::::::::GRUPO 5 MANTENIMIENTO MATRICULA:::::::::::::::::::::::::::::::::::::::::::
---:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


CREATE PROCEDURE SP_DetalleMatriculaEstudiante
AS
BEGIN
	BEGIN TRY
	    begin tran
		SELECT /*C.CodCursoActivo,C.Nombre,*/E.Codigo_Estudiante,E.Nombres,E.Apellido_Paterno,E.Apellido_Materno,E.DNI,E.Email,
			B.NroSerie, B.Codigo_Boleta,B.Pago,B.TipoDsto,B.Costo,B.Observacion/*, (C.Dias + ' : ' + C.Hora) as Horario*/
			FROM TEstudiante E inner join Boleta B
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
	

	/* ---------------- Procedimiento para Listar Estudiante Matriculado --------------- */
	

	/* ---------------- Procedimiento para Agregar Boleta Estudiante --------------- */
	

	/* ---------------- Procedimiento para Mantenimiento Boleta Estudiante --------------- */
	-- Comprobacion por el visual
	

	/* ---------------- Procedimiento para Descuento Matricula Estudiante --------------- */
	

--================ PROCEDIMIENTO ALMACENADO PARA "CURSO ACTIVO"===================================\

--drop procedure SP_Mostrar_CursoActivo
exec SP_Mostrar_CursoActivo











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
			from CursoActivo C inner join CargaAcademica CA
				on (C.Codigo_CursoActivo=CA.CodCursoActivo and C.Grupo=CA.Grupo and C.Periodo=CA.Periodo and C.Año=CA.Año)
				inner join TDocentes D on(CA.CodDocente=D.Codigo_Docente)
	go

	/* ----------------  Vista para Todos los cursos que no tienen carga academica(de todos los meses, grupos, etc*)(tipo no es clave primaria) --------------- */
	CREATE VIEW viCursoSinCargaAcademica
	AS
		select C.Codigo_CursoActivo, C.Grupo, C.Periodo, C.Año
			from CursoActivo C
		except 
		select T.Codigo_CursoActivo, T.Grupo, T.Periodo, T.Año
			from viCursosConCargaAcademica T 
	go
-----------------------------------------------------------------------------------
--PROCEDIMIENTO ALMACENADO PARA MANTENIMIENTO DE ESTUDIANTE MATRICULADO
--------------------------------------------------------------------------------------
