using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paex3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                //contenenedor de una coleccion para  guardar temporalmente los datos 
                var parametros = new System.Collections.Specialized.NameValueCollection();

                //agrego los datos 
                parametros.Add("codigo", txtID.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.17.45/WS_Paex/post.php","POST", parametros);
                DisplayAlert("Alerta", "Ingreso correcto", "CErrar");

                Navigation.PushAsync(new MainPage());
            }
            catch (Exception)
            {

                //throw;
            }

        }
    }
}