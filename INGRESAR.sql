USE BDMantenimiento2021
go

--ESTUDIANTES
--ESTUDIANTES
insert into TEstudiante values ('173622','VICTOR','QUISPE','DIAZ','76513532','M','los alpes','963094628','17362@unsaac,edu.pe','')
insert into TEstudiante values ('173672','ALVARO','MENDOZA',' ESCALANTE ','77674232','','','','173672@unsaac,edu.pe','')
insert into TEstudiante values ('173652','FARFAN','LOPEZ ','GUTIERREZ','76574276','','','','173652@unsaac,edu.pe','')
insert into TEstudiante values ('163632','DELIANA','HURTADO','LAPADULA','76574652','','','','163632@unsaac,edu.pe','')
insert into TEstudiante values ('176632','ANTONIO','CASTRO','OLARTE','76293232','','','','176632@unsaac,edu.pe','')
insert into TEstudiante values ('184643','VICTOR','QUISPE','OCHOA','76513532','','','','17362@unsaac,edu.pe','')
insert into TEstudiante values ('184644','ALVARO','CARO',' ESCALANTE ','77674232','','','','173672@unsaac,edu.pe','')
insert into TEstudiante values ('184645','CONSTANZA','LOPEZ ','GUZMAN','76574276','','','','173652@unsaac,edu.pe','')
insert into TEstudiante values ('184646','DELIANA','HURTADO','CARRASCO','76574652','','','','163632@unsaac,edu.pe','')
insert into TEstudiante values ('184647','ANTONIO','CCENTE','OLARTE','76293232','','','','176632@unsaac,edu.pe','')
insert into TEstudiante values ('184648','DIEGO','KU','CARRASCO','76574652','','','','163632@unsaac,edu.pe','')
insert into TEstudiante values ('184649','JUAN','PAZ','OLARTE','76293232','','','','176632@unsaac,edu.pe','')

--BOLETA
insert into Boleta values ('0001','1111','',120.00,'DCTO2',120.00,'C001','173622','cancelado')
insert into Boleta values ('0002','1111','',120.00,'DCTO2',120.00,'C001','173672','cancelado')
insert into Boleta values ('0003','1111','',120.00,'DCTO2',120.00,'C001','173652','cancelado')
insert into Boleta values ('0004','1111','',120.00,'DCTO2',120.00,'C002','163632','cancelado')
insert into Boleta values ('0005','1111','',120.00,'DCTO2',120.00,'C002','176632','cancelado')
insert into Boleta values ('0006','1111','',120.00,'DCTO2',120.00,'C001','173622','cancelado')
insert into Boleta values ('0007','1111','',120.00,'DCTO2',120.00,'C001','173672','cancelado')
insert into Boleta values ('0008','1111','',120.00,'DCTO2',120.00,'C001','173652','cancelado')
insert into Boleta values ('0009','1111','',120.00,'DCTO2',120.00,'C002','163632','cancelado')
insert into Boleta values ('0010','1111','',120.00,'DCTO2',120.00,'C002','176632','184647')
insert into Boleta values ('0011','1111','',120.00,'DCTO2',120.00,'C002','163632','184648')
insert into Boleta values ('0012','1111','',120.00,'DCTO2',120.00,'C002','176632','184649')


/*========================== TABLA ESTUDIANTE ==========================*/
INSERT INTO TEstudiante values ('00024','Montesinos','Velazco','Gustavo','76336287','M','Nogales C-15','983146088','00024@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00025','Gutierrez','Peña','Rodrigo','74568392','M','San Jeronimo D-2','976889784','00025@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00026','Fernandez','Mora','Fabricio','27630945','M','Almudena F-5','988786543','00026@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00027','Tello','Rodriguez','Andrew Russell','67255598','M','Manzanares V-3','946088611','00027@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00028','Morocho','Molina','Benjamin','66398122','M','Av. El Sol 345','931746088','00028@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00029','Villafuerte','Mendoza','Leonel','71127037','M','Sta. Ursula B-2','955897877','00029@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00030','Calderon','Covarrubias','Marcelo','89341856','M','Nogales K-9','900784456','00030@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00031','Vela','Mejia','Benjamin Alan','22984567','M','Marcavalle 128','966344475','00031@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00032','Vizacarra','Gonzales','Fabricio','88734295','M','Av. Garcilaso G-4','990876522','00032@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00033','Patiño','Guzman','Gabriela','43287765','F','Larapa K-2','900787565','00033@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00034','Montañez','Molina','kenneth','36788975','M','Huancaro B-10','900667431','00034@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00035','Malpartida','Cuba','Anggela','47665539','F','Los Angeles L-3','927890061','00035@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00036','Gastañaga','Davila','Laura','82342111','F','Villa R-23','974713499','00036@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00037','Mozo','Merma','Valeria','77553489','F','San Mateo S-7','984602851','00037@unsaac.edu.pe','null')
INSERT INTO TEstudiante values ('00038','Villasante','Fernandez','Jhossep','44387900','M','Av. La Cultura 345','927880087','00038@unsaac.edu.pe','null')

