# BlazorNavigationAnimations

BlazorNavigationAnimations is a NuGet package that provides smooth navigation animations for Blazor applications. It enables slide-in and slide-out effects when navigating between pages, enhancing user experience.

## Features

- Supports all types of navigation: programmatic, hardware, software, links, Android, and iOS.
- Provides slide-in and slide-out animations for page transitions.
- Easy integration with Blazor applications.

## Installation

To install BlazorNavigationAnimations, add the package via NuGet:

```
dotnet add package BlazorNavigationAnimations
```

## Setup

### 1. Register the Service

Modify your `Program.cs` or `Startup.cs` to register the service:

```csharp
using BlazorNavigationAnimations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazorNavigationAnimations();
await builder.Build().RunAsync();
```

### 2. Use the Navigation Container

Wrap your content inside the `NavigationContainer` component:

```razor
@inject NavigationAnimationService NavigationAnimationService

<NavigationContainer>
    <Router AppAssembly="typeof(Program).Assembly" />
</NavigationContainer>
```

### 3. Add Required JavaScript

Include the following script in your `wwwroot/index.html` or `_Host.cshtml`:

```html
<script src="_content/BlazorNavigationAnimations/navigationHelper.js"></script>
```

### 4. Apply Animations with CSS

Add the following styles in your `wwwroot/css/site.css` or equivalent CSS file:

```css
@keyframes slideIn {
    from { transform: translateX(100%); opacity: 0; }
    to { transform: translateX(0); opacity: 1; }
}

@keyframes slideOut {
    from { transform: translateX(0); opacity: 1; }
    to { transform: translateX(-100%); opacity: 0; }
}

.slide-in { animation: slideIn 0.3s ease-out forwards; }
.slide-out { animation: slideOut 0.3s ease-in forwards; }
```

## Usage

To navigate with animation, use the `NavigationAnimationService`:
```

### In `MainLayout.razor`

```razor
@using BlazorNavigationAnimations.Components

<NavigationContainer>
    @Body
</NavigationContainer>
```

## License

This project is licensed under the MIT License.

## Author

Developed by Hasibul Islam.
