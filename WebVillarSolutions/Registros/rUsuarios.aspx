<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="WebVillarSolutions.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="content">
  <div id="Datos">
      
                <asp:Button ID="buscarButton" runat="server" Text="BUSCAR" class="btn btn-dark btn-lg text-center my-3 float-right" onclick="buscarButton_Click" />
                  <br />
                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label> 
                <asp:TextBox class="form-control" ID="id" runat="server" type="number" min="0" onkeypress="return isNumberKey(event)"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label>
                <asp:TextBox class="form-control" ID="nombres" placeholder="Nombres" runat="server" onkeypress="return isLetterKey(event)"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                <asp:TextBox class="form-control" ID="email" placeholder="ejemplo@email.com" pattern="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{1,5})$" runat="server"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox class="form-control" ID="usuario" placeholder="Usuario" runat="server" onkeypress="if (event.keyCode == 32) event.returnValue = false"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" Text="Clave"></asp:Label>
                <asp:TextBox class="form-control" ID="clave" placeholder="Clave" runat="server" type="password"></asp:TextBox>

                <asp:Label ID="Label6" runat="server" Text="Confirmar"></asp:Label>
                <asp:TextBox class="form-control" ID="confirmar" placeholder="Confirmar clave" runat="server" type="password"></asp:TextBox>

                <asp:Label ID="Label7" runat="server" Text="Fecha"></asp:Label>
                <asp:TextBox class="form-control" ID="fecha" type="date" runat="server" ></asp:TextBox>

              
                <asp:Button ID="nuevoButton" runat="server" Text="NUEVO" class="btn btn-dark btn-lg text-center my-3" OnClick="nuevoButton_Click" />
                <asp:Button ID="guardarButton" runat="server" Text="GUARDAR" class="btn btn-dark btn-lg text-center my-3" OnClick="guardarButton_Click"/>
                <asp:Button ID="eliminarButton" runat="server" Text="ELIMINAR" class="btn btn-dark btn-lg text-center my-3" OnClick="eliminarButton_Click"/>

    </div>
</div>

</asp:Content>
