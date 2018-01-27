create procedure actualizaDatos
@Clave_Emp int, @Nombre varchar(50), @ApPaterno varchar(50), @ApMaterno varchar(50),
@FecNac Datetime, @Departamento varchar(50), @Sueldo money

as

begin tran

if not exists(select Clave_Emp from Empleados where Clave_Emp = @Clave_Emp)
	begin
		raiserror('El empleado no existe',10,11)
		return 1
	end
update Empleados set Nombre = @Nombre, ApPaterno = @ApPaterno, ApMaterno = @ApMaterno, FecNac = @FecNac,
Departamento = @Departamento, Sueldo = @Sueldo where Clave_Emp = @Clave_Emp;
if @@error <> 0
	begin 
		raiserror('Error al actualizar el empleado',10,11)
		rollback tran
		return 1
	end

commit tran
return 0

