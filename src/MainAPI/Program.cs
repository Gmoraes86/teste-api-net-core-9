using Microsoft.EntityFrameworkCore;
using MainAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true; 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseResponseCaching(); 
app.UseCors("AllowSpecificOrigins");



app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(60) 
        };
    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

app.MapHealthChecks("/health");
app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
