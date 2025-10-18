using Aspire.Hosting;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);
var sqlBuilder = builder.AddSqlServer("hirenet-sql");
var authenDb = sqlBuilder.AddDatabase("AuthenDb");
var jobDb = sqlBuilder.AddDatabase("JobDb");
var walletDb = sqlBuilder.AddDatabase("WalletDb");


//var authenDbString = builder.AddConnectionString("AuthenDb");
//var jobDbString = builder.AddConnectionString("JobDb");

var authService = builder.AddProject<Projects.Hirenet_Authenticate_API>("hirenet-authenticate-api")
	//.WithReference(authenDbString)
	.WithReference(authenDb)
	.WaitFor(authenDb)
	.WithEndpoint("https", endpoint => endpoint.IsProxied = false);

var jobService = builder.AddProject<Projects.Hirenet_Job_API>("hirenet-job-api")
	.WithReference(jobDb)
	.WaitFor(jobDb)
		//.WithReference(jobDbString)
		//.WithExternalHttpEndpoints();
		.WithEndpoint("https", endpoint => endpoint.IsProxied = false);

builder.AddProject<Projects.Hirenet_Wallet_API>("hirenet-wallet-api")
	.WithReference(walletDb)
	.WaitFor(walletDb)
		//.WithExternalHttpEndpoints();
		.WithEndpoint("https", endpoint => endpoint.IsProxied = false);


builder.AddProject<Projects.Hirenet_Gateway>("hirenet-gateway")
	.WithReference(authService)
	.WithReference(jobService);



builder.Build().Run();
