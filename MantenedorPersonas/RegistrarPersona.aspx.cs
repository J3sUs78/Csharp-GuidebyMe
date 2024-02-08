using System;
using Proyecto.BL;



namespace MantenedorPersonas
{
    public partial class RegistrarPersona : System.Web.UI.Page
    {

        private PersonaBL logica = PersonaBL.Instance; // Obtener la instancia singleton

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
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

            string contrasena = txtPassword.Text;

            if(contrasena.Length <= 3 )
            {
                Response.Write("<script>alert('La clave debe tener mas de 3 caracteres y menos de 20....');</script>");
            }


            string pass_result;
            byte[] msjEncriptado = System.Text.Encoding.Unicode.GetBytes(contrasena);
            pass_result = Convert.ToBase64String(msjEncriptado);

            //Si no hay errores... entonces vamos a usar nuestra logica para registrar una persona....mandamos los campos siempre y cuando no hayan errores, si hay un error no validado entonces igual lo dejara pasar
            var response = logica.RegistrarPersonaBL(rutUsuario, primerNombre, segundoNombre, tercerNombre, apPaterno, apMaterno, fechaNacimientoEnCadena, genero,pass_result);

            Response.Write(response);

 
                
            


        }




    }
}