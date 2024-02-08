using Proyecto.BL;
using System;
using System.Data;

namespace MantenedorPersonas
{
    public partial class VerPersonas : System.Web.UI.Page
    {
        private PersonaBL logica = PersonaBL.Instance; // Obtener la instancia singleton

        protected void Page_Load(object sender, EventArgs e)
        {
            GetGV();
        }

        private void GetGV()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Rut", typeof(string)), // Assuming 'Rut' is an integer in your database
                new DataColumn("Nombre1", typeof(string)), // Changed as per your database column name
                new DataColumn("Nombre2", typeof(string)), // Added additional names if present
                new DataColumn("Nombre3", typeof(string)),
                new DataColumn("ApellidoPaterno", typeof(string)), // Changed as per your database column name
                new DataColumn("ApellidoMaterno", typeof(string)),
                new DataColumn("FechaNacimiento", typeof(DateTime)), // Assuming 'FechaNacimiento' is a string
                new DataColumn("Genero", typeof(string)),
            });

            try
            {
                // Obtener los datos de la capa lógica
                logica.SendDataPersonas(dt);

                // Verificar si el DataTable tiene filas antes de asignarlo como DataSource
                if (dt.Rows.Count > 0)
                {
                    GVPersonas.DataSource = dt;
                }
                else
                {
                    // Si no hay filas, establecer el mensaje y el color de fondo
                    GVPersonas.BackColor = System.Drawing.Color.LightYellow;
                    lblMensaje.Text = "<h2>No hay columnas ya que no se ha insertado data a la bd</h2>";
                }
            }
            catch (Exception ex)
            {
                GVPersonas.BackColor = System.Drawing.Color.Pink;
                lblMensaje.Text = $"<h2>ERROR: {ex.Message}</h2>";
            }

            GVPersonas.DataBind();
        }

    }
}
