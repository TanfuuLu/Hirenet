var builder = DistributedApplication.CreateBuilder(args);

var sqlBuilder = builder.AddSqlServer("HirenetSQL")
		.WithHostPort(3030)
		     .WithLifetime(ContainerLifetime.Persistent)
		     .WithDataVolume();

var authenDb = sqlBuilder.AddDatabase("AuthenDb");
builder.AddProject<Projects.Hirenet_Authenticate_API>("hirenet-authenticate-api")
	.WithReference(authenDb)
	.WaitFor(authenDb)
	.WithEndpoint("https", endpoint => endpoint.IsProxied = false);

builder.AddProject<Projects.Hirenet_Job_API>("hirenet-job-api");

builder.Build().Run();
