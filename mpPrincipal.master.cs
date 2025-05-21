using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace wsCheckUsuario
{
    public partial class mpPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtiene el nombre de la página actual
            string currentPage = System.IO.Path.GetFileName(Request.Path).ToLower();

            // Lista de páginas públicas que NO requieren sesión
            List<string> publicPages = new List<string> { "formulario web5.aspx", "wsacceso.aspx" };

            // Si la página NO es pública, validamos sesión
            if (!publicPages.Contains(currentPage))
            {
                // Validar que la sesión no esté vacía o nula (con OR)
                if (Session["nomUsuario"] == null || Session["imgUsuario"] == null ||
                    Session["usuUsuario"] == null || Session["maUsuario"] == null ||
                    Session["nomUsuario"].ToString() == "" || Session["imgUsuario"].ToString() == "" ||
                    Session["usuUsuario"].ToString() == "" || Session["maUsuario"].ToString() == "")
                {
                    // Mostrar alerta y redirigir
                    Response.Write("<script language='javascript'>" +
                        "alert('¡Acceso Denegado!');" + "</script>");

                    Response.Write("<script language='javascript'>" +
                        "document.location.href='wsAcceso.aspx';" + "</script>");
                }
                else
                {
                    // Sesión válida: actualizar etiquetas y foto
                    Label1.Text = Application["nomEmpresa"].ToString();
                    Label6.Text = Session["nomUsuario"].ToString() + "(" +
                                  Session["usuUsuario"].ToString() + ") - " +
                                  Session["maUsuario"].ToString();

                    Image2.ImageUrl = Session["imgUsuario"].ToString();
                }
            }

        


        //Actualizacion de etiquetas de la Aplicacion
        Label1.Text = Application["nomEmpresa"].ToString();
            Label6.Text = Session["nomUsuario"].ToString()+
                "("+Session["usuUsuario"].ToString()+") - "+
                Session["maUsuario"].ToString();

            // Configuracion de la foto del usuario en sesion
            Image2.ImageUrl = Session["imgUsuario"].ToString();
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {

            // Cerrar la sesion del usuario
            Session["nomUsuario"] = "";
            Session["imgUsuario"] = "";
            Session["usuUsuario"] = "";
            Session["maUsuario"] = "";
            Response.Write("<script language='javascript'>" +
              "alert('¡Sesion Cerrada Exitosamente!');" + "</script>");

            Response.Write("<script language='javascript'>" + 
                "document.location.href='wsAcceso.aspx';" + "</script>");
        }
    }
}