using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using React2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()

    //Konverterar siffrorna för min status
    // 0 = NotStarted
    // 1 = InProgress
    // 2 = Completed
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

builder.Services.AddOpenApi();

builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDbString"))
);

//Lägger till CORS stöd
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


var app = builder.Build();

//Aktiverr CORS
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
