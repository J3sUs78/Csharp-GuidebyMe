using System;

using Proyecto.BL;

namespace MantenedorPersonas
{
    public partial class Default : System.Web.UI.Page
    {
        private PersonaBL logica = PersonaBL.Instance; // Obtener la instancia singleton

        protected void Page_Load(object sender, EventArgs e)
        {
            // La instancia de logica ya está creada y disponible
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Parsear el puerto de forma segura
                int port;
                if(!int.TryParse(txtPort.Text, out port))
                {
                    //Mostrar mensaje error
                    Response.Write("<script>alert('El puerto debe ser un numero entero');</script>");
                }
                string response = logica.InsertarDataConexionBL(txtServer.Text, port.ToString(), txtUserId.Text, txtPassword.Text, txtDatabase.Text);

                // Muestra un mensaje de éxito
                Response.Write($"<script>alert('{response}');</script>");
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error
                Response.Write("<script>alert('Error al conectar: " + ex.Message + "');</script>");
            }
        }


        


        protected void btnProbarCone_Click(object sender, EventArgs e)
        {
            try
            {
                string response = logica.TestConnect();
                Response.Write($"<script>alert('{response}');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al conectar: " + ex.Message + "');</script>");
            }
        }
    }
}
