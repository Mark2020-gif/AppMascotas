﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMascotas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracion : ContentPage
    {
        /*private SQLiteAsyncConnection con;*/
        public Configuracion()
        {
            InitializeComponent();

            //lblEmail.Text = Registro.Correo();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

           await Navigation.PushAsync(new Login());
          
        }
    }
}