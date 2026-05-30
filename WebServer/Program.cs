var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => {
    var method = context.Request.Method;
    var path = context.Request.Path;
    Console.WriteLine($"-> {method} {path}");
    await next(context);
});

app.MapGet("/", () => Results.Ok(new {
    Message = "добро пожаловать!",
    Version = "1.0",
    Time = DateTime.Now.ToString("HH:mm:ss")
}));

app.MapGet("/me", () => Results.Ok(new {
    Name = "Uyutov",
    Group = "ИСП-234",
    Course = 3,
    Skills = new[] { "C#", "HTML", "CSS", "JS", "ASP.NET" }
}));

app.MapGet("/calc/{a}/{b}", (double a, double b) => Results.Ok(new {
    A = a,
    B = b,
    Sum = a + b,
    Diff = a - b,
    Mul = a * b,
    Div = b != 0 ? a / b : 0
}));

app.MapFallback(() => Results.NotFound(new {
    Error = "маршрут не найден",
    Code = 404
}));

app.Run();

// record Product(int Id, string Name, decimal Price, bool InStock);