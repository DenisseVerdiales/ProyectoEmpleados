using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoEmpleados
{
    class Conexion
    {
        public static SqlConnection conexion;

        public void conecta()
        {
            String sIp = "ProyectoEmpleados.mssql.somee.com", sBD= "ProyectoEmpleados",sUser= "Denisse_SQLLogin_1", sPsw= "2jnujm9gyk";
            //conexion = new SqlConnection("Data Source=DENISSE-PC\\SQLEXPRESS;Initial Catalog=Proyecto_Empleados;Integrated Security=True");

            //  String sCadena = String.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={2}",sIp,sBD,sUser,sPsw);
            String sCadena = String.Format(@"workstation id={0};packet size=4096;user id={1};pwd={2};data source={3};persist security info=False;initial catalog={4}",sIp,sUser,sPsw,sIp,sBD);
            conexion = new SqlConnection(sCadena);
        }
    }
}
