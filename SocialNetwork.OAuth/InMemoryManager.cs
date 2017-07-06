using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Services.InMemory;
using IdentityServer3.Core.Models;
using IdentityServer3.Core;
using System.Security.Claims;

namespace SocialNetwork.OAuth
{
    public class InMemoryManager
    {

        public List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "mail@filipekberg ",
                    Username = "mail@filipekberg.se",
                    Password= "password",
                    Claims = new []
                    {
                        new Claim(Constants.ClaimTypes.Name, "Filip Ekberg")
                    }
                }
            };
        }

        public IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "read",
                    DisplayName = "read user data"
                }
            };
        }

        public IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "SocialNetwork",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName = "SocialNetwork",
                    Flow = Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read "
                    },
                    Enabled = true 
                }
            };
        }
    }
}