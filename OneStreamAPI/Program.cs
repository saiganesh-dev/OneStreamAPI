using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OneStreamAPI.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()   // Allow any origin
                   .AllowAnyMethod()   // Allow any HTTP method
                   .AllowAnyHeader();  // Allow any headers
        });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // Use the CORS policy

app.UseAuthorization();
app.MapControllers();
app.Run();
