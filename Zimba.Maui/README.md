# Zimba.Maui

A collection of reusable controls for .NET MAUI applications.

## Installation

Install the package via NuGet:

```
dotnet add package Zimba.Maui
```

Or search for "Zimba.Maui" in the NuGet Package Manager.

## Controls

### AddButton

A Floating Action Button (FAB) for .NET MAUI applications.

#### Usage

Add the namespace to your XAML:

```xml
xmlns:controls="clr-namespace:Zimba.Maui.Controls;assembly=Zimba.Maui.Controls"
```

Then use the control:

```xml
<controls:FAB
        Command="{Binding AddItemCommand}"
        BackgroundColor="Blue"
        Text="+" />
```

#### Properties

- `Text` - The text displayed on the button (default: "+")
- `BackgroundColor` - The background color of the button
- `Command` - The command to execute when the button is tapped
- `CommandParameter` - The parameter to pass to the command

## License

This project is licensed under the MIT License - see the LICENSE file for details.