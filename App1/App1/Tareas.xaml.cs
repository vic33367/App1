using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tareas : ContentPage
    {
        public ObservableCollection<tblTareas> Items { get; set; }
        public static MobileServiceClient cliente;
        public static IMobileServiceTable<tblTareas> Tabla;
        string area;
        public Tareas()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<tblTareas>();            
            leerTareas();


        }
        
        private async void leerTareas()
        {
            IEnumerable<tblTareas> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<tblTareas>(elementos);
            BindingContext = this;
        }
        private async void LeerTareasEliminadas()
        {
            IEnumerable<tblTareas> elementos = await Tabla.Where(todoItem => todoItem.Delete == true).ToEnumerableAsync();
            Items = new ObservableCollection<tblTareas>(elementos);
            BindingContext = this;
            InitializeComponent();
        }
        private async void btnreg_Clicked(object sender, System.EventArgs e)
        {
            if (txtnombre.Text == null || txtdescripcion.Text == null)
            {
                await DisplayAlert("Error", "Debe llenar todos los campos", "Ok");
            }
            else
            {
                var data = new tblTareas
                {
                    Tarea = txtnombre.Text,
                    Descripcion = txtdescripcion.Text
                    
                };

                try
                {
                    await Tareas.Tabla.InsertAsync(data);
                    leerTareas();
                    await DisplayAlert("Correcto", "Actividad " + txtnombre.Text + " agregada correctamente", "Ok");
                    InitializeComponent();
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "Ok");
                }
            }
        }
        private void pkrArea_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
                var picker = (Picker)sender;
                int selectedIndex = picker.SelectedIndex;

                if (selectedIndex != -1)
                {
                area = (string)picker.ItemsSource[selectedIndex];
                }
            
        }

        private void btnact_Clicked(object sender, EventArgs e)
        {

        }

        private void btndel_Clicked(object sender, EventArgs e)
        {

        }

        private  void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var dato = e.SelectedItem as tblTareas;
            DisplayAlert("Item Selected", ""+dato, "Ok");
            BindingContext = dato;
        }

    }
}