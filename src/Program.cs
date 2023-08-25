var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<ExternalServiceImpl>();
    serviceBuilder.AddServiceEndpoint<ExternalServiceImpl, DomainBellaNS.API.ExternalService.ExternalService>(new BasicHttpBinding(), "/ExternalService");
    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = false;
});

app.Run();