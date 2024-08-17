using ConsultorioSeguros.BLL;
using ConsultorioSeguros.DAL;
using Microsoft.AspNetCore.Cors;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Configure dependency injection
builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddScoped<IAseguradoService, AseguradoService>();
builder.Services.AddScoped<IAseguradoSeguroService, AseguradoSeguroService>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<IAseguradoRepository, AseguradoRepository>();
builder.Services.AddScoped<IAseguradoSeguroRepository, AseguradoSeguroRepository>();
builder.Services.AddScoped<FileValidatorService>();

// Configure database connection
builder.Services.AddSingleton<DatabaseContext>(sp =>
    new DatabaseContext(builder.Configuration.GetConnectionString("DefaultConnection")));

WebApplication app = builder.Build();

app.UseCors("AllowAnyOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();