using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//-------------------------
using System.Data;
using System.Data.SqlClient;

//-------------------------
namespace Proyecto01_paginas.Droid.Resources.clases
{
    public class ClaseConexion
    {
        //--------Declarar Objetos
        SqlConnection conexion;
        SqlDataAdapter adaptador;
        public DataSet datos;
        SqlCommand comando;
        public void conectar()
        {
            String cadena = "data source=bdventas1347168.database.windows.net;" +
                            "Initial Catalog=BDVentasEnLinea;" +
                            "User ID=administrador;Password=Senati@20202;" +
                            "Connection Timeout=60;";

            try
            {

                conexion = new SqlConnection(cadena);
                conexion.Open();

                Toast.MakeText(Application.Context,"Conexión Ok", ToastLength.Long).Show();

            } catch (Exception e)
            {
                Toast.MakeText(Application.Context, e.Message, ToastLength.Long).Show();
            }

        }

        //--------------
        public void consultardatos(String cadenasql)
        {
            try
            {

                adaptador = new SqlDataAdapter(cadenasql, conexion);
                datos = new DataSet();
                adaptador.Fill(datos, "xxx");

            }
            catch (Exception e)
            {
                Toast.MakeText(Application.Context, e.Message, ToastLength.Long).Show();
            }
        }

        //------------------------------
        public void ejecutar(String cadenasql)
        {
            try
            {

                comando = new SqlCommand(cadenasql, conexion);
                comando.ExecuteNonQuery();

            }catch(Exception e)
            {
                Toast.MakeText(Application.Context, e.Message, ToastLength.Long).Show();
            }
        }
    }
}