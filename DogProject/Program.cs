using DogProject;
using DogProject.Clients;
using DogProject.Services;
using DogProject.Extensions;
using DogProject.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRestClient, RestClient>();
builder.Services.AddTransient<IIntegration, Integration>();
builder.Services.AddTransient<IDogClient, DogClient>();
builder.Services.AddTransient<IShowImageService, ShowImageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseInteraction();
app.UseRouting();
app.Run();
