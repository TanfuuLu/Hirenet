using Aspire.Hosting;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var authenDbString = builder.AddConnectionString("AuthenDb");
var jobDbString = builder.AddConnectionString("JobDb");




var authService = builder.AddProject<Projects.Hirenet_Authenticate_API>("hirenet-authenticate-api")
	.WithReference(authenDbString)
	.WithExternalHttpEndpoints();

var jobService = builder.AddProject<Projects.Hirenet_Job_API>("hirenet-job-api")
	.WithReference(jobDbString)
	.WithExternalHttpEndpoints();

builder.AddProject<Projects.Hirenet_Gateway>("hirenet-gateway")
	.WithReference(authService)
	.WithReference(jobService)
	;

builder.Build().Run();
