using System;
using Proyecto.BE;
using Proyecto.BL;

namespace MantenedorPersonas
{
    public partial class EditarPersona : System.Web.UI.Page
    {

        private PersonaBL logica = PersonaBL.Instance; // Obtener la instancia singleton

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void btnObtenerDatos_Click(object sender, EventArgs e)
        {
            string rut_input = txtRutUsuario.Text;

            try
            {
                // Llama al método BuscarPorRut para obtener los datos de la persona
                PersonaBE persona = logica.BuscarPorRut(rut_input);

                // Si se encuentra la persona, llena los campos de la vista
                if (persona != null)
                {

                    txtPrimerNombre.Text = persona.PrimerNombre;
                    TxtApPaterno.Text = persona.ApPaterno;
                    txtRutUsuario.Text = persona.Rut;
                    txtEdad.Text = persona.Edad.ToString();
                    txtSegundoNombre.Text = persona.SegundoNombre;
                    TxtApMaterno.Text = persona.ApMaterno;
                    txtTercerNombre.Text = persona.TercerNombre;
                    txtDate.Text = persona.FechaNacimiento.ToString();
                    RolListGenero.SelectedValue = persona.Genero.ToString();
                }
                else
                {
                    // Muestra un mensaje de error si no se encuentra la persona
                    Response.Write(string.Format("<script>alert('Persona no encontrada</script>"));
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                Response.Write(string.Format($"<script>alert('No se pudo buscar el usuario, ya que no hay una conexion echa...')</script>"));
            }
        }

        public void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                // Obtener los datos del formulario
                string primerNombre = txtPrimerNombre.Text;
                string apPaterno = TxtApPaterno.Text;
                string rutUsuario = txtRutUsuario.Text;
                string segundoNombre = txtSegundoNombre.Text;
                string apMaterno = TxtApMaterno.Text;
                string tercerNombre = txtTercerNombre.Text;
                int genero = Int32.Parse(RolListGenero.SelectedValue);
                string fechaNacimientoEnCadena = Request.Form[txtDate.UniqueID];


                //Si no hay errores... entonces vamos a usar nuestra logica para registrar una persona....mandamos los campos siempre y cuando no hayan errores, si hay un error no validado entonces igual lo dejara pasar
                var response = logica.EditarPersonaBL(rutUsuario, primerNombre, segundoNombre, tercerNombre, apPaterno, apMaterno, fechaNacimientoEnCadena, genero);

                Response.Write($"<script>alert('{response}');</script>");


                
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert(' Error al registrar...{ex.Message}');</script>");
            }
        }
    }
}