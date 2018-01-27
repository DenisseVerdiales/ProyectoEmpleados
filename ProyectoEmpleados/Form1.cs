using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProyectoEmpleados
{
    public partial class Form1 : Form
    {
        BindingSource bs = new BindingSource();
        public Form1()
        {    
            InitializeComponent();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            Alta alta = new Alta();
            alta.FormClosed += new System.Windows.Forms.FormClosedEventHandler(recargarGrid);
            alta.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           llenarDataGrid();
            bs.DataSource = dgv_Empleados;
        }
       
        private void dgv_Empleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {  
           if(dgv_Empleados.Columns[e.ColumnIndex].Name == "btnModificar")
            {
                string ClaveEmp,Nombre, ApPaterno, ApMaterno, FechNacimiento, Departamento, Sueldo;
                
                ClaveEmp = dgv_Empleados.CurrentRow.Cells[0].Value.ToString();
                Nombre = dgv_Empleados.CurrentRow.Cells[1].Value.ToString();
                ApPaterno = dgv_Empleados.CurrentRow.Cells[2].Value.ToString();
                ApMaterno = dgv_Empleados.CurrentRow.Cells[3].Value.ToString();
                FechNacimiento = dgv_Empleados.CurrentRow.Cells[5].Value.ToString();
                Departamento = dgv_Empleados.CurrentRow.Cells[6].Value.ToString();
                Sueldo = dgv_Empleados.CurrentRow.Cells[7].Value.ToString();

                Alta actualiza = new Alta();
                // actualiza.Load(ClaveEmp, Nombre, ApPaterno, ApMaterno, FechNacimiento, Departamento, Sueldo);
                actualiza.txtClaveEmp.Text = ClaveEmp;
                actualiza.txtNombre.Text = Nombre;
                actualiza.txtApPat.Text = ApPaterno;
                actualiza.txtApMat.Text = ApMaterno;
                actualiza.dtpCalendario.Text = FechNacimiento;
                actualiza.cbDepartamento.Text = Departamento;
                actualiza.txtSueldo.Text = Sueldo;

                actualiza.FormClosed += new System.Windows.Forms.FormClosedEventHandler(recargarGrid);
                actualiza.ShowDialog();

            }
           else if (dgv_Empleados.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                if (MessageBox.Show("Estas seguro que deseas eliminar el registro?","INFORMACION",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                  
                        int iFila = dgv_Empleados.CurrentRow.Index; //obtengo la fila actual
                        string sClaveEmp = dgv_Empleados.CurrentRow.Cells[0].Value.ToString();

                        dgv_Empleados.Rows.RemoveAt(iFila);
                        Empleados emp = new Empleados();
                        emp.eliminarEmpleados(sClaveEmp);
                    
                   
                }
            }


        }
        public void eliminarRegistro()
        {

        }
        public void llenarDataGrid()
        {
            try
            {
               
                Conexion conecta = new Conexion();
                conecta.conecta();
                Conexion.conexion.Open();

                SqlDataAdapter data = new SqlDataAdapter("select Clave_Emp, Nombre , ApPaterno , ApMaterno, (Nombre+' '+ ApPaterno+' ' +ApMaterno) as Nombre_Completo ,FecNac as Fecha_Nacimiento,Descripcion,Sueldo from Empleados e, Departamentos d where e.Departamento = d.Puesto", Conexion.conexion);
                DataTable dt = new DataTable(); 
                data.Fill(dt); 
                dgv_Empleados.DataSource = dt; 
                dgv_Empleados.Columns[0].Visible = false; // ocultar columna del id
                dgv_Empleados.Columns[1].Visible = false;
                dgv_Empleados.Columns[2].Visible = false;
                dgv_Empleados.Columns[3].Visible = false;


                DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();  
                    btnModificar.HeaderText = "";
                    btnModificar.Text = "Modificar";
                    btnModificar.Name = "btnModificar";
                    btnModificar.UseColumnTextForButtonValue = true;
                    
                    dgv_Empleados.Columns.Add(btnModificar);

                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
               
                    btnEliminar.HeaderText = "";
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.Name = "btnEliminar";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    dgv_Empleados.Columns.Add(btnEliminar);
                
                   dgv_Empleados.CellClick += new DataGridViewCellEventHandler(dgv_Empleados_CellClick);
                
                Conexion.conexion.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }

        }
        private void recargarGrid(object sender, FormClosedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                dgv_Empleados.Columns.Remove(dgv_Empleados.Columns[0]);
            }
           
            Conexion conecta = new Conexion();
            conecta.conecta();
            Conexion.conexion.Open();

            SqlDataAdapter data = new SqlDataAdapter("select Clave_Emp, Nombre , ApPaterno , ApMaterno, (Nombre+' '+ ApPaterno+' ' +ApMaterno) as nombre,FecNac as FechaNacimiento,Descripcion,Sueldo from Empleados e, Departamentos d where e.Departamento = d.Puesto", Conexion.conexion);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgv_Empleados.DataSource = dt;
            dgv_Empleados.Columns[0].Visible = false; // ocultar columna del id
            dgv_Empleados.Columns[1].Visible = false;
            dgv_Empleados.Columns[2].Visible = false;
            dgv_Empleados.Columns[3].Visible = false;


            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            btnModificar.HeaderText = "";
            btnModificar.Text = "Modificar";
            btnModificar.Name = "btnModificar";
            btnModificar.UseColumnTextForButtonValue = true;

            dgv_Empleados.Columns.Add(btnModificar);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();

            btnEliminar.HeaderText = "";
            btnEliminar.Text = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgv_Empleados.Columns.Add(btnEliminar);    
        }
    }
}
