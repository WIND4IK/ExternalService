var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();


var app = builder.Build();
//app.UseHttpsRedirection();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<ExternalServiceImpl>();
    serviceBuilder.AddServiceEndpoint<ExternalServiceImpl, DomainBellaNS.API.ExternalService.ExternalService>(new BasicHttpBinding() , "/ExternalService");
    //serviceBuilder.AddServiceEndpoint<ExternalServiceImpl, DomainBellaNS.API.ExternalService.ExternalService>(new BasicHttpBinding { Security = { Mode = BasicHttpSecurityMode.Transport, Transport = { ClientCredentialType = HttpClientCredentialType.None}}}, "/ExternalService");
    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = true;
});
app.Run();