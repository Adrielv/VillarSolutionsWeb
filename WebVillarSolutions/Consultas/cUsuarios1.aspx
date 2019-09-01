<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.Master" AutoEventWireup="true" CodeBehind="cUsuarios1.aspx.cs" Inherits="WebVillarSolutions.Consultas.cUsuarios1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 align="center" style="font-weight: bold">Consulta de Usuarios</h3>
    <div class="form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-info" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>UsuarioId</asp:ListItem>
                <asp:ListItem>Email</asp:ListItem>
                <asp:ListItem>Usuario</asp:ListItem>
                <asp:ListItem>Nombres</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--Criterio--%>
        <div class="form-group col-md-3">
            <asp:Label ID="Label1" runat="server" class="text-info" Text="Criterio">Criterio</asp:Label>
            <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="buscarLinkButton" CssClass="btn btn-info" runat="server" OnClick="buscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
        </div>
    </div>

    <%--Rango fecha--%>
    <div class="form-row justify-content-center">
        <div class="form-group col-md-2">
            <asp:Label Text="Desde" class="text-info" runat="server" />
            <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
        <div class="form-group col-md-2">
            <asp:Label Text="Hasta" class="text-info" runat="server" />
            <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>

            <asp:GridView ID="UsuarioGrid" runat="server" class="table table-condensed table-responsive " AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" DataKeyNames="UsuarioId" CellPadding="4" ForeColor="Black" GridLines="None">
                    <EmptyDataTemplate><div style="text-align:center">No hay datos.</div></EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField ControlStyle-ForeColor="#6699ff" DataNavigateUrlFields="UsuarioId" DataNavigateUrlFormatString="~/Registros/rUsuarios.aspx?Id={0}" Text="Editar"></asp:HyperLinkField>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
        </div>
    </div>
 

</asp:Content>
