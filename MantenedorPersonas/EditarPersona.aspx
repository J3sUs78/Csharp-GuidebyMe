<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditarPersona.aspx.cs" Inherits="MantenedorPersonas.EditarPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Bootstrap -->
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <!-- Bootstrap -->
    <!-- Bootstrap DatePicker -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css"/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap DatePicker -->

</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="card text-center mt-3">
        <div class="card-header">
             <h5>Bienvenido, ya una vez creado algun registro de alguien, ya podras editarlo aqui...</h5>
            <br />
            <h6> Debes ingresar el rut y darle a obtener datos, para poder lllamar los datos de ese rut</h6>
        </div>

        <div class="card-body" >
            
                <div class="row g-3">
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label for="txtPrimerNombre">Primer Nombre:</label>
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
                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                    <asp:ListItem Value="M">Masculino</asp:ListItem>
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
                            <asp:Button ID="Button1" runat="server" Text="Obtener datos" CssClass="btn btn-secondary" OnClick="btnObtenerDatos_Click" />
                            <asp:Button ID="Button2" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
                    </div>
        
                </div>

        </div>
    </div>



<script type="text/javascript">
    $(function () {
        $('[id*=txtDate]').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd/mm/yyyy",
            language: "tr"
        });
    });
</script>

</asp:Content>
