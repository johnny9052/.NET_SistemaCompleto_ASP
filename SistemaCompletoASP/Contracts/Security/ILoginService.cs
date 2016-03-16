using SistemaCompletoASP.DTO.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCompletoASP.Contracts.Security
{
    /*Contracto - INTERFAZ que obliga a definir el logIn*/
    interface ILoginService
    {
        IList<String> LoginUser(LoginDTO login);
    }
}
