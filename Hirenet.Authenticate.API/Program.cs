using Hirenet.Authenticate.Application;
using Hirenet.Authenticate.Infrastructure;
using Hirenet.Authenticate.Infrastructure.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDbContext<AuthenticateDbContext>("AuthenDb");
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.Services.ApplyMigrations();
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
