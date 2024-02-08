<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegistrarPersona.aspx.cs" Inherits="MantenedorPersonas.RegistrarPersona" %>
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
            <h5>Bienvenido, ya una vez establecida la conexión a la base de datos, entonces podrás registrarte...</h5>
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
                            <label for="txtPassword">Contraseña:</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingresa tu contraseña" 
                                    minlength="8" 
                                    data-toggle="tooltip" data-placement="top" title="La contraseña debe tener al menos 8 caracteres">
                                </asp:TextBox>
<%--                                <span class="input-group-text" id="togglePassword">
                                    <i class="bi bi-eye-slash"></i>
                                </span>--%>
                        </div>
                      <div class="mb-3">
                            <div class="btnRP d-grid gap-2">
                                 <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
                            </div>
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
