using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuarios : ContentPage
    {
        private static IMobileServiceTable<tblUsuarios> tabla;
        public static MobileServiceClient cliente;
        public ObservableCollection<tblUsuarios> Items { get; set; }
        string tipo;

        public Usuarios()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            tabla = cliente.GetTable<tblUsuarios>();
            leerAlumnos();
        }
        private async void leerAlumnos()
        {
            IEnumerable<tblUsuarios> elementos = await tabla.ToEnumerableAsync();
            Items = new ObservableCollection<tblUsuarios>(elementos);
            BindingContext = this;
            InitializeComponent();
        }
        private async void btnreg_ClickedAsync(object sender, EventArgs e)
        {
            if (txtuser.Text == null || txtnombre.Text == null || txtape_pat.Text == null || txtape_mat.Text == null  )
            {
                await DisplayAlert("Error", "Debe llenar todos los campos", "Ok");
            }
            else
            {
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txtuser.Text);
                string result = Convert.ToBase64String(encryted);
                var datos = new tblUsuarios
                {
                    Id = txtuser.Text,
                    Nombre = txtnombre.Text,
                    Paterno = txtape_pat.Text,
                    Materno = txtape_mat.Text,
                    Tipo = tipo,
                    Correo = txtcorreo.Text,
                    Contraseña = result
                };

                try
                {
                    await tabla.InsertAsync(datos);
                    await DisplayAlert("Correcto", "El Usuario se a agregado correctamente", "Ok");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "Ok");
                }
            }
        }

        private void pkrTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                tipo = (string)picker.ItemsSource[selectedIndex];
            }
        }
    }
}