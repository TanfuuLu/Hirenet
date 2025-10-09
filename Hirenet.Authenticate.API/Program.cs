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
builder.Services.AddCors(options => {
	options.AddPolicy("AllowAll", policy => {
		policy.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build(); app.UseCors("AllowAll");
app.Services.ApplyMigrations();
app.MapDefaultEndpoints();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.MapScalarApiReference("/scalar/v1").AllowAnonymous();
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
