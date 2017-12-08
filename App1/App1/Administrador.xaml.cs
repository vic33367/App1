using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Administrador : ContentPage
    {
        public Administrador()
        {
            InitializeComponent();
            lbldata0.Text = "Id: " + App1.MainPage.mat;
            lbldata1.Text = "Nombre: "+App1.MainPage.nom+" "+ App1.MainPage.ape1 + " " + App1.MainPage.ape2 + " " ;
            lbldata2.Text = "Correo: " +App1.MainPage.correo;
        }

        private async void btnAct_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Tareas());
        }
    }
}