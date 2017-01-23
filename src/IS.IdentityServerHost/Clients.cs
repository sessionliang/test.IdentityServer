using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.IdentityServerHost
{
    static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>() {
                new Client {
                    ClientName="dm.web",
                    ClientId="dm.web",
                    Enabled=true,
                    AccessTokenType = AccessTokenType.Reference, //引用令牌，不需要签名证书

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret> {
                        new Secret("f4189a35-1c49-474b-91d0-2110452cc9fc".Sha256())
                    },

                    AllowedScopes= new List<string> {
                        "api" //对应scope
                    }
                }
            };
        }
    }
}
