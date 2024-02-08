<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="VerPersonas.aspx.cs" Inherits="MantenedorPersonas.VerPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="text-center mt-3 mx-auto">
    <asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" UpdateMode="Conditional" runat="server">
      <ContentTemplate>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>

        <asp:GridView ID="GVPersonas" AutoGenerateColumns="false" runat="server" CssClass="table-responsive">
          <HeaderStyle CssClass="thead-light" />  <Columns>
            <asp:BoundField HeaderText="Rut" DataField="Rut" />
            <asp:BoundField HeaderText="Primer Nombre" DataField="Nombre1" />
            <asp:BoundField HeaderText="Segundo Nombre" DataField="Nombre2" />
            <asp:BoundField HeaderText="Tercer  Nombre" DataField="Nombre3" />
            <asp:BoundField HeaderText="Apellido Paterno" DataField="ApellidoPaterno" />
            <asp:BoundField HeaderText="Apellido Materno" DataField="ApellidoMaterno" />
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
            <asp:BoundField HeaderText="Genero" DataField="Genero" />
          </Columns>
        </asp:GridView>
      </ContentTemplate>
    </asp:UpdatePanel>
  </div>
</asp:Content>

