#pragma warning disable ASPIREJAVASCRIPT001

var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddConnectionString("motivplan");

var api = builder.AddProject<Projects.MotivPlan_WebApi>("api")
    .WithReference(database);

builder.AddJavaScriptApp(
        "web",
        "../../frontend",
        runScriptName: "start")
    .WithHttpEndpoint(
        port: 4200,
        targetPort: 4200,
        isProxied: false)
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();