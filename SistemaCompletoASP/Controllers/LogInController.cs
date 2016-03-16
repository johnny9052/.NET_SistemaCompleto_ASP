using SistemaCompletoASP.Contracts.Security;
using SistemaCompletoASP.DTO.Security;
using SistemaCompletoASP.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SistemaCompletoASP.Controllers
{
    public class LogInController : Controller
    {
        #region Variables

        /*Objeto que tiene definidos todas las funciones, y es igualada a la interfaz del contract*/
        /*Readonly establece que el objeto solo puede ser modificado en un constructor
         * o en su definicion, si se quisiera
         modificar dicho objeto fuera de esto no lo permitira*/
        private static readonly ILoginService ContractService = new LoginService();

        #endregion

        #region Login Methods


        
        public string  UserIdentify(String usu, String pass)
        {
            /*Se define el DTO (Clase que solo define datos, no funciones que lo diferencia del modelo)*/
            LoginDTO objDTO = new LoginDTO(usu, pass);
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.LoginUser(objDTO);
            /*Lista temporal que contendra la respuesta que se le dara al cliente*/
            IList<String> res = new List<String>();
            /*Se valida si la consulta SQL retorno valores*/
            if (info != null && info.Count() > 1)
            {
                /*Se crea variables de sesion*/
                //CreateUserSession(info);                
                res.Add("Success");
                res.Add(info.ElementAt(0));
                res.Add(info.ElementAt(1));
            }
            else
            {
                res.Add("Error");
            }

            var json = new JavaScriptSerializer().Serialize(new
            {
                res = res
            });

            return json;
            
        }


        /*Se crean variables de sesion a partir de lo retornado por la consulta SQL*/
        private void CreateUserSession(IEnumerable<String> info)
        {
            Session["USER_ID"] = info.ElementAt(0);
            Session["USER_NAME"] = info.ElementAt(1);
        }

        #endregion


        #region Logout Methods

        
        public string LogOut()
        {

            IList<String> res = new List<String>();
            /*Se valida si la consulta SQL retorno valores*/

            try
            {

                                
                res.Add("Success");

                var json = new JavaScriptSerializer().Serialize(new
                {
                    res = res
                });

                return json;
                
            }
            catch (Exception)            
            {
                res.Add("Success");
                var json = new JavaScriptSerializer().Serialize(new
                {
                    res = "Error"
                });

                return json;
            }
        }

        #endregion

    }
}