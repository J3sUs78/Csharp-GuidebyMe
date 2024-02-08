<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FContactosPersona.aspx.cs" Inherits="MantenedorPersonas.FContactosPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     

     <div class="card-body" >
         
             <div class="row g-3">
                 <div class="col-md-6">
                     <div class="mb-3">
                         <label for="txtR">Primer Nombre:</label>
                         <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="mb-3">
                         <label for="TxtApPaterno">Apellido Paterno:</label>
                         <asp:TextBox ID="TxtApPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="mb-3">
                         <label for="txtRutUsuario">RUT:</label>
                         <asp:TextBox ID="txtRutUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="mb-3">
                         <label for="txtEdad">Edad:</label>
                         <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                 </div>
                 <div class="col-md-6">
                     <div class="mb-3">
                         <label for="txtSegundoNombre">Segundo Nombre:</label>
                         <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>

                     <div class="mb-3">
                         <label for="TxtApMaterno">Apellido Materno:</label>
                         <asp:TextBox ID="TxtApMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>

                     <div class="mb-3">
                         <label for="txtTercerNombre">Tercer Nombre:</label>
                         <asp:TextBox ID="txtTercerNombre" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>


                     <div class="mb-3">
                         <label for="cmbRol">Genero:</label>
                             <asp:DropDownList ID="RolListGenero"  runat="server" CssClass="form-select">
                                 <asp:ListItem Value="2">Femenino</asp:ListItem>
                                 <asp:ListItem Value="1">Masculino</asp:ListItem>
                             </asp:DropDownList>

                     </div>

                     <div class="mb-3">
                         <div class="d-flex align-items-center">
                                 <label for="txtDate">Fecha de Nacimiento:</label>
                                 <asp:TextBox ID="txtDate" runat="server" ReadOnly="true"></asp:TextBox>
                                 <span class="input-group-text"><i class="bi bi-calendar-date"></i></span>

                         </div>

                     </div>
                 </div>
 
             </div>


             <div class="col-md-6">
                 <div class="d-grid gap-2">
                     <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
                 </div>
     
             </div>

     </div>
 </div>

</asp:Content>
