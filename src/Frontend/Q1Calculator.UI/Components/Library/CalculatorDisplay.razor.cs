using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.Library;

public partial class CalculatorDisplay : ComponentBase
{
    [Parameter]
    public string DisplayValue { get; set; } = null!;

    [Parameter]
    public EventCallback OnEnterClicked { get; set; }

    private async Task EnterClicked()
    {
        await OnEnterClicked.InvokeAsync();
    }
}
