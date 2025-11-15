using eCommerce.ProductsService.DataAccessLayer;
using eCommerce.ProductsService.BusinessLogicLayer;
using FluentValidation.AspNetCore;
using eCommerce.ProductsMicroService.API.Middlewares;
using eCommerce.ProductsMicroService.API.APIEndpoints;

var builder = WebApplication.CreateBuilder(args);

// add DAL and BLL services
builder.Services.AddDataAccessLayer(builder.Configuration); // API only references BLL, but we can access DAL through BLL
builder.Services.AddDBusinessLogicLayer();

builder.Services.AddControllers();

// Fluent validations
builder.Services.AddFluentValidationAutoValidation();

// swagger
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();

// Cors
app.UseCors();

// swagger
app.UseSwagger();
app.UseSwaggerUI();

// Auth
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapProductAPIEndpoints();


app.Run();
