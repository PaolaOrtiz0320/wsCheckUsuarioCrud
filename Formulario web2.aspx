<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true" CodeBehind="Formulario_web2.aspx.cs" Inherits="wsCheckUsuario.Formulario_web2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/formularios.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
        .auto-style2 {
            width: 71%;
        }
        .auto-style3 {
            height: 27px;
            width: 71%;
        }
    .auto-style4 {
        width: 73%;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">    
        <br />
        <asp:Label ID="Label1" runat="server" Text="Gestión de Items" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Label>
        <br /><br />

        <table border="0" class="auto-style4">
            <tr>
                <td width="30%">
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="Small" Text="ID ITEM:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="3" Width="60px" CssClass="aspNetTextBox"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/imagenes/icon_logalum.GIF" OnClick="ImageButton5_Click" />
                </td>
            </tr>

            <tr>
                <td width="30%">
                    <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="Small" Text="Nombre:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="150" Width="300px" CssClass="aspNetTextBox"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td width="30%">
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" Text="Descripcion:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox3" runat="server" MaxLength="40" Width="300px" CssClass="aspNetTextBox"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td width="30%">
                    <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="Small" Text="Tipo:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListTipo" runat="server" Width="321px" CssClass="aspNetTextBox"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td width="30%" class="auto-style1">
                    <asp:Label ID="Label14" runat="server" Font-Names="Arial" Font-Size="Small" Text="Estado:"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="DropDownListEstado" runat="server" Width="321px" CssClass="aspNetTextBox"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td width="30%">
                    <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="Small" Text="Imagen:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox4" runat="server" MaxLength="40" Width="300px" CssClass="aspNetTextBox"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td width="30%">
                    <asp:Label ID="LabelHoraEntrega" runat="server" Font-Names="Arial" Font-Size="Small" Text="Hora Entrega:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox5" runat="server" MaxLength="10" Width="300px" Placeholder="HH:mm:ss" CssClass="aspNetTextBox"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td width="30%">
                    <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="Small" Text="Día Entrega:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox6" runat="server" MaxLength="20" Width="299px" CssClass="aspNetTextBox"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td width="30%">
                    <asp:Label ID="LabelUbicacion" runat="server" Font-Names="Arial" Font-Size="Small" Text="Ubicación:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListUbicacion" runat="server" Width="318px" CssClass="aspNetTextBox"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td colspan="2" align="center">
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    &nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Modificar" CssClass="btn btn-warning" OnClick="Button2_Click" />
                    &nbsp;
                    <asp:Button ID="Button3" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="Button3_Click" />
                    &nbsp;
                    <br />
                </td>
            </tr>
        </table>
        <br /><br />
    </div>
</asp:Content>
