﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {

        public static IEnumerable<IdentityResource> Ids =>
             new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string>{"role"}
                }
                
            };

        public static IEnumerable<ApiResource> Apis =>
        new List<ApiResource>
        {
            new ApiResource("Api", "Api Services"),
            new ApiResource("ApiExterne", "Api Externes"),
        };

        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            // interactive ASP.NET Core MVC client
            new Client
            {
                ClientId = "CoronaOutWeb",
                ClientName = "CoronaOutWeb",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                RequireConsent = false,
                RequirePkce = true,

                // where to redirect to after login
                RedirectUris = { "http://localhost:5000/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "http://localhost:5000/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "Api",
                    "ApiExterne"

                },
                AllowOfflineAccess = true
            }

        };
    }
}