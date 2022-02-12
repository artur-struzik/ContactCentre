var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/contactcentre", () =>
{
    return "Hello from Contact Centre";
});

app.Run();