var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "привет от ИСП-231 Автор: Uyutov");

app.Run();
