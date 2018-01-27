using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //eventos seleccionados por teclado

namespace ProyectoEmpleados
{
    class Validar
    {
        public void SoloLetras(KeyPressEventArgs e)
        {
            try
            {
                if(Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false; // para que permita solo letras
                }
                else if(Char.IsControl(e.KeyChar)) //si presiona la tecla de borrado
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar)) //si presiona la tecla de espacio
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true; //si no es ninguna de las teclas anteriores, no haga nada
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void SoloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false; // para que permita solo numeros
                }
                else if (Char.IsControl(e.KeyChar)) //si presiona la tecla de borrado
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar)) //si presiona la tecla de espacio
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true; // si no es ninguna de las teclas anteriores, no haga nada
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
