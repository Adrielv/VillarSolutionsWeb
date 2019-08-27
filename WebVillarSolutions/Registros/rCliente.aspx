<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.Master" AutoEventWireup="true" CodeBehind="rCliente.aspx.cs" Inherits="WebVillarSolutions.Registros.rCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="pageContent">
    <div id="Datos">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <asp:TextBox class="form-control" ID="id" runat="server" type="number" min="0" onkeypress="return isNumberKey(event)"></asp:TextBox>
        
        <asp:Button ID="buscarButton" runat="server" Text="BUSCAR" class="btn btn-dark btn-lg text-center my-3" OnClick="buscarButton_Click" />

        <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label>
        <asp:TextBox class="form-control" ID="nombres" placeholder="Nombres..." runat="server" onkeypress="return isLetterKey(event)"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" Text="Cedula"></asp:Label>
        <asp:TextBox class="form-control" ID="cedula" pattern="^\d{3}-\d{7}-\d{1}$" placeholder="###-#######-#" runat="server" ></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Telefono"></asp:Label>
        <asp:TextBox class="form-control" ID="tlf" pattern="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" placeholder="###-###-#### o (###) ###-####" runat="server"></asp:TextBox>

        <asp:Label ID="Label5" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox class="form-control" ID="direccion" placeholder="Direccion..." runat="server"></asp:TextBox>

        <asp:Label ID="Label7" runat="server" Text="Fecha"></asp:Label>
        <asp:TextBox class="form-control" ID="fecha" type="date" runat="server" ></asp:TextBox>

        <asp:Button ID="nuevoButton" runat="server" Text="NUEVO" class="btn btn-primary btn-lg text-center my-3" OnClick="nuevoButton_Click"/>
        <asp:Button ID="guardarButton" runat="server" Text="GUARDAR" class="btn btn-success btn-lg text-center mb-3" OnClick="guardarButton_Click"/>
        <asp:Button ID="eliminarButton" runat="server" Text="ELIMINAR" class="btn btn-danger btn-lg text-center" OnClick="eliminarButton_Click"/>
    </div>
</div>
</asp:Content>
