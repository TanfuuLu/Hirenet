using Hirenet.Contract.Application;
using Hirenet.Contract.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var uploadPath = @"E:\Hirenet\Hirenet\uploadsfile";
builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();

app.MapDefaultEndpoints();
app.Services.ApplyMigrations();

if (!Directory.Exists(uploadPath))
{
    Directory.CreateDirectory(uploadPath);
}

// Cho phép truy cập file tĩnh (file upload)
app.UseStaticFiles(new StaticFileOptions {
	FileProvider = new PhysicalFileProvider(uploadPath),
	RequestPath = "/uploadsfile"
});

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
