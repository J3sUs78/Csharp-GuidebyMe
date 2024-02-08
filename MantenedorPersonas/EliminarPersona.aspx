<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EliminarPersona.aspx.cs" Inherits="MantenedorPersonas.EliminarPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="card text-center mt-3">
    <div class="card-header">
      <h5>Eliminar Persona</h5>
    </div>

    <div class="card-body">

      <div class="row g-3">
        <div class="col-md-12">
          <div class="mb-3">
            <label for="txtRutEliminar">Ingrese el RUT de la persona a eliminar:</label>
            <asp:TextBox ID="txtRutEliminar" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
        </div>
                  <div class="d-grid gap-2">
          <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
        </div>
      </div>

    </div>
  </div>

</asp:Content>

