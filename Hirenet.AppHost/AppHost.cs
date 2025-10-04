var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hirenet_AuthenticationService>("hirenet-authenticationservice");

builder.AddProject<Projects.Hirenet_Authenticate_API>("hirenet-authenticate-api");

builder.Build().Run();
