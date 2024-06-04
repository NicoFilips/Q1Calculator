using Microsoft.AspNetCore.Components;
using MudBlazor;
using Q1Calculator.UI.Helpers;
using Q1Calculator.UI.HostBuilder;

namespace Q1Calculator.UI.Components.View;

public partial class Calculator : IDisposable
{
    [Inject]
    private IHttpClientFactory HttpClientFactory { get; set; } = null!;

    [Inject]
    private EvaluateService EvaluateService { get; set; } = null!;
    private async Task<string> PerformCall()
    {
        if (CalculationHelper.IsValidExpression(DisplayValue))
            return await EvaluateService.EvaluateAsync(DisplayValue);

        return "Invalid Expression";
    }

    private string DisplayValue { get; set; } = "0";
    private bool _isDarkMode = true;
    private MudTheme _theme = new();

    private void AppendNumber(int number)
    {
        DisplayValue += number.ToString();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DisplayValue = "0";
    }

    private void UpdateDisplay(string value)
    {
        if(DisplayValue == "0")
        {
            DisplayValue = value;
        }
        else
        {
            DisplayValue += value;
        }
    }

    private void HandleOperatorClicked(string operatorSymbol)
    {
        DisplayValue += " " + operatorSymbol + " ";
    }

    private void HandleBackspaceClicked(string operatorSymbol)
    {
        if (!string.IsNullOrEmpty(DisplayValue))
        {
            DisplayValue = DisplayValue.Substring(0, DisplayValue.Length - 1);
        }
    }

    private void HandleClearAllClicked()
    {
        DisplayValue = "0";
    }

    private async Task StateHasChangedAsync() => await InvokeAsync(StateHasChanged);


    private async Task HandleApiCall()
    {
        string result = await PerformCall();
        DisplayValue = result;
    }

    public void Dispose() => GC.SuppressFinalize(this);
}
