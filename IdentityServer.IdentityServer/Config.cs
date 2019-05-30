using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer.IdentityServer
{
    public class Config
    {
        public static IEnumerable<TestUser> GetAllUsers()
        {
            return new List<TestUser>
            {
                new TestUser{ SubjectId="1",Username="Sooraj", Password="password123"},
                new TestUser{ SubjectId="2",Username="Jon", Password="password123"}
            };
        }
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("IdentityServerApi","Customer Api for Identity Server")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            //Client Credetials based Grant Types
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={ new Secret("secret".Sha256()) },
                    AllowedScopes={ "IdentityServerApi" }
                },
           

            //Resource Owner based Grant Types
           
                new Client
                {
                    ClientId="ro.client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={ new Secret("secret".Sha256()) },
                    AllowedScopes={ "IdentityServerApi" }
                }
            };
        }
    }
}