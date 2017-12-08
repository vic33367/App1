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
        public ObservableCollection<tblareas> Items { get; set; }
        public ObservableCollection<tblTareas> Items2 { get; set; }
        public static MobileServiceClient cliente;
        public static MobileServiceClient cliente2;
        public static IMobileServiceTable<tblareas> Tabla;
        public static IMobileServiceTable<tblTareas> Tabla2;
        string area;
        public Tareas()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            cliente2 = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<tblareas>();
            Tabla2 = cliente2.GetTable<tblTareas>();
            leerAreas();
            leerTareas();


        }
        private async void leerAreas()
        {
            IEnumerable<tblareas> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<tblareas>(elementos);
            int cont = Items.Count;
            var monkeyList = new List<string>();
            for (int i=0;i<cont;i++)
            {
                monkeyList.Add(Items[i].Area);
            }            
            pkrArea.ItemsSource = monkeyList;
        }
        private async void leerTareas()
        {
            IEnumerable<tblTareas> elementos = await Tabla2.ToEnumerableAsync();
            Items2 = new ObservableCollection<tblTareas>(elementos);
            BindingContext = this;
        }
        private async void LeerTareasEliminadas()
        {
            IEnumerable<tblTareas> elementos = await Tabla2.Where(todoItem => todoItem.Delete == true).ToEnumerableAsync();
            Items2 = new ObservableCollection<tblTareas>(elementos);
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
                    Descripcion = txtdescripcion.Text,
                    Area = area
                };

                try
                {
                    await Tareas.Tabla2.InsertAsync(data);
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