using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paex3
{
    public partial class MainPage : ContentPage
    {
        //acede al servidor con esta direccion
        private const string Url = "http://192.168.17.45/WS_Paex/post.php";

        private readonly HttpClient cliente = new HttpClient(); 

        //variable global 
        private ObservableCollection<Estudiante> destudiante;


        public MainPage()
        {
            InitializeComponent();
            mostrar();
        }

        //agrego un metodo 
        public async void mostrar()
        {
            //capturando los datos en la url con el metodo get
            var content = await cliente.GetStringAsync(Url);

            //llamar a un list de estudiante, le guardo en una variable y el convierto 

            List<Estudiante> gestudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);
             //aggregamos esa variable
            destudiante = new ObservableCollection<Estudiante>(gestudiante);

            ListaEstudiante.ItemsSource = destudiante;




        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registrar());
        }

        private void ListaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new ListaAE(objetoEstudiante));
        }
    }
}
