﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace wsCheckUsuario
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Variables globales (Application)
            Application["nomEmpresa"] = "ITP Item Exchange";

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Variables locales (Session)
            Session["nomUsuario"] = "";
            Session["imgUsuario"] = "";
            Session["usuUsuario"] = "";
            Session["maUsuario"] = "";

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}