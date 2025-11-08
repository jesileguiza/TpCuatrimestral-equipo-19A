<%@ Page Title="" Language="C#" MasterPageFile="~/MasterComercio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCuatrimestral_Grupo_19A.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <header class="encabezado">
        <h1 class="logo-text">Nombre proyecto</h1>
        <h2 class="subtitulo">Librería · Juguetería · Reposteria · Papelera </h2>
    </header>

    <section class="banner">
        <h3>¡Aca encontras todo lo que necesitas!</h3>
    </section>

    <section class="categorias">
        <div class="card cat1">Papelería</div>
        <div class="card cat2">Librería</div>
        <div class="card cat3">Reposteria</div>
        <div class="card cat4">Juguetería</div>
        <div class="card cat5">Cotillon</div>
    </section>

    <section class="productos">
        <h3>Productos destacados</h3>
        <div class="galeria">
            <div class="card-producto">
                 <img src="Imagen\Productos\nievereymomo.jpg" alt="Nieve Rey Momo" class="img-producto" />
                <p>Nieve Rey Momo x12</p>
            </div>
            <div class="card-producto">
                <p>falta productos</p>
            </div>
            <div class="card-producto">
                <p>falta productos</p>
            </div>
        </div>
    </section>

    <footer class="footer">
        <p>Trabajo Cuatrimestral Programacion 3 - Universidad Tecnologica Nacional © 2025</p>
    </footer>

   
</asp:Content>
