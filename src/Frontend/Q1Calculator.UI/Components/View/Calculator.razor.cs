using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.View;

public partial class Calculator : ComponentBase, IDisposable
{
    private string DisplayValue { get; set; } = "";

    private void AppendNumber(int number)
    {
        DisplayValue += number.ToString();
    }

    private async Task PerformOperation(string operation)
    {
        // Implement logic to call REST API with the current numbers and the selected operation
        // For demonstration purposes, this is a placeholder
        var result = await CallApi(DisplayValue, operation);
        DisplayValue = result.ToString();
    }

    private Task<double> CallApi(string expression, string operation)
    {
        // Call your REST API here
        // This is just a placeholder for the actual API call
        return Task.FromResult(0.0);
    }

    public void Dispose() => GC.SuppressFinalize(this);
}
