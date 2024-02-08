<%@ Page Title="Iniciar sesion" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FInicioSesion.aspx.cs" Inherits="MantenedorPersonas.FInicioSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="card text-center mt-3">
        <div class="card-header">
            <h5>Bienvenido, ya registrado inica sesion....</h5>
        </div>


    

        <div class="card-body" >
        
                <div class="row g-3">
                    <div class="col-md-6">

                        <div class="mb-3">
                            <label for="txtRutUsuario">RUT:</label>
                            <asp:TextBox ID="txtRutUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="txtPaswword">Contraseña: </label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                            <div class="d-grid gap-2">
                                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesion" CssClass="btn btn-primary"  OnClick="btnLogin_Click"/>
                            </div>
                        </div>
                 </div>
 
                
                

        </div>
    </div>

</asp:Content>
