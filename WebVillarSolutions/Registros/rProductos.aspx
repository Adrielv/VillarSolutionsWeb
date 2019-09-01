<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="WebVillarSolutions.Registros.rProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="content">
            <div id="Datos">
                <p style="color:#000000;text-align:center; font-size:larger">REGISTRO DE PRODUCTOS</p>

                  <asp:Button ID="buscarButton" runat="server" Text="BUSCAR" class="btn btn-dark btn-lg text-center my-3 float-right" onclick="buscarButton_Click" />
              <br />
                <asp:Label ID="Label1" runat="server" Text="ProductoId"></asp:Label>
                <asp:TextBox class="form-control" ID="id" runat="server" type="number" min="0" onkeypress="return isNumberKey(event)"></asp:TextBox>

          
               
                <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox class="form-control" ID="descripcion" runat="server"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox class="form-control" ID="cantidad" runat="server" ></asp:TextBox>

               
                <asp:Label ID="Label4" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox class="form-control" ID="precio" runat="server" type="number" min="1" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="precio_TextChanged"></asp:TextBox>

                 <asp:Label ID="Label5" runat="server" Text="Costo"></asp:Label>
                <asp:TextBox class="form-control" ID="costo" runat="server" type="number" min="1" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="costo_TextChanged"></asp:TextBox>

                 <asp:Label ID="Label6" runat="server" Text="Ganancia"></asp:Label>
                <asp:TextBox class="form-control" ID="ganancia" runat="server" ReadOnly="true"></asp:TextBox>

                 <asp:Label ID="Label7" runat="server" Text="ITBIS"></asp:Label>
                <asp:TextBox class="form-control" ID="itbis" runat="server" ReadOnly="true"></asp:TextBox>

                
              
                <asp:Button ID="nuevoButton" runat="server" Text="NUEVO" class="btn btn-dark btn-lg text-center my-3" OnClick="nuevoButton_Click"/>
                <asp:Button ID="guardarButton" runat="server" Text="GUARDAR" class="btn btn-dark btn-lg text-center my-3" OnClick="guardarButton_Click"/>
                <asp:Button ID="eliminarButton" runat="server" Text="ELIMINAR" class="btn btn-dark btn-lg text-center my-3" OnClick="eliminarButton_Click"/>
                </div>

    </div>
</asp:Content>
