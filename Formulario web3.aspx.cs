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
    public partial class Formulario_web3 : System.Web.UI.Page
    {

        public class Alumno //variables que serviran para pasarlas al actualizar y insertar un usuario
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

        private async Task ConsultarAlumnoPorId()//Metodo para buscar por filtro algun alumno ya sea para actualiza
        {
            try
            {
                // 1) Validamos y parseamos el Id a entero
                if (!int.TryParse(TextBox1.Text.Trim(), out int idAlumno))
                {
                    Response.Write("<script>alert('El Id debe ser un número válido');</script>");
                    return;
                }

                // 2) Preparamos la URL (UrlEncode por si acaso)
                string url = $"https://localhost:44304/api/usuario/consultarAlumnoPorId?id=" + idAlumno;

                using (var client = new HttpClient())
                {
                    // 3) Llamada HTTP
                    HttpResponseMessage respuesta = await client.GetAsync(url);
                    if (!respuesta.IsSuccessStatusCode)
                    {
                        Response.Write("<script>alert('Error al conectar con la API.');</script>");
                        return;
                    }

                    // 4) Leemos el JSON crudo
                    string json = await respuesta.Content.ReadAsStringAsync();

                    // 5) Parseamos a JObject
                    JObject root = JObject.Parse(json);

                    // 6) Comprobamos statusExec
                    if (root["statusExec"]?.Value<bool>() != true)
                    {
                        Response.Write("<script>alert('Error en la respuesta de la API.');</script>");
                        return;
                    }

                    // 7) Leemos el array datos.alumno
                    JArray arr = (JArray)root["datos"]?["alumno"];
                    if (arr == null || arr.Count == 0)
                    {
                        Response.Write("<script>alert('Alumno no encontrado.');</script>");
                        return;
                    }

                    // 8) Tomamos el primer objeto del array
                    JObject fila = (JObject)arr[0];

                    // 9) Asignamos a los TextBox
                    TextBox1.Text = fila["USU_ID"]?.ToString();
                    TextBox2.Text = fila["USU_NOMBRE"]?.ToString();
                    TextBox3.Text = fila["USU_APELLIDO"]?.ToString();
                    TextBox4.Text = fila["USU_EMAIL"]?.ToString();
                    TextBox5.Text = fila["USU_MATRICULA"]?.ToString();
                    TextBox6.Text = fila["USU_USERNAME"]?.ToString();
                    TextBox7.Text = fila["USU_PASSWORD"]?.ToString();
                    TextBox8.Text = fila["RUTA_IMAGEN"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                // Escapamos posibles comillas para no romper el alert
                string msg = ex.Message.Replace("'", "\\'");
                Response.Write($"<script>alert('Error de aplicación: {msg}');</script>");
            }
        }




        //Actualizar alumno
        private async Task ActualizarAlumno()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    String data = @"{
                                  ""UsuId"":""" + TextBox1.Text + "\"," +
                                  "\"UsuNombre\":\"" + TextBox2.Text + "\"," +
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
                    string apiUrl = "https://localhost:44304/api/usuario/actualizar";
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
                        if (objRespuesta.ban == 1)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('Alumno actualizado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web3.aspx';" +
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


        private async Task EliminarAlumno()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    String data = @"{
                                      ""UsuId"":""" + TextBox1.Text + @"""
                                    }";
                    // Configuración del contenido del <body> a enviar
                    HttpContent contenido = new StringContent
                                (data, Encoding.UTF8, "application/json");
                    // Ejecución de la petición HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/eliminar";
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
                        if (objRespuesta.ban == 1)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('Alumno Eliminado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web3.aspx';" +
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

        protected async void Button2_Click(object sender, EventArgs e)
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
                                        await ActualizarAlumno();
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        protected async void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                "alert('El id está vacío');" +
                "</script>");
            }
            else
            {
                await ConsultarAlumnoPorId();
            }
        }

        protected async void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                "alert('El cve está vacío');" +
                "</script>");
            }
            else
            {
                await EliminarAlumno();
            }
        }
    }

 
 }
