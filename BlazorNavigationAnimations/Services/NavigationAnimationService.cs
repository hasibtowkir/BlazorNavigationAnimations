using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace BlazorNavigationAnimations.Services;

public class NavigationAnimationService : IDisposable
{
    private readonly NavigationManager _navigationManager;
    private readonly IJSRuntime _jsRuntime;
    public event Action? OnSlideOut;
    public event Action? OnSlideIn;

    public NavigationAnimationService(NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        _navigationManager = navigationManager;
        _jsRuntime = jsRuntime;
        _navigationManager.LocationChanged += OnLocationChanged;
    }

    private async void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        OnSlideOut?.Invoke();
        await Task.Delay(300);
        OnSlideIn?.Invoke();
    }

    public async Task NavigateWithAnimation(string url)
    {
        OnSlideOut?.Invoke();
        await Task.Delay(300);
        _navigationManager.NavigateTo(url);
    }

    public async Task InitializeJS()
    {
        await _jsRuntime.InvokeVoidAsync("navigationHelper.initialize");
    }

    public void Dispose()
    {
        _navigationManager.LocationChanged -= OnLocationChanged;
    }
}