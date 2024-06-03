using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.Library;

public partial class CalculatorDisplay : ComponentBase
{
    [Parameter]
    public string Value { get; set; }

}
