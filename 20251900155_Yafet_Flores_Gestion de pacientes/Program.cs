using _20251900155_Yafet_Flores_Gestion_de_pacientes.Features;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PacienteAppservice>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
