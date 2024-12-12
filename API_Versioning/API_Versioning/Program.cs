using API_Versioning.Context;
using API_Versioning.Interface;
using API_Versioning.Model;
using API_Versioning.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProductsDb"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;

    options.ApiVersionReader = ApiVersionReader.Combine(
       new QueryStringApiVersionReader("api-version"),
       new HeaderApiVersionReader("X-API-Version"),
       new MediaTypeApiVersionReader()
    );
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Version 1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "API Version 2", Version = "v2" });

    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Products.Add(new Product { Name = "Sample Product", Price = 10.99M });
    context.SaveChanges();
}
//app.UseMiddleware<ApiDeprecationMiddleware>();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Versioning v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "API Versioning v2");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
