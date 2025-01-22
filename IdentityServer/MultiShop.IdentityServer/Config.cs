﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        // ResourceCatalog resource'u catalogun program.cs'inde Audience ta belirttik.
        new ApiResource("ResourceCatalog")
        {
            Scopes={"CatalogFullPermission","CatalogReadPermission"}
        },
        new ApiResource("ResourceDiscount")
        {
            Scopes ={"DiscountFullPermission"}
        },
        new ApiResource("ResourceOrder")
        {
            Scopes ={"OrderFullPermission"}
        },
        new ApiResource("ResourceCargo")
        {
            Scopes={"CargoFullPermission"}
        },
        new ApiResource("ResourceBasket")
        {
            Scopes={"BasketFullPermission"}
        },
        new ApiResource("ResourceOcelot")
        {
            Scopes={"OcelotFullPermission"}
        },
        new ApiResource("ResourceComment")
        {
            Scopes={"CommentFullPermission"}
        },
        new ApiResource("ResourcePayment")
        {
            Scopes={ "PaymentFullPermission" }
        },
          new ApiResource("ResourceImage")
        {
            Scopes={ "ImageFullPermission" }
        },

        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
        new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
        new ApiScope("DiscountFullPermission","Full authority for discount operations"),
        new ApiScope("OrderFullPermission","Full authority for order operations"),
        new ApiScope("CargoFullPermission","Full authority for cargo operations"),
        new ApiScope("BasketFullPermission","Full authority for basket operations"),
        new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
        new ApiScope("CommentFullPermission","Full authority for comment operations"),
        new ApiScope("PaymentFullPermission","Full authority for payment operations"),
        new ApiScope("ImageFullPermission","Full authority for images operations"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };
    public static IEnumerable<Client> Clients => new Client[] {


        //Visitor
        new Client
        {
            ClientId="MultiShopVisitorId",
            ClientName="Multi Shop Visitor User",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes ={ "CatalogFullPermission", "CatalogReadPermission", "CargoFullPermission", "OcelotFullPermission", "CommentFullPermission", "CommentFullPermission", "ImageFullPermission" , "CommentFullPermission" }
        },

        //Manager
        new Client
        {
            ClientId="MultiShopManagerId",
            ClientName="Multi Shop Manager User",
            AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission",  "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImageFullPermission","OrderFullPermission",
            IdentityServerConstants.LocalApi.ScopeName,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile}
        },
        //Admin
        new Client
        {
            ClientId="MultiShopAdminId",
            ClientName ="Multi Shop Admin User",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
             ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImageFullPermission",
            IdentityServerConstants.LocalApi.ScopeName,
            IdentityServerConstants.StandardScopes.Email,
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile

            },
            AccessTokenLifetime=600
        }
    };

}
