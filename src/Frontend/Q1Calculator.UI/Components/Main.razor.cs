using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Q1Calculator.UI.Components.View;

namespace Q1Calculator.UI.Components;

[UsedImplicitly]
public partial class Main : IDisposable
{
    private string DisplayValue { get; set; } = "";

    public Type View { get; private set; } = typeof(Calculator);

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

    public void SetView<T>()
    {
        View = typeof(T);
        StateHasChangedAsync();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SetView<Calculator>();
    }

    public void Dispose() => GC.SuppressFinalize(this);

    public new void InvokeAsync(Action action) => base.InvokeAsync(action);

    private async Task StateHasChangedAsync() => await base.InvokeAsync(StateHasChanged);
}
