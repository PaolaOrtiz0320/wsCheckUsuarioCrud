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

namespace wsCheckUsuario
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            //Configurar el evento de PageIndexChanging  del Gridview1
            GridView1.PageIndexChanging += GridView1_PageIndexChanging;
            await cargaDatosApi();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Actualizar el indice de pagina del GridView1
            //Actualizar los datos del GridView2
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        private async Task cargaDatosApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://localhost:44304/api/usuario/listarItemsDisponibles";
                    HttpResponseMessage respuesta = await client.GetAsync(apiUrl);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string resultado = await respuesta.Content.ReadAsStringAsync();
                        clsApiStatus objRespuesta = JsonConvert.DeserializeObject<clsApiStatus>(resultado);

                        if (objRespuesta?.datos?["items"] != null)
                        {
                            JArray jsonArray = (JArray)objRespuesta.datos["items"];
                            DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());

                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No se encontraron datos.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Error de conexión con webapi');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error inesperado: " + ex.Message + "');</script>");
            }
        }

        protected async void ImageButton1_Click(object sender, ImageClickEventArgs e)
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
                        JArray jsonArray = (JArray)objRespuesta.datos["items"];
                        DataTable dtFinal = JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());

                        if (dtFinal.Rows.Count > 0)
                        {
                            GridView1.DataSource = dtFinal;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No se encontraron resultados.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Error de conexión al buscar.');</script>");
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error inesperado ...');</script>");
            }
        }

        // -------------------------------------------------------
        // Este método convierte la ruta de texto en <img> dentro
        // de la celda 4 (índice 3) de cada fila de datos.
        // -------------------------------------------------------
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Índice 3 = columna 4
                TableCell cell = e.Row.Cells[3];
                string ruta = cell.Text.Trim();

                // Limpiar la celda de texto
                cell.Controls.Clear();

                // Crear y añadir el control Image
                Image img = new Image
                {
                    ImageUrl = ResolveUrl(ruta),
                    Width = Unit.Pixel(60),
                    Height = Unit.Pixel(60),
                    AlternateText = "Sin imagen"
                };
                cell.Controls.Add(img);
            }
        }
    }
}