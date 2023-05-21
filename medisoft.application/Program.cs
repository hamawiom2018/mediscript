using medisoft.application.models;
using medisoft.service;
using medisoft.service.IServices;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSpaStaticFiles(configuration =>
    {
        configuration.RootPath = "ClientApp/dist";
    });
    //recieve api key from appsettings.json as json string
    var apiKetGoogle= builder.Configuration.GetSection("GoogleAccount").Get<GoogleCredentials>();
string apiKey = Newtonsoft.Json.JsonConvert.SerializeObject(apiKetGoogle);
ITranscriptService transcriptService = new TranscriptService(apiKey);
builder.Services.AddSingleton<ITranscriptService>(transcriptService);
string bardApiKey = builder.Configuration.GetSection("BardApiKey").Value;
IBardService bardService = new BardService(bardApiKey);
builder.Services.AddSingleton<IBardService>(bardService);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}

app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
});


app.Run();