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
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            //Validacion de 1er carga de pagina (postBack)
            if (Page.IsPostBack == false) {
                //Llamada para ejecucion del metodo
                await CargaDatosTipoUsuario();
                await CargaDatosEstadoUsuario();
                await CargaDatosUbicacionUsuario();
            }

        }


        public class Item
        {
            public int ITEM_ID { get; set; }
            public string ITEM_NOMBRE { get; set; }
            public string ITEM_DESCRIPCION { get; set; }
            public string RUTA_IMAGEN { get; set; }
            public string TIPO_NOMBRE { get; set; }
            public string EST_DESCRIPCION { get; set; }
            public string PROPIETARIO { get; set; }
            public string HORA_ENTREGA { get; set; }
            public string DIA_ENTREGA { get; set; }
            public string LUGAR { get; set; }
        }

        public class RespuestaAPI
        {
            public bool statusExec { get; set; }
            public string msg { get; set; }
            public int ban { get; set; }
            public Item Item { get; set; }
        }

        // Creación del método asíncrono para ejecutar el
        // endpoint vwTipoUsuario
        private async Task CargaDatosTipoUsuario()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración de la peticion HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/listarTipos";
                    // Ejecución del endpoint
                    HttpResponseMessage respuesta = await client.GetAsync(apiUrl);
                    // ---------------------------------------------------
                    // Validación de recepción de respuesta Json
                    clsApiStatus objRespuesta = new clsApiStatus();

                    // Validación del estatus OK
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);
                        // ------------------------------------------
                        JArray jsonArray = (JArray)objRespuesta.datos["tipos"];
                        // Convertir JArray a DataTable
                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                        // -------------------------------------------
                        // Visualización de los datos formateados DropDownList
                        DropDownListTipo.DataSource = dt;
                        DropDownListTipo.DataTextField = "TIPO_NOMBRE";
                        DropDownListTipo.DataValueField = "TIPO_ID";
                        DropDownListTipo.DataBind();
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


        private async Task CargaDatosEstadoUsuario()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración de la peticion HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/listarEstados";
                    // Ejecución del endpoint
                    HttpResponseMessage respuesta = await client.GetAsync(apiUrl);
                    // ---------------------------------------------------
                    // Validación de recepción de respuesta Json
                    clsApiStatus objRespuesta = new clsApiStatus();

                    // Validación del estatus OK
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);
                        // ------------------------------------------
                        JArray jsonArray = (JArray)objRespuesta.datos["estados"];
                        // Convertir JArray a DataTable
                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                        // -------------------------------------------
                        // Visualización de los datos formateados DropDownList
                        DropDownListEstado.DataSource = dt;
                        DropDownListEstado.DataTextField = "EST_DESCRIPCION";
                        DropDownListEstado.DataValueField = "EST_ID";
                        DropDownListEstado.DataBind();
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



        private async Task CargaDatosUbicacionUsuario()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración de la peticion HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/listarUbicaciones";
                    // Ejecución del endpoint
                    HttpResponseMessage respuesta = await client.GetAsync(apiUrl);
                    // ---------------------------------------------------
                    // Validación de recepción de respuesta Json
                    clsApiStatus objRespuesta = new clsApiStatus();

                    // Validación del estatus OK
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();
                        objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);
                        // ------------------------------------------
                        JArray jsonArray = (JArray)objRespuesta.datos["ubicaciones"];
                        // Convertir JArray a DataTable
                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
                        // -------------------------------------------
                        // Visualización de los datos formateados DropDownList
                        DropDownListUbicacion.DataSource = dt;
                        DropDownListUbicacion.DataTextField = "LUGAR";
                        DropDownListUbicacion.DataValueField = "UBI_ID";
                        DropDownListUbicacion.DataBind();
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



        // Creación del método asíncrono para ejecutar el
        // endpoint spInsUsuario
        private async Task insertarDatos()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    String data = @"{
                                  ""Nombre"":""" + TextBox2.Text + "\"," +
                                  "\"Descripcion\":\"" + TextBox3.Text + "\"," +
                                  "\"TipoId\":\"" + DropDownListTipo.SelectedValue + "\"," +
                                  "\"EstId\":\"" + DropDownListEstado.SelectedValue + "\"," +
                                  "\"UsuId\":\"" + Session["idUsuario"].ToString() + "\"," +
                                  "\"RutaImagen\":\"" + TextBox4.Text + "\"," +
                                  "\"HoraEntrega\":\"" + TextBox5.Text + "\"," +
                                  "\"DiaEntrega\":\"" + TextBox6.Text + "\"," +
                                  "\"UbiId\":\"" + DropDownListUbicacion.SelectedValue + "\"" +
                                  "}";
                    // Configuración del contenido del <body> a enviar
                    HttpContent contenido = new StringContent
                                (data, Encoding.UTF8, "application/json");
                    // Ejecución de la petición HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/insertarItem";
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
                                           "alert('Item registrado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web2.aspx';" +
                                           "</script>");
                        }
                        if (objRespuesta.ban == 1)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('El nombre de item ya existe');" +
                                           "</script>");
                        }
                        if (objRespuesta.ban == 2)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('El item ya existe');" +
                                           "</script>");
                        }
                        if (objRespuesta.ban == 3)
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('El tipo de usuario no existe');" +
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
        //Consulta para actualizar 
        private async Task consultaItemId()
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:44304/api/usuario/listarItems?filtro=" + TextBox1.Text;

                    HttpResponseMessage respuesta = await client.GetAsync(apiUrl);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();

                        clsApiStatus objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);

                        if (objRespuesta != null && objRespuesta.statusExec)
                        {
                            JArray jsonArray = (JArray)objRespuesta.datos["items"];

                            if (jsonArray != null && jsonArray.Count > 0)
                            {
                                // Tomamos el primer item para llenar controles
                                dynamic item = JsonConvert.DeserializeObject<dynamic>(jsonArray[0].ToString());

                                TextBox2.Text = item.ITEM_NOMBRE;
                                TextBox3.Text = item.ITEM_DESCRIPCION;
                                TextBox4.Text = item.RUTA_IMAGEN;
                                TextBox5.Text = item.HORA_ENTREGA;
                                TextBox6.Text = item.DIA_ENTREGA;

                                DropDownListTipo.SelectedValue = item.TIPO_NOMBRE;
                                DropDownListEstado.SelectedValue = item.EST_DESCRIPCION;
                                DropDownListUbicacion.SelectedValue = item.LUGAR;
                            }
                            else
                            {
                                Response.Write("<script>alert('Item no encontrado.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Error en la respuesta de la API.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al conectar con la API.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error de aplicación: " + ex.Message + "');</script>");
            }
        }


        //ACTUALIZAR DATOS
        private async Task actualizarItem()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    String data = @"{
                                  ""ItemId"":""" + TextBox1.Text + "\"," +
                                  "\"Nombre\":\"" + TextBox2.Text + "\"," +
                                  "\"Descripcion\":\"" + TextBox3.Text + "\"," +
                                  "\"TipoId\":\"" + DropDownListTipo.SelectedValue + "\"," +
                                  "\"EstId\":\"" + DropDownListEstado.SelectedValue + "\"," +
                                  "\"Rutaimagen\":\"" + TextBox4.Text + "\"," +
                                  "\"HoraEntrega\":\"" + TextBox5.Text + "\"," +
                                  "\"DiaEntrega\":\"" + TextBox6.Text + "\"," +
                                  "\"UbiId\":\"" + DropDownListUbicacion.SelectedValue + "\"" +
                                  "}";
                    // Configuración del contenido del <body> a enviar
                    HttpContent contenido = new StringContent
                                (data, Encoding.UTF8, "application/json");
                    // Ejecución de la petición HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/actualizarItem";
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
                                           "alert('Item Actualizado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web2.aspx';" +
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


        //Eliminar ITEM
        private async Task EliminarItem()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Configuración del Json que se enviará
                    String data = @"{
                                      ""ItemId"":""" + TextBox1.Text + @"""
                                    }";
                    // Configuración del contenido del <body> a enviar
                    HttpContent contenido = new StringContent
                                (data, Encoding.UTF8, "application/json");
                    // Ejecución de la petición HTTP
                    string apiUrl = "https://localhost:44304/api/usuario/eliminarItem";
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
                                           "alert('Item Eliminado exitosamente');" +
                                           "</script>");
                            Response.Write("<script language='javascript'>" +
                                           "document.location.href='Formulario web2.aspx';" +
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

        //Boton buscar por ID para actualizar 
        protected async void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                "alert('El ID está vacío');" +
                "</script>");
            }
            else
            {
                await consultaItemId();
            }  
        
        }

        
        //Boton para insertar iten
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
                //Descripcion
                if (TextBox3.Text == "")
                {
                    Response.Write("<script language='javascript'>" +
                                   "alert('La Descripcion esta vacia');" +
                                   "</script>");

                }
                else
                {
                   
                        if (TextBox4.Text == "")
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('La imagen esta vacia');" +
                                           "</script>");

                        }
                        else
                        {
                            //Nombre 
                            if (TextBox5.Text == "")
                            {
                                Response.Write("<script language='javascript'>" +
                                               "alert('La contraseña esta vacia');" +
                                               "</script>");

                            }
                            else
                            {
                                //Nombre 
                                if (TextBox6.Text == "")
                                {
                                    Response.Write("<script language='javascript'>" +
                                                   "alert('La ruta de la foto esta vacio');" +
                                                   "</script>");

                                }
                                else
                                {
                                    //ejecucion asincrona del metodo de insercion de usuario
                                    await insertarDatos();
                                }
                            }
                        }
                    }
                }
            }
        //Boton modificar
        protected async void Button2_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                "alert('El id está vacío');" +
                "</script>");
            }
            else
            {
                if (TextBox2.Text == "")
                {
                    Response.Write("<script language='javascript'>" +
                                   "alert('El nombre esta vacio');" +
                                   "</script>");

                }
                else
                {
                    ///Descripcion
                    if (TextBox3.Text == "")
                    {
                        Response.Write("<script language='javascript'>" +
                                       "alert('La descripcion esta vacia');" +
                                       "</script>");

                    }
                    else
                    {
                        //Ruta img
                        if (TextBox4.Text == "")
                        {
                            Response.Write("<script language='javascript'>" +
                                           "alert('La ruta de la imagen esta vacia');" +
                                           "</script>");

                        }
                        else
                        {
                            //Hora
                            if (TextBox5.Text == "")
                            {
                                Response.Write("<script language='javascript'>" +
                                               "alert('La Hora esta vacio');" +
                                               "</script>");

                            }
                            else
                            {
                                //Dia
                                if (TextBox6.Text == "")
                                {
                                    Response.Write("<script language='javascript'>" +
                                                   "alert('El dia esta vacio');" +
                                                   "</script>");

                                }
                                else
                                {
                                        await actualizarItem();
                                }
                              }
                          }
                      }
                  }
              }
           }
        //Boton Eliminar
        protected async void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script language='javascript'>" +
                "alert('El id está vacío');" +
                "</script>");
            }
            else
            {
                await EliminarItem();
            }
        }
    }

  }



