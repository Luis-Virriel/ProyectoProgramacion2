using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ProyectoProgramacion2
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "ADMIN" && password == "ADMIN")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                var tecnico = Models.BaseDeDatos.Tecnicos
                    .Find(t => t.CI.Equals(username, StringComparison.OrdinalIgnoreCase));
                if (tecnico != null && tecnico.CI == password)
                {
                    Session["VariableUsuario"] = password;
                    
                    Response.Redirect("PaginaTecnicos.aspx");
                }
                else
                {
                    lblMessage.Text = "Usuario o contraseña incorrectos.";
                }
            }
        }
    }
}
