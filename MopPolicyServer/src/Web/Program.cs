using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MopPolicyServer.Infrastructure.Data;
using MopPolicyServer.Infrastructure.Data.Contexts.ContextInitializers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger(c => { });

app.UseSwaggerUI(c =>
{
    var policyServerConfiguration = (PolicyServerConfiguration)app.Services.GetService(typeof(PolicyServerConfiguration))!;
    c.SwaggerEndpoint($"{policyServerConfiguration.ApiBaseUrl}/swagger/v1/swagger.json", policyServerConfiguration.ApiName);
    c.OAuthClientId(policyServerConfiguration.OidcSwaggerUIClientId);
    c.OAuthAppName(policyServerConfiguration.ApiName);
    c.OAuthUsePkce();
    
    

});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });


app.MapEndpoints();

app.Run();

public partial class Program
{
}
