	
	USE BDMantenimiento2021
	go
	
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
