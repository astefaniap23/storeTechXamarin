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
    public partial class Pagina4 : ContentPage
    {


        ClaseConexion objeto = new ClaseConexion();


        public Pagina4()
        {
            InitializeComponent();

            ///------------ impresora 1
            imgImpresora1.Clicked += ImgImpresora1_Clicked;
            lblCantidad1.IsVisible = false;
            txtCantidad1.IsVisible = false;
            btncomprar1.Clicked += BtnComprar1_Clicked;


            ///------------ impresora 2
       
            imgImpresora2.Clicked += ImgImpresora2_Clicked;
            lblCantidad2.IsVisible = false;
            txtCantidad2.IsVisible = false;

            btncomprar2.Clicked += BtnComprar2_Clicked;

            ///------------ impresora 3
        
            imgImpresora3.Clicked += ImgImpresora3_Clicked;
            lblCantidad3.IsVisible = false;
            txtCantidad3.IsVisible = false;

            btncomprar3.Clicked += BtnComprar3_Clicked;

        }

        //-----------------Impresora1


        private void BtnComprar1_Clicked(object sender, EventArgs e)
        {
            if (btncomprar1.Text == "Comprar")
            {
                btncomprar1.Text = "Registrar sus datos";
                lblCantidad1.IsVisible = true;
                txtCantidad1.IsVisible = true;
            }
            else
            {
                //Recuperar valores

                ClaseVariables.codigoProducto = 4;
                ClaseVariables.nombreproducto = lblNombre1.Text;
                int cant = int.Parse(txtCantidad1.Text);
                ClaseVariables.cantidad = cant;
         
                double precio = double.Parse(lblPrecio1.Text);
                ClaseVariables.precio = precio;
   
                Console.WriteLine("Precio====>" + ClaseVariables.precio);

                //Mostrar pagina
                Navigation.PushAsync(new Pagina7());
            }
        }

       
        private void ImgImpresora1_Clicked(object sender, EventArgs e)
        {

            objeto.conectar();
         
            String cad = "select P.nombre,P.precio_venta,P.stock,P.descripcion," +
                         "C.nombre from producto P " +
                         "join categoria C on P.idcategoria = C.idcategoria " +
                         "where idproducto = 4 and C.idcategoria = 2;";

            objeto.consultardatos(cad);

            this.lblNombre1.Text = "Nombre:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString();
            this.lblPrecio1.Text = objeto.datos.Tables["xxx"].Rows[0].ItemArray[1].ToString();
            this.lblStock1.Text = "Stock:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[2].ToString();
            this.lblDescripcion1.Text = "Descripción:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[3].ToString();
            this.lblCategoria1.Text = "Categoria:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[4].ToString();
        }

        //-----------------Impresora2

        private void BtnComprar2_Clicked(object sender, EventArgs e)
        {
            if (btncomprar2.Text == "Comprar")
            {
                btncomprar2.Text = "Registrar sus datos";
                lblCantidad2.IsVisible = true;
                txtCantidad2.IsVisible = true;
            }
            else
            {
                //Recuperar valores

                ClaseVariables.codigoProducto = 7;
                ClaseVariables.nombreproducto = lblNombre2.Text;
                int cant = int.Parse(txtCantidad2.Text);
                ClaseVariables.cantidad = cant;

                double precio = double.Parse(lblPrecio2.Text);
                ClaseVariables.precio = precio;

                Console.WriteLine("Precio====>" + ClaseVariables.precio);

                //Mostrar pagina
                Navigation.PushAsync(new Pagina7());
            }
        }


        private void ImgImpresora2_Clicked(object sender, EventArgs e)
        {

            objeto.conectar();

            String cad = "select P.nombre,P.precio_venta,P.stock,P.descripcion," +
                         "C.nombre from producto P " +
                         "join categoria C on P.idcategoria = C.idcategoria " +
                         "where idproducto = 7 and C.idcategoria = 2;";

            objeto.consultardatos(cad);

            this.lblNombre2.Text = "Nombre:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString();
            this.lblPrecio2.Text = objeto.datos.Tables["xxx"].Rows[0].ItemArray[1].ToString();
            this.lblStock2.Text = "Stock:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[2].ToString();
            this.lblDescripcion2.Text = "Descripción:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[3].ToString();
            this.lblCategoria2.Text = "Categoria:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[4].ToString();
        }



        //-----------------Impresora3

        private void BtnComprar3_Clicked(object sender, EventArgs e)
        {
            if (btncomprar3.Text == "Comprar")
            {
                btncomprar3.Text = "Registrar sus datos";
                lblCantidad3.IsVisible = true;
                txtCantidad3.IsVisible = true;
            }
            else
            {
                //Recuperar valores

                ClaseVariables.codigoProducto = 3;
                ClaseVariables.nombreproducto = lblNombre3.Text;
                int cant = int.Parse(txtCantidad3.Text);
                ClaseVariables.cantidad = cant;

                double precio = double.Parse(lblPrecio3.Text);
                ClaseVariables.precio = precio;

                Console.WriteLine("Precio====>" + ClaseVariables.precio);

                //Mostrar pagina
                Navigation.PushAsync(new Pagina7());
            }
        }


        private void ImgImpresora3_Clicked(object sender, EventArgs e)
        {

            objeto.conectar();

            String cad = "select P.nombre,P.precio_venta,P.stock,P.descripcion," +
                         "C.nombre from producto P " +
                         "join categoria C on P.idcategoria = C.idcategoria " +
                         "where idproducto = 3  and C.idcategoria = 2;";

            objeto.consultardatos(cad);

            this.lblNombre3.Text = "Nombre:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[0].ToString();
            this.lblPrecio3.Text = objeto.datos.Tables["xxx"].Rows[0].ItemArray[1].ToString();
            this.lblStock3.Text = "Stock:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[2].ToString();
            this.lblDescripcion3.Text = "Descripción:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[3].ToString();
            this.lblCategoria3.Text = "Categoria:" + objeto.datos.Tables["xxx"].Rows[0].ItemArray[4].ToString();
        }

    }
}