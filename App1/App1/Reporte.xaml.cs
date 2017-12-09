using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Reporte : ContentPage
	{
        public ObservableCollection<tblAsignarTareas> Items2 { get; set; }
        public static MobileServiceClient cliente2;
        public static IMobileServiceTable<tblAsignarTareas> Tabla2;
        string tarea;
        public Reporte (object selectedItem)
        {
            var dato = selectedItem as tblAsignarTareas;
            BindingContext = dato;
            InitializeComponent();
            cliente2 = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla2 = cliente2.GetTable<tblAsignarTareas>();
            if (tarea == "CREAR UN REPORTE DE PROYECTO")
            {
                btnConfirmar.IsVisible = false;
            }
            else
            {
                btnEnviar.IsVisible = false;
            }
        }

        

        private async void btnEnviar_Clicked(object sender, EventArgs e)
        {
            

            DateTime fecha = DateTime.Now;
            string fecha2 = fecha.ToString("dd/MM/yyyy");
            var data = new tblAsignarTareas
            {
                Id = lblId.Text,
                Accion = edit1.Text,
                Estatus = "Creada"
            };

            try
            {
                if (fecha2 == lblApe2.Text.Substring(0, 9))
                {

                    await Tabla2.UpdateAsync(data);
                    await DisplayAlert("Correcto", "Tarea Terminada Correctamente", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "Fuera de tiempo", "Ok");
                    var data1 = new tblAsignarTareas
                    {
                        Id = lblId.Text,
                        Estatus = "Cancelada"
                };

                    await Tabla2.UpdateAsync(data);
                }

            }
            catch (Exception error)
            {
                await DisplayAlert("error", "" + error, "Ok");
            }
        }
    }
}