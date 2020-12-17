using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//----------Llamar a la libreria-------------
using Proyecto01_paginas.Droid.Resources.clases;
//-------------------------------------------

namespace Proyecto01_paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

   
    public partial class Pagina1 : ContentPage
    {
        

        public Pagina1()
        {
            InitializeComponent();

            imgLenovo.Clicked += ImgLenovo_Clicked;

            //Ocultar
            lblCantidad.IsVisible = false;
            txtCantidad.IsVisible = false;

            btnComprar.Clicked += BtnComprar_Clicked;


        }

        private void BtnComprar_Clicked(object sender, EventArgs e)
        {
            if(btnComprar.Text=="Comprar")
            {
                btnComprar.Text = "Registrar sus datos";
                lblCantidad.IsVisible = true;
                txtCantidad.IsVisible = true;
            }
            else
            {
                //Recuperar valores
                
                ClaseVariables.codigoProducto = 1;
                ClaseVariables.nombreproducto = lblNombre.Text;
                int cant = int.Parse(txtCantidad.Text);
                ClaseVariables.cantidad = cant;
                //-----------------
                double precio = double.Parse(lblPrecio.Text);
                ClaseVariables.precio = precio;
                //----------------------------------------
                Console.WriteLine("Precio====>" + ClaseVariables.precio);

                //Mostrar pagina
                Navigation.PushAsync(new Pagina7());
            }
        }

        //----------------
        ClaseConexion objeto = new ClaseConexion();
        //---------------
        private void ImgLenovo_Clicked(object sender, EventArgs e)
        {
            
            objeto.conectar();
            //--------------
            String cad = "select P.nombre,P.precio_venta,P.stock,P.descripcion," +
                         "C.nombre from producto P " +
                         "join categoria C on P.idcategoria = C.idcategoria " +
                         "where idproducto = 1 and C.idcategoria = 1;";

            objeto.consultardatos(cad);

            
            
            this.lblNombre.Text ="Nombre:" +  objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString();
            this.lblPrecio.Text = objeto.datos.Tables["xxx"].Rows[0].ItemArray[1].ToString();
            this.lblStock.Text = "Stock:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[2].ToString();
            this.lblDescripcion.Text ="Descripción:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[3].ToString();
            this.lblCategoria.Text = "Categoria:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[4].ToString();
        }
    }
}