using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto01_paginas.Droid.Resources.clases;

namespace Proyecto01_paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina7 : ContentPage
    {
        ClaseConexion objeto = new ClaseConexion();
        public Pagina7()
        {
            InitializeComponent();

            Application.Current.PageAppearing += Current_PageAppearing;

            btnEnviar.Clicked += BtnEnviar_Clicked;

        }

        private void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            //--------Insertar cliente

            try { 
            String nombre = txtNombre.Text;
            String apellidos = txtApellidos.Text;
            String correo = txtCorreo.Text;
            String telefono = txtTelefono.Text;

           

            String sexo = "";
            if (cboSexo.SelectedItem != null)
            {
               sexo = cboSexo.SelectedItem.ToString();
               sexo = sexo.Substring(0, 1);
             }

            String fecha = "";
             if (dpFecha.Date != null)
             {
                fecha = dpFecha.Date.ToString("yyyy/MM/dd");
             }

            bool validacion =  Validacion(nombre, apellidos, cboSexo, dpFecha, correo, telefono);


             if (validacion) { 


                String cadenaSql = "insert into cliente(nombre,apellido,sexo,fechanac,correo,telefono) " +
                                 "values('" + nombre + "','" + apellidos + "','" + sexo + "','" + fecha + "','" + correo + "','" + telefono + "')";

                Console.WriteLine(cadenaSql);
                objeto.ejecutar(cadenaSql);

                //--------Insertar usuario
                String usuario = nombre.Substring(0, 1) + apellidos;
                cadenaSql = "insert into usuario(idrol,nombre) " +
                           "values(" + 2 + ",'" + usuario + "')";
                Console.WriteLine(cadenaSql);
                objeto.ejecutar(cadenaSql);

                //------Insertar venta
                String consulta = "select * from cliente " +
                                "where nombre='" + nombre + "' and apellido='" + apellidos + "' and correo='" + correo + "'";

                objeto.consultardatos(consulta);

                int idcliente = int.Parse(objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString());

                consulta = "select * from usuario " +
                         "where nombre='" + usuario + "'";

                objeto.consultardatos(consulta);

                int idusuario = int.Parse(objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString());

                consulta = "select CURRENT_TIMESTAMP";
                objeto.consultardatos(consulta);

                String fechaVenta = objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString();

                int cantidad = ClaseVariables.cantidad;
                double importe = ClaseVariables.precio * cantidad;
                double subtotal = importe;
                double igv = subtotal * 0.18;
                double total = subtotal + igv;

                cadenaSql = "insert into venta(idcliente,idusuario,fecha_venta,subtotal,igv,total,estado) " +
                           "values(" + idcliente + "," + idusuario + "," +
                           "'" + fechaVenta + "'," + subtotal + "," + igv + "," + total + ",1)";
                Console.WriteLine(cadenaSql);
                objeto.ejecutar(cadenaSql);


                //-----------------Insertar Detalle-------------
                consulta = "select * from venta " +
                         "where idcliente=" + idcliente + " and idusuario=" + idusuario + "";

                objeto.consultardatos(consulta);

                int idventa = int.Parse(objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString());

                cadenaSql = "insert into detalle_venta(idventa,idproducto,cantidad,importe) " +
                          "values(" + idventa + "," + ClaseVariables.codigoProducto + "," + cantidad + "," + importe + ")";

                Console.WriteLine(cadenaSql);
                objeto.ejecutar(cadenaSql);

                cadenaSql = "update producto " +
                          "set stock=stock - " + cantidad + " where idproducto=" + ClaseVariables.codigoProducto + "";
                Console.WriteLine(cadenaSql);
                objeto.ejecutar(cadenaSql);

                btnEnviar.Text = "Venta OK";
                } 

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Pagina7 BotonEnviar", "this is an error message" + ex);
                DisplayAlert("Exception", ex.Message, "ok");
            }
        }

        private void Current_PageAppearing(object sender, Page e)
        {
            String cadena = ClaseVariables.nombreproducto + "Cant:" +
                            ClaseVariables.cantidad;
            edProducto.Text = cadena;

            objeto.conectar();
        }


        private bool Validacion(String nombre, String apellidos, Picker sexo, DatePicker fecha, String correo, String telefono)
        {

            if (nombre == null || nombre.Length <= 0)
            {
                DisplayAlert("Error", "Campo NOMBRE debe estar lleno", "ok");
                System.Console.WriteLine("Error", "Campo NOMBRE debe estar lleno");
                return false;
            } else if (apellidos == null || apellidos.Length <= 0)
            {
                DisplayAlert("Error", "Campo APELLIDOS debe estar lleno", "ok");
                System.Console.WriteLine("Error", "Campo APELLIDOS debe estar lleno");
                return false;
            } else if (correo == null || correo.Length <= 0)
            {
                DisplayAlert("Error", "Campo CORRREO debe estar lleno", "ok");
                System.Console.WriteLine("Error", "Campo CORRREO debe estar lleno");
                return false;
            }
            else if (telefono == null || telefono.Length <= 0)
            {
                DisplayAlert("Error", "Campo TELEFONO debe estar lleno", "ok");
                System.Console.WriteLine("Error", "Campo TELEFONO debe estar lleno");
                return false;

            } else if (sexo == null || sexo.SelectedItem.ToString().Length <= 0)
            {
                DisplayAlert("Error", "Campo SEXO debe estar lleno", "ok");
                System.Console.WriteLine("Error", "Campo SEXO debe estar lleno");
                return false;
            }
            else if (fecha == null || fecha.Date.ToString().Length <= 0)
            {
                DisplayAlert("Error", "Campo FECHA debe estar lleno", "ok");
                System.Console.WriteLine("Error", "Campo FECHA debe estar lleno");
                return false;
            }

            return true;
        }
    }
}