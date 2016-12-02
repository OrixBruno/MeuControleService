using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.ViewModels
{
    public class AuthorizationViewModel
    {
        public String grant_type { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String access_token { get; set; }
        public String token_type { get; set; }
        public String expires_in { get; set; }
    }
}