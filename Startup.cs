using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestMS.API.Interface;
using TestMS.API.Service;
using TestMS.Domain.Interface;
using TestMS.Infrastructure;

public class Startup
{
    private readonly IWebHostEnvironment _env;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen( s => 
        {
            s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "V1",
                Title = "TestMS"
            });
        });
        var key = "This is my key";
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        services.AddSingleton<IAuthentication>(new Authentication(key));
        // Dependency injection
        services.RegisterServices();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "TestMS v1"));

    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
}
}