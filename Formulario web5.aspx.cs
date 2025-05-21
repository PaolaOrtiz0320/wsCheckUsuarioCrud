using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wsCheckUsuario.Models;
using System.Text;

namespace wsCheckUsuario
{
    public partial class Formulario_web5 : System.Web.UI.Page
    {

        public class Alumno
        {
            public int USU_ID { get; set; }
            public string USU_NOMBRE { get; set; }
            public string USU_APELLIDO { get; set; }
            public string USU_EMAIL { get; set; }
            public string RUTA_IMAGEN { get; set; }
            public string USU_PASSWORD { get; set; }
            public string USU_USERNAME { get; set; }
            public string USU_MATRICULA { get; set; }

        }


        public class RespuestaAPI
        {
            public bool statusExec { get; set; }
            public string msg { get; set; }
            public int ban { get; set; }
            public Alumno datos { get; set; }
        }

        // Creación del método asíncrono para ejecutar el
        // endpoint vwTipoUsuario

        // Creación del método asíncrono para ejecutar el
        // endpoint spInsUsuario
        private async Task InsertarAlumno()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    String data = @"{
                                  ""UsuNombre"":""" + TextBox2.Text + "\"," +
                                  "\"UsuApellido\":\"" + TextBox3.Text + "\"," +
                                  "\"UsuEmail\":\"" + TextBox4.Text + "\"," +
                                  "\"UsuMatricula\":\"" + TextBox5.Text + "\"," +
                                  "\"UsuUsername\":\"" + TextBox6.Text + "\"," +
                                  "\"UsuPassword\":\"" + TextBox7.Text + "\"," +
                                  "\"Imagen\":\"" + TextBox8.Text + "\"" +
                                  "}";
                    // Configuración del contenido del <body> a enviar
                    HttpContent contenido = new StringContent
                                (data, Encoding.UTF8, "application/json");
                    // Ejecución de la petición HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/insertar";
                    // ----------------------------------------------
                    HttpResponseMessage respuesta =
                        await client.PostAsync(apiUrl, contenido);
                    // ---------------------------------------------------
                    // Validación de recepción de respuesta Json
                    clsApiStatus objRespuesta = new clsApiStatus();
                    // ---------------------------------------------------

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado =
                                await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);

                        // Bandera de estatus del proceso
                        if (objRespuesta.ban == 0)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('Alumno registrado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web3.aspx';" +
                                           "</script>");
                        }
                        if (objRespuesta.ban == 1)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('El nombre de alumno ya existe');" +
                                           "</script>");
                        }
                        if (objRespuesta.ban == 2)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('El alumno ya existe');" +
                                           "</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>" +
                                       "alert('Error de conexión con el servicio');" +
                                       "</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>" +
                               "alert('Error de la aplicación, intentar nuevamente');" +
                               "</script>");
            }
        }




        protected async void Button1_Click(object sender, EventArgs e)
        {
            //Nombre 
            if (TextBox2.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                               "alert('El nombre esta vacio');" +
                               "</script>");

            }
            else
            {
                //Apellido Paterno
                if (TextBox3.Text == "")
                {
                    Response.Write("<script language='javascript'>" +
                                   "alert('El apellido esta vacio');" +
                                   "</script>");

                }
                else
                {
                    //Apellido Materno
                    if (TextBox4.Text == "")
                    {
                        Response.Write("<script language='javascript'>" +
                                       "alert('El email esta vacio');" +
                                       "</script>");

                    }
                    else
                    {
                        //Nombre 
                        if (TextBox5.Text == "")
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('La matricula esta vacio');" +
                                           "</script>");

                        }
                        else
                        {
                            //Nombre 
                            if (TextBox6.Text == "")
                            {
                                Response.Write("<script language='javascript'>" +
                                               "alert('El usuario esta vacio');" +
                                               "</script>");

                            }
                            else
                            {
                                //password 
                                if (TextBox7.Text == "")
                                {
                                    Response.Write("<script language='javascript'>" +
                                                   "alert('La contraseña esta vacia');" +
                                                   "</script>");
                                }
                                else
                                {
                                    //Imagen
                                    if (TextBox8.Text == "")
                                    {
                                        Response.Write("<script language='javascript'>" +
                                                       "alert('La ruta de la imagen esta vacia');" +
                                                       "</script>");
                                    }
                                    else
                                    {
                                        //ejecucion asincrona del metodo de insercion de alumno
                                        await InsertarAlumno();
                                    }

                                }
                            }
                        }
                    }
                }
            }

        }
    }
}

