create database Proyecto_Empleados

create table Departamentos
(
	Puesto int not null identity(1,1),
	Descripcion varchar(50) not null,
	primary key(Puesto)
);

create table empleados
(
	Clave_Emp int not null identity(1,1),
	Nombre varchar(50) not null,
	ApPaterno varchar(50) not null,
	ApMaterno varchar(50) not null,
	FecNac datetime not null,
	Departamento int not null,
	Sueldo money not null,
	primary key (Clave_Emp),
	foreign key(Departamento) references Departamentos(Puesto)
);

insert into Departamentos(Descripcion) values('Sistemas');
insert into Departamentos(Descripcion) values('Compras');
insert into empleados(Nombre,ApPaterno,ApMaterno,FecNac,Departamento,Sueldo) values('Denisse','Verdiales','Moreno','19920909',1,10000);
insert into empleados(Nombre,ApPaterno,ApMaterno,FecNac,Departamento,Sueldo) values('Paul','Ontivero','Marin','19920512',1,15000);
insert into empleados(Nombre,ApPaterno,ApMaterno,FecNac,Departamento,Sueldo) values('Ana','Martinez','Bueno','19920218',2,17000);

