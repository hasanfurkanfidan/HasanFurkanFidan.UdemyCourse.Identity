// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace HasanFurkanFidan.UdemyCourse.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes = {"catalog_fullpermission" } },
            new ApiResource("resource_photostock"){Scopes = {"photostock_fullpermission" } },

        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {

                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
               new ApiScope("catalog_fullpermission","Catalog api için full erişim"),
               new ApiScope("photosctock_fullpermission","Photo Stock api için full erişim"),
               new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
              new Client
              {
                  ClientName="Asp.Net Core Mvc",
                  ClientId="WebMvcClient",
                  ClientSecrets = {new Secret ("secret".Sha256()) },
                  AllowedGrantTypes = GrantTypes.ClientCredentials,
                  AllowedScopes = { "catalog_fullpermission", "photosctock_fullpermission",IdentityServerConstants.LocalApi.ScopeName }
              }

                // interactive client using code flow + pkce
             
            };
    }
}