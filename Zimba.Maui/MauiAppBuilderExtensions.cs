using Zimba.Maui.Controls;

namespace Zimba.Maui;

public static class MauiAppBuilderExtensions
{
    /// <summary>
    /// Adds all Zimba.Maui to the application
    /// </summary>
    /// <param name="builder">The MauiAppBuilder instance</param>
    /// <returns>The MauiAppBuilder instance</returns>
    public static MauiAppBuilder UseZimbaMaui(this MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers(handlers =>
        {
            // Register any custom handlers here in the future if needed
        });

        // Initialize resources
        BaseControl.EnsureResourcesInitialized();

        return builder;
    }
}