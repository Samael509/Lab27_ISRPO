var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "добро пожаловать на сервер!");

app.MapGet("/about", () => "это мой первый ASP.NET Core сервер");

app.MapGet("/time", () => $"время на сервере: {DateTime.Now}");

app.MapGet("/hello/{name}", (string name) => $"привет, {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"{a + b}");

app.Run();