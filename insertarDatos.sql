create procedure insertarDatos
@Nombre varchar(50), @ApPaterno varchar(50), @ApMaterno varchar(50),
@FecNac Datetime, @Departamento int, @Sueldo money

as

begin tran

insert into Empleados(Nombre,ApPaterno,ApMaterno,FecNac,Departamento,Sueldo) values(@Nombre,@ApPaterno,@ApMaterno,@FecNac,@Departamento,@Sueldo)
if @@error <> 0
	begin 
		raiserror('Error al registrar al empleado',10,11)
		rollback tran
		return 1
	end

commit tran
return 0
