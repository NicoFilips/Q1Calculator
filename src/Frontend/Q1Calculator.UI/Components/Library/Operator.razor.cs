using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.Library;

public partial class Operator : ComponentBase
{
    [Parameter]
    public EventCallback<string> OnOperatorClicked { get; set; }

    private async Task OperatorClicked(string operatorSymbol)
    {
        await OnOperatorClicked.InvokeAsync(operatorSymbol);
    }

}
