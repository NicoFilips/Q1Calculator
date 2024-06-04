using Microsoft.AspNetCore.Components;

namespace Q1Calculator.UI.Components.Library;

public partial class Numpad : ComponentBase
{
    [Parameter]
    public EventCallback<string> OnDigitClicked { get; set; }

    [Parameter]
    public EventCallback<string> OnBackspaceClicked { get; set; }

    [Parameter]
    public string input { get; set; }

    [Parameter]
    public EventCallback<string> OnClearAllClicked { get; set; }
    private async Task ClearAllClicked()
    {
        await OnClearAllClicked.InvokeAsync();
    }

    private void AddDigit(string digit)
    {
        input += digit;
    }

    private async Task NumberClick(string number)
    {
        await OnDigitClicked.InvokeAsync(number);
    }

    private async Task BackspaceClick()
    {
        await OnBackspaceClicked.InvokeAsync();
    }

    private void Backspace()
    {
        if (input.Length > 0)
        {
            input = input.Substring(0, input.Length - 1);
        }
    }

}

