using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alumno : ContentPage
    {
        private static IMobileServiceTable<tblAsignarTareas> Tabla;
        public static MobileServiceClient cliente;
        public ObservableCollection<tblAsignarTareas> Items { get; set; }
        public Alumno()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<tblAsignarTareas>();
            lbldata0.Text = "Id: " + App1.MainPage.mat;
            lbldata1.Text = "Nombre: " + App1.MainPage.nom + " " + App1.MainPage.ape1 + " " + App1.MainPage.ape2 + " ";
            lbldata2.Text = "Correo: " + App1.MainPage.correo;
            leerAsignarTarea();
        }
        private async void leerAsignarTarea()
        {
            IEnumerable<tblAsignarTareas> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<tblAsignarTareas>(elementos);
            BindingContext = this;
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new Reporte(e.SelectedItem as tblAsignarTareas));

        }
    }
}