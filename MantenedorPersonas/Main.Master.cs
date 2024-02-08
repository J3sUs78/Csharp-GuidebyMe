using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MantenedorPersonas
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if a user is logged in
            bool isLoggedIn = (Session["Logeado"] != null);

            // Update visibility of menu items based on login status
            liRegister.Visible = !isLoggedIn; // Visible only if not logged in
            liVerPersonas.Visible = isLoggedIn;
            liEditar.Visible = isLoggedIn;
            liEliminar.Visible = isLoggedIn;
            liIniciarSesion.Visible = !isLoggedIn; // Visible only if not logged in
        }

    }
}