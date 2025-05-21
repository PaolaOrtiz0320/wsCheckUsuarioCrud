<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true" CodeBehind="Formulario web5.aspx.cs" Inherits="wsCheckUsuario.Formulario_web5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/formularios.css" rel="stylesheet" />
    <!-- Formulario exclusivamente para registrar alumnos nuevos desde la pagina de acceso -->
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
        .auto-style4 {
            height: 33px;
        }
        .auto-style5 {
            height: 38px;
        }
        .auto-style7 {
            height: 36px;
        }
        .auto-style8 {
            height: 32px;
        }
        .auto-style10 {
            height: 357px;
            width: 71%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">    
    <br />
    <asp:Label ID="Label1" runat="server" Text="Gestión de Alumnos" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Label>
    <br /><br />

    <table border="0" class="auto-style10">

        <tr>
            <td width="30%" class="auto-style5">

                <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" Text="Nombre:"></asp:Label>

            </td>
            <td width="70%" class="auto-style5">

                <asp:TextBox ID="TextBox2" runat="server" MaxLength="150" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%" class="auto-style4">

                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" Text="Apellidos:"></asp:Label>

            </td>
            <td width="70%" class="auto-style4">

                <asp:TextBox ID="TextBox3" runat="server" MaxLength="40" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%" class="auto-style8">

                <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" Text="Email:"></asp:Label>

            </td>
            <td width="70%" class="auto-style8">

                <asp:TextBox ID="TextBox4" runat="server" MaxLength="40" Width="300px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%" class="auto-style7">

                <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" Text="Matricula:"></asp:Label>

            </td>
            <td width="70%" class="auto-style7">

                <asp:TextBox ID="TextBox5" runat="server" MaxLength="8" Width="299px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%" class="auto-style1">

                <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" Text="Usuario:"></asp:Label>

            </td>
            <td width="70%" class="auto-style1">

                <asp:TextBox ID="TextBox6" runat="server" MaxLength="8" Width="299px"></asp:TextBox>

            </td>
        </tr>

        <tr>
            <td width="30%" class="auto-style8">

                <asp:Label ID="Label15" runat="server" Font-Names="Arial" Font-Size="Small" Text="Contraseña:"></asp:Label>

            </td>
            <td width="70%" class="auto-style8">

                <asp:TextBox ID="TextBox7" runat="server" MaxLength="200" Width="299px"></asp:TextBox>

            </td>
        </tr>

        <tr>
            <td width="30%" class="auto-style5">

                <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" Text="Imagen:"></asp:Label>

            </td>
            <td width="70%" class="auto-style5">
                <asp:TextBox ID="TextBox8" runat="server" MaxLength="200" Width="299px"></asp:TextBox>


            </td>
        </tr>

        <tr>
            <td colspan="2" align="middle">
                <br />
                <asp:Button ID="Button1" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="Button1_Click" />
                 &nbsp;
                <asp:Button ID="Button2" runat="server" Text="Acceder"  CssClass="btn btn-orange" PostBackUrl="~/Formulario web1.aspx"/>
                <br />
            </td>
        </tr>
    </table>

    <br /><br />
</div>

</asp:Content>
