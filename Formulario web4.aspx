<%@ Page Async="true" Title="Somos" Language="C#" MasterPageFile="~/mpPrincipal.master" AutoEventWireup="true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/principal.css" rel="stylesheet" />
    <link href="bootstrap/css/somos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="quienes-container">
        <h1 class="quienes-title">👩‍💻 Nosotros Somos</h1>

        <div class="personas">
            <div class="persona">
                <img src="imagenes/fotos/paoortiz.jpg" alt="Gabriela" class="foto">
                <h3>Gabriela Paola Ortiz Velázquez</h3>
                <p>Estudiante de 8° semestre en el Tec de Pachuca. Apasionada por el desarrollo web, la gestion de base de datos y la experiencia de usuario.</p>
                <a href="https://www.linkedin.com/in/gabriela-paola-ortiz-velázquez-033b03307" target="_blank" class="linkedin-btn">LinkedIn</a>
            </div>

            <div class="persona">
                <img src="imagenes/fotos/2.jpg" alt="Fernanda" class="foto">
                <h3>María Fernanda Moedano Alcántara</h3>
                <p>Estudiante de 8° semestre en el Tec de Pachuca. Enfocada en datos, IA y tecnología socialmente responsable.</p>
                <a href="https://www.linkedin.com/in/maría-fernanda-moedano-alcántara-a32aba307" target="_blank" class="linkedin-btn">LinkedIn</a>
            </div>

            <div class="persona">
                <img src="imagenes/fotos/4.jpg" alt="Alan" class="foto">
                <h3>Alan Soto Cadena</h3>
                <p>Estudiante de 8° semestre en el Tec de Pachuca. Especialista en ciberseguridad y backend.</p>
                <a href="https://www.linkedin.com/in/alan-soto-cadena-226405305" target="_blank" class="linkedin-btn">LinkedIn</a>
            </div>
        </div>

        <div class="btn-container">
            <a href="Formulario web1.aspx" class="volver-btn">🏠 Volver al inicio</a>
        </div>
    </div>
</asp:Content>
