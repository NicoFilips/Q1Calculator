using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.View;

public partial class Calculator : IDisposable
{
    private string DisplayValue { get; set; } = "";

    private void AppendNumber(int number)
    {
        DisplayValue += number.ToString();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DisplayValue = "0";
    }

    private async Task StateHasChangedAsync() => await InvokeAsync(StateHasChanged);



    private async Task PerformOperation(string operation)
    {
        //Todo add API Call
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
