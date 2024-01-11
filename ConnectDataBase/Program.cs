var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// HTML bien formateado con tabulaciones y saltos de línea
string htmlContent = @"
    <!DOCTYPE html>
    <html>
    <head>
        <title>Página de inicio</title>
    </head>
    <body>
        <h1>Título de la página</h1>
        <p>Este es un párrafo de ejemplo.</p>
    </body>
    </html>
";

app.MapGet("/", () => htmlContent);

app.Run();