using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Dtos.Paycheck;
using Api.Mappers;
using Api.Mappers.Interfaces;
using Api.Models;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Api.Services;
using Api.Services.Deductions;
using Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee Benefit Cost Calculation Api",
        Description = "Api to support employee benefit cost calculations"
    });

    // produce swagger doc from xml comments
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var allowLocalhost = "allow localhost";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowLocalhost,
        policy => { policy.WithOrigins("http://localhost:3000", "http://localhost"); });
});

RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowLocalhost);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void RegisterServices(IServiceCollection services)
{
    services.AddSingleton<IMapper<Dependent, GetDependentDto>, DependentMapper>();
    services.AddSingleton<IMapper<Employee, GetEmployeeDto>, EmployeeMapper>();
    services.AddSingleton<IMapper<Deduction, GetDeductionDto>, DeductionMapper>();
    services.AddSingleton<IMapper<Paycheck, GetPaycheckDto>, PaycheckMapper>();

    // typically the persistence layer objects will be request scope - setting it for mock too even if not necessary
    services.AddScoped<IEmployeesRepository, EmployeesRepositoryMock>();
    services.AddScoped<IDependentsRepository, DependentsRepositoryMock>();

    services.AddScoped<IPaycheckService, PaycheckService>();

    services.AddSingleton<IDeductionCalculatorFactory, DeductionCalculatorFactory>();
    services.AddSingleton<IPaycheckCalculator, PaycheckCalculator>();
}