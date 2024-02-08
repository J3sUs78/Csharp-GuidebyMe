using Proyecto.BL;
using System;

namespace MantenedorPersonas
{
    public partial class FInicioSesion : System.Web.UI.Page
    {
        private PersonaBL logica = PersonaBL.Instance; // Get singleton instance

        protected void Page_Load(object sender, EventArgs e)
        {
            // Handle potential postback scenarios by loading logged user state
            if (Page.IsPostBack)
            {
                var loggedUser = Session["LoggedUser"];
                if (loggedUser != null)
                {
                    
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var rut = txtRutUsuario.Text;
            var pass = txtPassword.Text;

            // Validate user credentials (replace with actual implementation)
            var authenticatedUser = logica.IngresarUsuario(rut, pass);

            if (authenticatedUser != null)
            {
                // Store authenticated user state in session
                Session["Logeado"] = authenticatedUser;

              

                // Redirect to appropriate landing page
                Response.Redirect("~/VerPersonas.aspx"); // Or other appropriate page
            }
            else
            {
                // Handle failed login attempt (e.g., display error message)
                Response.Write($"<script>alert('RUT o Password invalidos....');</script>");
            }
        }


    }
}
