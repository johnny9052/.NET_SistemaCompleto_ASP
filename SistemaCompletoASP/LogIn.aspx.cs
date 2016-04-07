using Newtonsoft.Json.Linq;
using SistemaCompletoASP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCompletoASP
{
    public partial class LogIn : System.Web.UI.Page
    {

        LogInController obj;


        protected void Page_Load(object sender, EventArgs e)
        {
            obj = new LogInController();

            /*Si no se ha iniciado sesion, entonces se va a login*/
            if (Session.Count > 0)
            {
                Response.Redirect("~");
            }
        }

        protected void ValidarUsuario(object sender, EventArgs e)
        {

            string usuario = txtUser.Text;
            string password = txtPassword.Text;


            string data = obj.UserIdentify(usu: usuario, pass: password);

            JObject o = JObject.Parse(data);
            JArray a = (JArray)o["res"];

            if (a[0].ToString() == "Success")
            {
                Session["USER_ID"] = a[1];
                Session["USER_NAME"] = a[2];
                Response.Redirect("~");
            }
            else
            {
                string script = "alert(\"El usuario no existe!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            
            

        }
    }
}