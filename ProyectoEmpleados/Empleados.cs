using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoEmpleados
{
    class Empleados
    {
        string sNombre, sApPaterno, sApMaterno;
        DateTime dFechNacimiento;
        int iDepartamento;
        Double dSueldo;
         
        public string snombre
        {
            set { sNombre = value; }
            get { return sNombre; }
        }
        public string apPaterno
        {
            set { sApPaterno = value; }
            get { return sApPaterno; }
        }
        public string apMaterno
        {
            set { sApMaterno = value; }
            get { return sApMaterno; }
        }
        public DateTime fechaNac
        {                                
            set { dFechNacimiento = value; }
            get { return dFechNacimiento; }
        }
        public int departamento
        {
            set { iDepartamento = value; }
            get { return iDepartamento; }
        }
        public double sueldo
        {
            set { dSueldo = value; }
            get { return dSueldo; }
        }

        public void eliminarEmpleados(string claveEmpleado)
        {
            try
            {
                int iClaveEmpleado = Int32.Parse(claveEmpleado);

                Conexion conecta = new Conexion();
                conecta.conecta();
                Conexion.conexion.Open();

                SqlCommand cmd = new SqlCommand("eliminaDatos", Conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Clave_Emp", iClaveEmpleado);

                cmd.ExecuteNonQuery();

                Conexion.conexion.Close();
                MessageBox.Show("Empleado eliminado con exito", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }


        }
        public void ActualizaDatos(string ClaveEmp, string Nombre, string ApPaterno, string ApMaterno, string FechNacimiento, string Departamento, string Sueldo)
        {
            try
            {
                DateTime dtFechaNac; 
                int iDepartamento, iClaveEmp;
                double dSueldo = double.Parse(Sueldo);
                string sDepto;

                dtFechaNac = DateTime.Parse(FechNacimiento);
                iClaveEmp = Int32.Parse(ClaveEmp);

                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand();
                data.SelectCommand.CommandText = "select Puesto from Departamentos where Descripcion like '%%" + Departamento + "%%'";
                data.SelectCommand.CommandType = CommandType.Text;
                data.SelectCommand.Connection = Conexion.conexion;
                DataTable dt = new DataTable();
                data.Fill(dt);
                sDepto = dt.Rows[0]["Puesto"].ToString();
                iDepartamento = Int32.Parse(sDepto);


                Conexion conecta = new Conexion();
                conecta.conecta();
                Conexion.conexion.Open();

                SqlCommand cmd = new SqlCommand("actualizaDatos", Conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Clave_Emp", iClaveEmp);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", ApMaterno);
                cmd.Parameters.AddWithValue("@FecNac", dtFechaNac);
                cmd.Parameters.AddWithValue("@Departamento", iDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", dSueldo);


                cmd.ExecuteNonQuery();

                Conexion.conexion.Close();
                MessageBox.Show("Empleado actualizado con exito", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
            


        }
        public void insertarDatos(string nombre, string apellidoPat, string apellidoMat, DateTime fechaNac, string departamento, double sueldo)
        {
             try
            {
                int iDep = 0;
                string depto;
                Conexion conecta = new Conexion();
                conecta.conecta();
                Conexion.conexion.Open();


                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand();
                data.SelectCommand.CommandText = "select Puesto from Departamentos where Descripcion like '%%"+ departamento + "%%'";
                data.SelectCommand.CommandType = CommandType.Text;
                data.SelectCommand.Connection = Conexion.conexion;
                DataTable dt = new DataTable();
                data.Fill(dt);
                depto = dt.Rows[0]["Puesto"].ToString();
                iDep = Int32.Parse(depto);


                SqlCommand cmd = new SqlCommand("insertarDatos", Conexion.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", apellidoPat);
                cmd.Parameters.AddWithValue("@ApMaterno", apellidoMat);
                cmd.Parameters.AddWithValue("@FecNac", fechaNac);
                cmd.Parameters.AddWithValue("@Departamento", iDep);
                cmd.Parameters.AddWithValue("@Sueldo", sueldo);

                cmd.ExecuteNonQuery();

                Conexion.conexion.Close();
                MessageBox.Show("Registro con exito", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
