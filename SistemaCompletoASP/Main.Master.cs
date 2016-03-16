using Newtonsoft.Json.Linq;
using SistemaCompletoASP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaCompletoASP
{
    public partial class Main : System.Web.UI.MasterPage
    {

        LogInController obj;

        protected void Page_Load(object sender, EventArgs e)
        {

            obj = new LogInController();

            
            /*Si no se ha iniciado sesion, entonces se va a login*/
            if (Session.Count == 0)
            {                
                Response.Redirect("View/LogIn.aspx");
            }            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            string data = obj.LogOut();

            JObject o = JObject.Parse(data);
            string res = o.GetValue("res")[0].ToString();

            if (res == "Success")
            {

                /*Cancela la sesion actual*/
                Session.Abandon();
                /*Destruye variables de sesion*/
                Session.RemoveAll();


                Response.Redirect("~");
            }

        }
    }
}