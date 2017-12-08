using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<tblUsuarios> Items { get; set; }
        public static MobileServiceClient cliente;
        public static IMobileServiceTable<tblUsuarios> Tabla;
        public static string mat, nom, ape1, ape2, tipo, correo;
        public MainPage()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<tblUsuarios>();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (txtuser.Text == null || txtpass.Text == null)
            {
                if (txtuser.Text == null) { txtuser.BackgroundColor = Color.Red; }
                if (txtpass.Text == null) { txtpass.BackgroundColor = Color.Red; }
                if (txtuser.Text != null) { txtuser.BackgroundColor = Color.Default; }
                if (txtpass.Text != null) { txtpass.BackgroundColor = Color.Default; }
            }
            else
            {
                try
                {
                    string result = "";
                    byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txtpass.Text);
                    result = Convert.ToBase64String(encryted);
                    IEnumerable<tblUsuarios> elementos = await Tabla.Where(todoItem => todoItem.Id == txtuser.Text && todoItem.Contraseña == result).ToEnumerableAsync();
                    Items = new ObservableCollection<tblUsuarios>(elementos);
                    int cont = Items.Count;
                    mat = Items[0].Id;
                    nom = Items[0].Nombre;
                    ape1 = Items[0].Paterno;
                    ape2 = Items[0].Materno;
                    tipo = Items[0].Tipo;
                    correo = Items[0].Correo;

                    if (cont == 1)
                    {
                        await DisplayAlert("Correcto", "Bienvenido " + nom + " " + ape1 + " " + ape2, "Ok");
                        if (tipo == "Administrador")
                        {
                            await Navigation.PushModalAsync(new Administrador());
                        }
                        else if (tipo == "Maestro")
                        {
                            await Navigation.PushModalAsync(new Maestro());
                        }
                        else if (tipo == "Alumno")
                        {
                            await Navigation.PushModalAsync(new Alumno());
                        }


                    }
                    else
                    {
                        await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Ok");
                    }
                }
                catch
                {

                }
            }
        }
    }
}
