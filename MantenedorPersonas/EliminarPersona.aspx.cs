using Proyecto.BL;
using System;


namespace MantenedorPersonas
{
    public partial class EliminarPersona : System.Web.UI.Page
    {

        private PersonaBL logica = PersonaBL.Instance; // Obtener la instancia singleton

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            var rut_us = txtRutEliminar.Text;

            var response = logica.EliminarPersonaBL(rut_us);
            Response.Write($"<script>alert('{response}');</script>");
            txtRutEliminar.Text = "";

        }
    }
}