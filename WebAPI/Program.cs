using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extension;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDirectoryBrowser();

builder.Services.AddCors();

//Saðlayýcý Autofac sync. 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

//.net 7 için Configuration baþýna builder ekledik.
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


//Jwtbearer'ýn 6.0.14 kuruldu.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

//Birden fazla modül ekleyebilmek için kullanýyoruz.
builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Uploads/Images")),
    RequestPath = "/Uploads/Images",
    EnableDirectoryBrowsing = true
});




//Middleware - Sýrasýyla hangisi devreye gireceðini söylüyoruz. Araya giriyoruz.
app.UseAuthentication();
//----------
app.UseAuthorization();

app.MapControllers();

app.Run();
