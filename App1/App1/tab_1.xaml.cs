using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class tab_1 : ContentPage
	{
        private static IMobileServiceTable<tblUsuarios> tabla;
        public static MobileServiceClient cliente;
        public ObservableCollection<tblUsuarios> Items { get; set; }
        public tab_1 ()
		{
			InitializeComponent ();
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

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new asignarProyecto(e.SelectedItem as tblUsuarios));
            
        }
    }
}