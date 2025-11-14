using eCommerce.ProductsService.DataAccessLayer;
using eCommerce.ProductsService.BusinessLogicLayer;
using FluentValidation.AspNetCore;
using eCommerce.ProductsMicroService.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// add DAL and BLL services
builder.Services.AddDataAccessLayer(builder.Configuration); // API only references BLL, but we can access DAL through BLL
builder.Services.AddDBusinessLogicLayer();

builder.Services.AddControllers();

// Fluent validations
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
