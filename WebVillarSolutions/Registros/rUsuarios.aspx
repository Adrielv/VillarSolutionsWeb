<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="WebVillarSolutions.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           
 <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-8">
            <div class="card">
                <div class="card-header text-uppercase text-center text-info"> Registro Usuario</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" class="text-info text-center" Text="UsuarioId"></asp:Label>
                                    <asp:Button class="btn btn-info" ID="BuscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                                    <asp:TextBox class="form-control" type="number" ID="UsuarioIdTextBox" Text="0" runat="server" ValidationGroup="Guardar"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="usuarioIdRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="usuarioIdTextBox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="usuarioIdRegularExpressionValidator" runat="server" ErrorMessage="Solo Números" ControlToValidate="usuarioIdTextBox" ValidationExpression="^[0-9]*$" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-md-offset-3 ">
                            <div class="container ">
                                <div class="form-group ">
                                    <asp:Label ID="Label10" runat="server" class="text-info" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="FechaTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br>
                      
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" class="text-info" Text="Nombre"></asp:Label>
                                    <asp:TextBox class="form-control" type="text" ID="NombresTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="nombreRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="NombresTextBox" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="nombreRegularExpressionValidator" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombresTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group ">
                                    <asp:Label ID="Label8" runat="server" class="text-info" Text="Usuario"></asp:Label>
                                    <asp:TextBox class="form-control " type="text" ID="UsuarioTextBox" placeholder="Usuario" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="usernameRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="UsuarioTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br>
                      
                      
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" class="text-info" Text="Email"></asp:Label>
                                    <asp:TextBox class="form-control" type="email" ID="EmailTextBox" placeholder="Adriel@gmail.com" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="EmailTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" class="text-info" Text="Contraseña"></asp:Label>
                                    <asp:TextBox class="form-control" ID="ClaveTextBox" type="password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="ClaveTextBox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="passwordCompareValidator" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="ConfirmarTextBox" ControlToValidate="ClaveTextBox" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Guardar"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" class="text-info" Text="Confirmar Contraseña"></asp:Label>
                                    <asp:TextBox class="form-control" ID="ConfirmarTextBox" type="password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="cpasswordRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="ConfirmarTextBox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cpasswordCompareValidator" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="ClaveTextBox" ControlToValidate="ConfirmarTextBox" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Guardar"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <br>                    
                        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" />
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button Text="Nuevo" class="btn btn-primary" runat="server" ID="nuevoButton" OnClick="nuevoButton_Click" />
                                    <asp:Button Text="Guardar" class="btn btn-success" runat="server" ID="guadarButton" OnClick="guardarButton_Click" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger" runat="server" ID="eliminarButton" OnClick="eliminarButton_Click" />
                                </div>
                            </div>
                        </div>

                    </form>
                </article>
            </div>
            <!-- card.// -->
    </div>
    <br>
</asp:Content>