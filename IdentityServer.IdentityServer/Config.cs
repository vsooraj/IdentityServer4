using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser{ SubjectId="1",Username="Sooraj", Password="password"},
                new TestUser{ SubjectId="2",Username="Jon", Password="password"}
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

            return new List<Client>
            {
                //Client Credetials based Grant Types
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
                },
           

                //Implicit Flow Grant Types           
                new Client
                {
                    ClientId="mvc",
                    ClientName="MVC Client",
                    AllowedGrantTypes=GrantTypes.Implicit,
                    RedirectUris={ "http://localhost:5003/signin-oidc" },
                    PostLogoutRedirectUris={ "http://localhost:5003/signout-callback-oidc" },

                    AllowedScopes= new List<string>
                    {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile

                    }

                }

            };
        }
    }
}