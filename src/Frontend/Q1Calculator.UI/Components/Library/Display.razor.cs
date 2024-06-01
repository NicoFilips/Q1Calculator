using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.Library;

public partial class Display : ComponentBase
{
    [Parameter]
    public string DisplayValue { get; set; }
}
