using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Q1Calculator.UI.Components.View;
using Q1Calculator.UI.Helpers;
using Q1Calculator.UI.HostBuilder;

namespace Q1Calculator.UI.Components;

[UsedImplicitly]
public partial class Main : IDisposable
{
    private string DisplayValue { get; set; } = "0";

    public Type View { get; private set; } = typeof(Calculator);


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
