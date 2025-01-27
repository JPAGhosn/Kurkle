using KRK_Auth.Bindings;
using KRK_Auth.Clients;
using KRK_Auth.Data;
using KRK_Auth.Endpoints;
using KRK_Auth.Extensions;
using KRK_Shared.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<KeycloakOptions>(builder.Configuration.GetSection("Services:Keycloak"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<KeycloakOptions>>().Value);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddWebCors();

// Keycloak HTTP service
builder.Services.AddHttpClient<KeycloakClient>();


var app = builder.Build();

app.UseWebCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapAuthEndpoints();

if (app.Environment.IsProduction()) app.UseHttpsRedirection();

UsersDbPreparation.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();