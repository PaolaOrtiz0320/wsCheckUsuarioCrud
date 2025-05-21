using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wsCheckUsuario.Models;
using System.Text.RegularExpressions;


namespace wsCheckUsuario
{
    public partial class wsAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private async Task cargaDatosApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Contenido para enviarse al endpoint
                    String datos = @"{
                                    ""UsuUsername"":""" + TextBox1.Text + "\"," +
                                    "\"UsuPassword\":\"" + TextBox2.Text + "\"" +
                                    "}";
                    // Configurar el envío del contenido
                    HttpContent contenido =
                            new StringContent(datos, Encoding.UTF8, "application/json");
                    string urlApi = "https://localhost:44304/api/usuario/login";
                    // Ejecución del endpoint
                    HttpResponseMessage respuesta =
                            await client.PostAsync(urlApi, contenido);


                    // ---------------------------------------------------
                    // Validación de recepción de respuesta Json
                    clsApiStatus objRespuesta = new clsApiStatus();
                    // Se debe importar el modelo de salida clsApiStatus!
                    // ---------------------------------------------------
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);

                        if (objRespuesta.ban == 1)
                        {
                            //Usuario Valido, actualizacion de la sesion
                            //Variables locales (Session)
                            Session["idUsuario"] = objRespuesta.datos["Id"].ToString();
                            Session["nomUsuario"] = objRespuesta.datos["Nombre"].ToString();
                            Session["apUsuario"] = objRespuesta.datos["Apellido"].ToString();
                            Session["emaUsuario"] = objRespuesta.datos["Email"].ToString(); ;
                            Session["maUsuario"] = objRespuesta.datos["Matricula"].ToString();
                            Session["usuUsuario"] = objRespuesta.datos["Usuario"].ToString(); ;
                            Session["imgUsuario"] = objRespuesta.datos["Imagen"].ToString();
                            Response.Write("<script language='javascript'>" + "alert('Bienvenido(a):" + Session["nomUsuario"].ToString() + "');" + "</script>");

                            Response.Write("<script language='javascript'>" + "document.location.href='Formulario web1.aspx';" + "</script>");
                        }
                        else
                        {
                            //usuario NO valido, resetear la sesion 
                            //Variables locales (Session)
                            Session["nomUsuario"] = "";
                            Session["imgUsuario"] = "";
                            Session["usuUsuario"] = "";
                            Session["maUsuario"] = "";


                            Response.Write("<script language='javascript'>" + "alert('Acceso Denegado ...');" + "</script>");

                        }


                    }
                    else
                    {
                        Response.Write("<script language='javascript'>" + "alert('Fallo la conexion con el servidor, intentar mas tarde');" + "</script>");
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write(ex.InnerException.ToString());
                Response.Write("<script language='javascript'>" + "alert('Sucedio un error en el acceso de la aplicacion," +
                    "contacte al administrador del sistema.');" + "</script>");
            }

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            //Ejecucion asincronadel metodo cargaDatosApi( )
            await cargaDatosApi();
        }
    }
}