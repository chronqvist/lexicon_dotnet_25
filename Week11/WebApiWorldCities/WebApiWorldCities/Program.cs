using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using WebApiWorldCities.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebApiWorldCitiesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiWorldCitiesContext")
        ?? throw new InvalidOperationException("Connection string 'WebApiWorldCitiesContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "ASP.NET Core Web API with Swagger"
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty;
        c.DisplayRequestDuration();
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();