/*========================== TABLA CURSO ==========================*/

INSERT INTO TCurso Values ('10100','OFIMATICA I','CCI','WINDOWS 8-WORD 2010','B','DESACTIVADO', 7.5, '15-17')
INSERT INTO TCurso Values ('10101','OFIMATICA II','ACT','EXCEL 2013','A','DESACTIVADO', 1.5, '19-21')
INSERT INTO TCurso Values ('10102','OFFICE INTENSIVO','CCI','60.61.62','A','DESACTIVADO',2, '07-22')
INSERT INTO TCurso Values ('10103','OFFICE INTENSIVO','CCI','60.61.62','B','DESACTIVADO', 2, '07-22')
INSERT INTO TCurso Values ('10104','AUTOCAD 2D','CCI','DIBUJO Y EDICION BLOQUES','A','DESACTIVADO', 10, '15-17')
INSERT INTO TCurso Values ('10105','AUTOCAD 2D','CCI','DIBUJO Y EDICION BLOQUES','B','DESACTIVADO', 10, '17-19')
INSERT INTO TCurso Values ('10107','AUTOCAD 3D','CCI','MODELAMIENTO 3D','A','DESACTIVADO', 10, '15-17')
INSERT INTO TCurso Values ('10108','AUTOCAD 3D','CCI','MODELAMIENTO 3D','B','DESACTIVADO', 10, '17-19')
INSERT INTO TCurso Values ('10109','ARCGIS I','CCI','CARTOGRAFIA','A','DESACTIVADO',10, '09-11')
INSERT INTO TCurso Values ('10110','ARCGIS I','CCI','CARTOGRAFIA','B','DESACTIVADO', 10, '17-19')
INSERT INTO TCurso Values ('10111','ARCGIS I','CCI','CARTOGRAFIA','C','DESACTIVADO', 10, '17-19')
INSERT INTO TCurso Values ('10112','ARCGIS II','CCI','PROYECCION RASTER','A','DESACTIVADO', 10, '17-19')
INSERT INTO TCurso Values ('10113','ARCGIS II','CCI','PROYECCION RASTER','B','DESACTIVADO', 10, '19-21')
INSERT INTO TCurso Values ('10114','OFIMATICA I','ACT','WINDOWS 8 Y WORD 2010','A','DESACTIVADO', 1.5, '07-09')

/*************************************************************************************
								Datos de Detalle_Pago
**************************************************************************************/
--Curso 01 ofimatica I A
insert into Detalle_Pago Values('DP001',250.0,'Caja Cusco','Sin Observaciones')
insert into Detalle_Pago Values('DP002',250.0,'VISA','Sin Observaciones')
insert into Detalle_Pago Values('DP003',250.0,'Caja Cusco','Sin Observaciones')
insert into Detalle_Pago Values('DP004',250.0,'VISA','Sin Observaciones')
insert into Detalle_Pago Values('DP005',250.0,'PaytoPeru','Sin Observaciones')
insert into Detalle_Pago Values('DP006',250.0,'Caja Cusco','Sin Observaciones')
insert into Detalle_Pago Values('DP007',250.0,'PaytoPeru','Sin Observaciones')
insert into Detalle_Pago Values('DP008',250.0,'Caja Cusco','Sin Observaciones')
insert into Detalle_Pago Values('DP009',250.0,'VISA','Sin Observaciones')
insert into Detalle_Pago Values('DP010',250.0,'VISA','Sin Observaciones')
insert into Detalle_Pago Values('DP011',250.0,'PaytoPeru','Sin Observaciones')
--Curso 02: Ofimatica II A
insert into Detalle_Pago Values('DP012',300.0,'Caja Cusco','Sin Observaciones')
insert into Detalle_Pago Values('DP013',300.0,'Caja Cusco','Sin Observaciones')
insert into Detalle_Pago Values('DP014',300.0,'Caja Cusco','Sin Observaciones')

/***************************************************************************************
								PAGO
****************************************************************************************/
--Curso1: Ofimatica I A
insert into Pago Values('P001','00024','10100','DP001')
insert into Pago Values('P002','00025','10100','DP002')
insert into Pago Values('P003','00026','10100','DP003')
insert into Pago Values('P004','00027','10100','DP004')
insert into Pago Values('P005','00028','10100','DP005')
insert into Pago Values('P006','00029','10100','DP006')
insert into Pago Values('P007','00030','10100','DP007')
insert into Pago Values('P008','00031','10100','DP008')
insert into Pago Values('P009','00032','10100','DP009')
insert into Pago Values('P010','00033','10100','DP010')
insert into Pago Values('P011','00034','10100','DP011')
--Curso 02: Ofimatica II A
insert into Pago Values('P012','00036','10101','DP012')
insert into Pago Values('P013','00037','10101','DP013')
insert into Pago Values('P014','00038','10101','DP014')