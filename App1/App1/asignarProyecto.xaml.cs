using Acr.UserDialogs;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class asignarProyecto : ContentPage
    {
        public ObservableCollection<tblTareas> Items { get; set; }
        public static MobileServiceClient cliente;
        public static IMobileServiceTable<tblTareas> Tabla;

        public ObservableCollection<tblAsignarTareas> Items2 { get; set; }
        public static MobileServiceClient cliente2;
        public static IMobileServiceTable<tblAsignarTareas> Tabla2;
        string tarea;
        string dependencia,prioridad;
        public asignarProyecto(object selectedItem)
        {
            var dato = selectedItem as tblUsuarios;
            BindingContext = dato;
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<tblTareas>();
            cliente2 = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla2 = cliente.GetTable<tblAsignarTareas>();
            leerTareas();
            leerTareasAsignada();
        }

        private async void leerTareas()
        {
            IEnumerable<tblTareas> elementos = await Tabla.ToEnumerableAsync();
            Items= new ObservableCollection<tblTareas>(elementos);
            int cont1 = Items.Count;
            var List = new List<string>();
            for (int i = 0; i < cont1; i++)
            {
                List.Add(Items[i].Tarea);
            }
            pkrTarea.ItemsSource = List;
        }

        private async void leerTareasAsignada()
        {
            IEnumerable<tblAsignarTareas> elementos2 = await Tabla2.ToEnumerableAsync();
            Items2 = new ObservableCollection<tblAsignarTareas>(elementos2);
            int cont = Items2.Count;
            var List = new List<string>();
            for (int i = 0; i < cont; i++)
            {
                List.Add(Items2[i].Tarea);
            }
            pkrDependenciaUser.ItemsSource = List;
           
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var result = await UserDialogs.Instance.DatePromptAsync("Select date",DateTime.Now);
            if (result.Ok)
                txtFecha.Text = String.Format("{0:yyyy-MM-dd}", result.SelectedDate);
        }

        private void pkrTarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                tarea = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            var data = new tblAsignarTareas
            {
                Asignado = txtid.Text,
                Tarea = tarea,
                Prioridad = prioridad,
                FechaAsig = Convert.ToDateTime(fecha),
                FechaTerm = Convert.ToDateTime(txtFecha.Text),
                Estatus = "Creada"
            };

                try
                {
                await Tabla2.InsertAsync(data);
                leerTareasAsignada();
                await DisplayAlert("Correcto", "Tarea asignada correctamente", "Ok");
                    
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "Ok");
                }
            }

        private void pkrPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                prioridad = (string)picker.ItemsSource[selectedIndex];
            }

        }
        private void pkrDependenciaUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                dependencia = (string)picker.ItemsSource[selectedIndex];
            }

        }
    }
}