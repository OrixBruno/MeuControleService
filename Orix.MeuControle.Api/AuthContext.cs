using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.Api
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("Data Source=bancoprojetos.mssql.somee.com;Initial Catalog=bancoprojetos;Persist Security Info=True;User ID=Aliorus_SQLLogin_1;Password=4ouegmr6y9")
        {

        }
    }
}