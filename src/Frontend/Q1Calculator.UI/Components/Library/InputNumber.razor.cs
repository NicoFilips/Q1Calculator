using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.Library;

public partial class InputNumber : ComponentBase
{
    [Parameter]
    public int Number { get; set; }

    [Parameter]
    public EventCallback<int> OnNumberClick { get; set; }
}
