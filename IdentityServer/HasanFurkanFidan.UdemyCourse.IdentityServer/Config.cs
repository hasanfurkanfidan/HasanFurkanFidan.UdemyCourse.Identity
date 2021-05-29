// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace HasanFurkanFidan.UdemyCourse.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes = {"catalog_fullpermission" } },
            new ApiResource("resource_photostock"){Scopes = {"photostock_fullpermission" } },
            new ApiResource("resource_basket"){Scopes = {"basket_fullpermission"}}
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource()
                       {
                           Name = "roles",
                           DisplayName = "roles",
                           Description = "Kullanıcı Rolleri",
                           UserClaims = new []{"role"}
                       }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
               new ApiScope("catalog_fullpermission","Catalog api için full erişim"),
               new ApiScope("photostock_fullpermission","Photo Stock api için full erişim"),
               new ApiScope("basket_fullpermission","Basket microsevice için full erişim"),
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
                  AllowedScopes = { "catalog_fullpermission", "photostock_fullpermission", IdentityServerConstants.LocalApi.ScopeName }
              },
                new Client
              {
                  ClientName="Asp.Net Core Mvc",
                  ClientId="WebMvcClientForUser",
                  ClientSecrets = {new Secret ("secret".Sha256()) },
                  AllowOfflineAccess = true,
                  AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                  AllowedScopes = {"basket_fullpermission", IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OfflineAccess,"roles"},
                  AccessTokenLifetime = 1*60*60,
                  RefreshTokenExpiration = TokenExpiration.Absolute,
                  AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                  RefreshTokenUsage = TokenUsage.ReUse
              }
                // interactive client using code flow + pkce
             
            };
    }
}