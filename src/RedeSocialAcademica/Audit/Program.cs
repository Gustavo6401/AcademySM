using Audit.Domain.Interfaces.ApplicationServices;
using Audit.Domain.Interfaces.Repository;
using Audit.Domain.Interfaces.Services;
using Audit.Domain.Models;
using Audit.Domain.Services;
using Audit.Infra.Repositories;
using Audit.Presentation.ApplicationServices;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserActionRepository, UserActionRepository>();
builder.Services.AddScoped<IUserActionServices, UserActionServices>();
builder.Services.AddScoped<IUserActionApplicationServices, UserActionApplicationServices>();

BsonClassMap.RegisterClassMap<UserAction>(actions =>
{
    actions.AutoMap();
    actions.MapIdProperty(t => t.Id)
           .SetIdGenerator(ObjectIdGenerator.Instance);
});

builder.Services.Configure<UserActionSettings>(builder.Configuration.GetSection("AuditDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
