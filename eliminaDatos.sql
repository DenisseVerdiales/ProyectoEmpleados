create procedure eliminaDatos
@Clave_Emp int

as

begin tran

if not exists(select Clave_Emp from Empleados where Clave_Emp = @Clave_Emp)
	begin
		raiserror('El empleado no existe',10,11)
		return 1
	end

delete from Empleados where Clave_Emp = @Clave_Emp;
if @@error <> 0
	begin 
		raiserror('Error al eliminar',10,11)
		rollback tran
		return 1
	end
	
commit tran
return 0
