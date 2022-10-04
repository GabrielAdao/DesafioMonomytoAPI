using DesafioAPI.Context;
using DesafioAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using DesafioAPI.Controllers;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("AppDb");

var URI = "https://firebasestorage.googleapis.com/v0/b/testemonomytobackend/o/Clientes.json?alt=media&token=2fb4fc55-5299-4dfc-9059-d2ddb4ec67ab";

var app = builder.Build();

app.MapGet("/ListarClientes", () =>
{
    var t = Task.Run(() => ClientesController.GetAllUsers(new Uri(URI)));
    t.Wait();
    return Task.FromResult(t.Result);

});

app.MapGet("/ListarClientesNome/{nome}", (string nome) =>
{
    var t = Task.Run(() => ClientesController.GetUserByNome(new Uri(URI), nome));
    t.Wait();

    return Task.FromResult(t.Result);
    
});

app.MapGet("/ListarClientesId/{id}", (string id) =>
{
    var t = Task.Run(() => ClientesController.GetUserById(new Uri(URI), id));
    t.Wait();

    return Task.FromResult(t.Result);

});

app.Run();
