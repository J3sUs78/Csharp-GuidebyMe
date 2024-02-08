<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MantenedorPersonas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1 class="text-center mb-4">Configuración de la conexión a la base de datos</h1>

        <div class="card shadow-sm mb-4">
            <div class="card-body">

                <div class="row g-3">
                    <div class="col-md-12">
                        <div class="row g-2">
                            <div class="col-md-6">
                                <label for="txtServer">Servidor</label>
                                <asp:TextBox ID="txtServer" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtPort">Puerto</label>
                                <asp:TextBox ID="txtPort" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtUserId">Usuario</label>
                                <asp:TextBox ID="txtUserId" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtPassword">Contraseña</label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-12">
                                <label for="txtDatabase">Base de datos</label>
                                <asp:TextBox ID="txtDatabase" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="d-grid gap-2 ">
                            <asp:Button ID="btnGuardar" Text="Agregar datos de conexion" OnClick="btnGuardar_Click" runat="server" class="btn btn-secondary btn-block"></asp:Button>
                            <asp:Button ID="btnProbarCone" Text="Probar datos conexion" OnClick="btnProbarCone_Click" runat="server" class="btn btn-primary btn-block"></asp:Button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
