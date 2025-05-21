<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="wsAcceso.aspx.cs" Inherits="wsCheckUsuario.wsAcceso" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>ITP Item Exchange</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="bootstrap/css/estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor-login">
            <h2 style="text-align:center;">ITP Item Exchange</h2>

            <div class="form-group">
                <label for="TextBox1">Usuario:</label>
                <div class="input-group">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Username" />
                </div>
            </div>

            <div class="form-group">
                <label for="TextBox2">Contraseña:</label>
                <div class="input-group">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
                </div>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="Button1_Click" />
            <asp:Button ID="Button3" runat="server" Text="Registrarse" CssClass="btn btn-registrarse" PostBackUrl="~/Formulario web5.aspx" />
            <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-danger" PostBackUrl="~/wsAcceso.aspx" />
        </div>
    </form>

    <script src="bootstrap/js/jquery-3.5.1.min.js"></script>
    <script src="bootstrap/js/popper.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
