using Hirenet.Wallet.Application;
using Hirenet.Wallet.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddKafkaConsumer<string, string>("hirenet-kafka", configureSettings: settings => {
	settings.Config.GroupId = "wallet-service-group";
	settings.Config.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();
app.Services.ApplyMigrations();
app.MapDefaultEndpoints();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.MapOpenApi();
	app.MapScalarApiReference();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
