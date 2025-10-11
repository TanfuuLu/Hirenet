using Hirenet.Job.Infrastructure;
using Hirenet.Job.Application;
using Scalar.AspNetCore;
using Hirenet.Job.Infrastructure.Persistence;
var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDbContext<JobDbContext>("JobDb");
builder.AddServiceDefaults();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options => {
	options.AddPolicy("AllowAll", policy => {
		policy.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});
var app = builder.Build();
app.Services.ApplyMigrations();
app.MapDefaultEndpoints();

app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.MapScalarApiReference(options => {
		options.Title = "Hirenet Job API";
		options.AddDocument("/scalar/v1", "Hirenet Job API V1", "v1");
	}).AllowAnonymous();
	app.MapOpenApi();
}
else {
	app.MapOpenApi();
	app.MapScalarApiReference("scalar/v1", options => {
		options.WithTitle("Hirenet Job API");
		options.WithOpenApiRoutePattern("/openapi/v1.json");
	}).AllowAnonymous();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
