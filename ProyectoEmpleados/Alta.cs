using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoEmpleados
{
    public partial class Alta : Form
    {
        Validar validaDatos = new Validar(); //Instancia de la clase validar
        public Alta()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
            double dSueldo; 
            string nombre, apellidoPat, apellidoMat, departamento,sFechaNacimiento,sSueldo,sClaveEmp;
            DateTime fechaNac = dtpCalendario.Value.Date;
            departamento = cbDepartamento.Text;
            nombre = txtNombre.Text;
            apellidoPat = txtApPat.Text;
            apellidoMat = txtApMat.Text;
            bool bRespuesta = true;

            if (nombre == "")
            {
                MessageBox.Show("Debe agregar el nombre del empleado", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bRespuesta = false;
            }
            else if (apellidoPat == "")
            {
                MessageBox.Show("Debe agregar el apellido del empleado", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bRespuesta = false;
            }
            else if (txtApMat.Text == "")
            {
                MessageBox.Show("Debe agregar el apellido del empleado", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bRespuesta = false;
            }
            else if (departamento == "Seleccionar")
            {
                MessageBox.Show("Debe agregar elegir un departamento", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bRespuesta = false;
            }
            else if (txtSueldo.Text == "")
            {
                MessageBox.Show("Debe agregar el sueldo", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bRespuesta = false;
            }
            else if (fechaNac >= DateTime.Now.Date)
            {
                MessageBox.Show("Debes agregar una fecha de nacimiento valida", "CAMPO OBLIGATORIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bRespuesta = false;
            }

            if (bRespuesta)
            {
                dSueldo = Convert.ToDouble(txtSueldo.Text.ToString());
                if (txtClaveEmp.Text != "")
                {
                    sClaveEmp = txtClaveEmp.Text;
                    sFechaNacimiento = dtpCalendario.Text;
                    sSueldo = txtSueldo.Text;
                    Empleados actualizar = new Empleados();
                    actualizar.ActualizaDatos(sClaveEmp, nombre, apellidoPat, apellidoMat, sFechaNacimiento, departamento, sSueldo);
                  
                }
                else
                {    
                    Empleados InsertarDatos = new Empleados();
                    InsertarDatos.insertarDatos(nombre, apellidoPat, apellidoMat, fechaNac, departamento, dSueldo);
                    // Application.Restart();
                 
                }
                this.Close();

            }


        }

        private void Alta_Load(object sender, EventArgs e)
        {
            Conexion conecta = new Conexion();
            conecta.conecta();
            Conexion.conexion.Open();

            SqlDataAdapter dep = new SqlDataAdapter("select puesto, Descripcion from Departamentos", Conexion.conexion);
            DataTable dt = new DataTable();
            dep.Fill(dt);

            for(int i= 0; i < dt.Rows.Count;i++)
            {
                cbDepartamento.Items.Add(dt.Rows[i]["Descripcion"]);
            }


        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaDatos.SoloLetras(e);
        }

        private void txtApPat_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaDatos.SoloLetras(e);
        }

        private void txtApMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaDatos.SoloLetras(e);
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaDatos.SoloNumeros(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
     
    }
}
