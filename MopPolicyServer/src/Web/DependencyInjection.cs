using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MopPolicyServer.Application.Common.Interfaces;
using MopPolicyServer.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Configuration;
using Microsoft.Extensions.DependencyInjection.Configuration.Authorization;
using Microsoft.OpenApi.Models;
using MopPolicyServer.Infrastructure.Data.Contexts;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var policyServerConfiguration = configuration.GetSection(nameof(PolicyServerConfiguration)).Get<PolicyServerConfiguration>();
        services.AddSingleton(policyServerConfiguration);
        
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddRazorPages();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = policyServerConfiguration.IdentityServerBaseUrl;
                options.RequireHttpsMetadata = policyServerConfiguration.RequireHttpsMetadata;
                options.Audience = policyServerConfiguration.OidcApiName;
            });

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(policyServerConfiguration.ApiVersion, new OpenApiInfo { Title = policyServerConfiguration.ApiName, Version = policyServerConfiguration.ApiVersion });
            // options.IncludeXmlComments(string.Format(@"{0}\CQRS.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
        
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{policyServerConfiguration.IdentityServerBaseUrl}/connect/authorize"),
                        TokenUrl = new Uri($"{policyServerConfiguration.IdentityServerBaseUrl}/connect/token"),
                        Scopes = new Dictionary<string, string> {
                            { policyServerConfiguration.OidcApiName, policyServerConfiguration.ApiName }
                        }
                    }
                }
            });
            
            options.OperationFilter<AuthorizeCheckOperationFilter>();
        });
        return services;
    }

    // public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
    // {
    //     var keyVaultUri = configuration["KeyVaultUri"];
    //     if (!string.IsNullOrWhiteSpace(keyVaultUri))
    //     {
    //         configuration.AddAzureKeyVault(
    //             new Uri(keyVaultUri),
    //             new DefaultAzureCredential())
    //             ;
    //     }
    //
    //     return services;
    // }
}
