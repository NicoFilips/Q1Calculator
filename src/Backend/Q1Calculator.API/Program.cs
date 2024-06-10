using Q1Calculator.API.Host.RequestLogging;
using Q1Calculator.Core.Abstraction;
using Q1Calculator.Core.Implementation;

namespace Q1Calculator.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<ICalculatorRepo, CalculatorRepo>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRequestLogging();

// -------------------- Endpunkte --------------------

        app.MapGet("/add", (float number1, float number2, ICalculatorRepo calculatorRepo) =>
            {
                float result = calculatorRepo.Add(number1, number2);
                return Results.Ok(result);
            })
           .WithOpenApi();

        app.MapGet("/subtract", (float number1, float number2, ICalculatorRepo calculatorRepo) =>
            {
                float result = calculatorRepo.Subtract(number1, number2);
                return Results.Ok(result);
            })
           .WithOpenApi();

        app.MapGet("/divide", (float number1, float number2, ICalculatorRepo calculatorRepo) =>
            {
                float result = calculatorRepo.Divide(number1, number2);
                return Results.Ok(result);
            })
           .WithOpenApi();

        app.MapGet("/multiply", (float number1, float number2, ICalculatorRepo calculatorRepo) =>
            {
                float result = calculatorRepo.Multiply(number1, number2);
                return Results.Ok(result);
            })
           .WithOpenApi();

        app.MapGet("/evaluate", (string calculation, ICalculatorRepo calculatorRepo) =>
            {
                float result = calculatorRepo.Evaluate(calculation);
                return Results.Ok(result);
            })
           .WithOpenApi();

// ----------------------------------------


        app.Run();
    }
}
