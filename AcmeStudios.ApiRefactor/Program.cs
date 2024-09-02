using AcemStudios.ApiRefactor;
using AcemStudios.ApiRefactor.Data;
using AcmeStudios.ApiRefactor.DAL.Repository;
using AcmeStudios.ApiRefactor.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();

builder.Services.AddDbContext<StudioDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudioConnectionString")));

builder.Services.AddScoped<IStudioItemRepository, StudioItemRepository>();
builder.Services.AddScoped<IStudioItemService, StudioItemService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Studios API", Version = "V1" });
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Studios API V1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowMyOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();