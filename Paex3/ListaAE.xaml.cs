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
    public partial class ListaAE : ContentPage
    {
        //para recibir lo datos 
        public ListaAE(Estudiante datos)
        {
            InitializeComponent();
            txtID.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection(); //contenedor de los datos como un vector

            parametros.Add("codigo", txtID.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.17.45/WS_Paex/post.php?codigo=" + txtID.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);

            DisplayAlert("ACTUALIZAR", "Dato actualizado con exito", "Cerrar");

            Navigation.PushAsync(new MainPage());
            var msj = "Elemento actualizado con exito";
            DependencyService.Get<mensaje>().LongAlert(msj);

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection(); //contenedor de los datos como un vector

            parametros.Add("codigo", txtID.Text);

            cliente.UploadValues("http://192.168.17.45/WS_Paex/post.php?codigo=" + txtID.Text, "DELETE", parametros);

            DisplayAlert("ELIMINAR", "Dato Eliminado", "Cerrar");

            Navigation.PushAsync(new MainPage());
            var mensaje = "Elemento Eliminado con exito";
            DependencyService.Get<mensaje>().LongAlert(mensaje);

        }
    }
}