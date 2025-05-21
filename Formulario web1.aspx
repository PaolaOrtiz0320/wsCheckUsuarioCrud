<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="wsCheckUsuario.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/principal.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            border-collapse: collapse;
            margin-top: 0px;
            box-shadow: 0 0 12px rgba(75, 0, 130, 0.4);
            border-radius: 10px;
            overflow: hidden;
            font-size: 14px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class> 

        <asp:Label ID="Label1" runat="server" Text="📚 Biblioteca" CssClass="tituloContenido" Style="font-size: 20px; margin-bottom: 20px;"></asp:Label>

        <div class="input-group">
            <label for="TextBox1">Buscar Item:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="16px" ></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagenes/icon_logalum.GIF" CssClass="btn-primary" OnClick="ImageButton1_Click" AlternateText="Buscar" />
        </div>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" OnRowDataBound="GridView1_RowDataBound" CssClass="contenedor-grid" Height="115px" Width="100%">
       <AlternatingRowStyle BackColor="#e0c3fc" />
            <HeaderStyle BackColor="#6a0572" Font-Names="Arial" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#9b59b6" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#f8f0ff" ForeColor="#3b0069" />
            <SelectedRowStyle BackColor="#d1b3ff" Font-Italic="True" />
    </asp:GridView>
    </div>
</asp:Content>