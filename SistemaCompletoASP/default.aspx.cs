using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCompletoASP
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /*Si no se ha iniciado sesion, entonces se va a login*/
            if (Session.Count == 0)
            {
                Response.Redirect("~/LogIn.aspx");
            }       

        }
    }
}