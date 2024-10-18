using CadastroUsuario.Domain.Interfaces.ApplicationServices;
using CadastroUsuario.Domain.Interfaces.Cookies;
using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Salts;
using CadastroUsuario.Domain.Interfaces.Repositories.MongoDB.Tokens;
using CadastroUsuario.Domain.Interfaces.Repositories.SqlServer;
using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models.MongoDBCollections.BCryptPersistence;
using CadastroUsuario.Domain.Models.MongoDBCollections.TokenPersistence;
using CadastroUsuario.Domain.Services;
using CadastroUsuario.Infra.API.Groups;
using CadastroUsuario.Infra.Authentication;
using CadastroUsuario.Infra.BCryptServices;
using CadastroUsuario.Infra.Context;
using CadastroUsuario.Infra.Cookies;
using CadastroUsuario.Infra.Repositories.MongoDb.SaltsDataPersistence;
using CadastroUsuario.Infra.Repositories.MongoDb.TokensDataPersistence;
using CadastroUsuario.Infra.Repositories.SqlServer;
using CadastroUsuario.Presentation.ApplicationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IEducationalBackgroundServices, EducationalBackgroundServices>();
builder.Services.AddScoped<IUserLockoutServices, UserLockoutServices>();
builder.Services.AddScoped<IProfilePicServices, ProfilePicServices>();

builder.Services.AddScoped<PasswordHashing>();

builder.Services.AddScoped<ISaltsRepository, SaltsRepository>();
builder.Services.AddScoped<ITokenRepository, TokensRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLockoutRepository, UserLockoutRepository>();
builder.Services.AddScoped<IEducationalBackgroundRepository, EducationalBackgroundRepository>();
builder.Services.AddScoped<IProfilePictureRepository, ProfilePicRepository>();

builder.Services.AddScoped<ICookieConfiguration, CookieConfiguration>();

builder.Services.AddScoped<CookieAuthServices>();

builder.Services.AddScoped<IUserApplicationServices, UserApplicationServices>();
builder.Services.AddScoped<IEducationalBackgroundApplicationServices, EducationalBackgroundApplicationServices>();
builder.Services.AddScoped<IProfilePicApplicationServices, ProfilePicApplicationServices>();
builder.Services.AddScoped<IIntermediateTokenApplicationServices, IntermediateTokenApplicationServices>();

builder.Services.AddSingleton<IAuthorizationHandler, MultipleSchemesHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<GroupsUsersAPI>();
builder.Services.AddScoped<SaltsRepository>();

var sqlServerConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(sqlServerConnection, sqlServerOptionsAction: sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(120),
            errorNumbersToAdd: null
            );
    }));

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("C:\\AspNet-DataProtection-keys"))
    .SetDefaultKeyLifetime(TimeSpan.FromDays(90))
    .SetApplicationName("CadastroUsuario");

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", o =>
    {
        o.Cookie.Name = "Token";
        o.ExpireTimeSpan = TimeSpan.FromDays(90);
        o.Cookie.HttpOnly = true;
        o.SlidingExpiration = true;
        o.Cookie.SameSite = SameSiteMode.None;
        o.Cookie.Domain = "localhost";
        o.Cookie.Path = "/";
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        o.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        o.DataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo("C:\\AspNet-DataProtection-keys"));
    });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();

BsonClassMap.RegisterClassMap<SaltsData>(salts =>
{
    salts.AutoMap();
    salts.MapIdProperty(s => s.Id)
        .SetIdGenerator(ObjectIdGenerator.Instance);
});

BsonClassMap.RegisterClassMap<TokenData>(token =>
{
    token.AutoMap();
    token.MapIdProperty(t => t.Id)
         .SetIdGenerator(ObjectIdGenerator.Instance);
});

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokensDatabase"));
builder.Services.Configure<SaltsSettings>(builder.Configuration.GetSection("SaltsDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .WithOrigins("https://localhost:5173", "https://localhost:7025")
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();