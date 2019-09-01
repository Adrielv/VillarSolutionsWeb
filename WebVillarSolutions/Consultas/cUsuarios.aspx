<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="WebVillarSolutions.Consultas.cUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 align="center" style="font-weight: bold">Consulta de Usuarios</h3>
    <div class="form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-success" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>Todo por fecha</asp:ListItem>
                <asp:ListItem>UsuarioId</asp:ListItem>
                <asp:ListItem>Email</asp:ListItem>
                <asp:ListItem>Usuario</asp:ListItem>
                <asp:ListItem>Nombre</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--Criterio--%>
        <div class="form-group col-md-3">
            <asp:Label ID="Label1" runat="server" class="text-success" Text="Criterio">Criterio</asp:Label>
            <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="buscarLinkButton" CssClass="btn btn-outline-success mt-4" runat="server" OnClick="buscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
        </div>
    </div>

    <%--Rango fecha--%>
    <div class="form-row justify-content-center">
        <div class="form-group col-md-2">
            <asp:Label Text="Desde" class="text-success" runat="server" />
            <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
        <div class="form-group col-md-2">
            <asp:Label Text="Hasta" class="text-success" runat="server" />
            <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>
    <div class="form-row justify-content-center">
        <asp:GridView ID="UsuarioGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#006666" GridLines="None">
            <AlternatingRowStyle BackColor="#999999" />
            <Columns>
                <asp:BoundField DataField="UsuarioId" HeaderText="Usuario Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Nombres" HeaderText="Nombre" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="UserName" />
                <asp:BoundField DataField="NoTelefono" HeaderText="No. Telefónico" />
                <asp:BoundField DataField="NoCelular" HeaderText="No. Celular" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Password" HeaderText="Contraseña" />
                <asp:BoundField DataField="CPassword" HeaderText="Confirmación" />
                <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo" />
            </Columns>
            <HeaderStyle BackColor="LightGreen" Font-Bold="True" />
        </asp:GridView>
    </div>
</asp:Content>