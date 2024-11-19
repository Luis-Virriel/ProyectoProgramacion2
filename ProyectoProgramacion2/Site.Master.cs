using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoProgramacion2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage = Request.Url.AbsolutePath?.ToLower();
            if (currentPage.EndsWith("login.aspx"))
            {
                navbar.Visible = false;
            }
            else
            {
                navbar.Visible = true;
            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Login.aspx");
        }
       
    }
}