using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.ViewModels.System.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }

        public string Passwrod { get; set; }

        public bool RememberMe { get; set; }
    }
}
