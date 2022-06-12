using Api2.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args); 
var DefaultApi = builder.Configuration.GetValue<string>("Api1Url");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Cálculo do Juros API",
            Description = "Esta API é responsavel por retornar o valor do calculo do juros composto e de informar o link do repositório do código fonte da API.",
            Contact = new OpenApiContact() { Name = "Raul da Mata Esteves", Email = "raul.m.esteves@gmail.com" }
        });
    })
    .AddHttpClient<ITaxaJurosHttpClient, TaxaJurosHttpClient>(c =>
    {
        c.BaseAddress = new Uri(DefaultApi);
    });

builder.Services.AddScoped<ICalculaJurosService, CalculaJurosService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }
