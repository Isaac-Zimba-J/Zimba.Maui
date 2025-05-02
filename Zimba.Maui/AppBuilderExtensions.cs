using Microsoft.Maui.Controls;
using System.Reflection;

namespace Zimba.Maui;

public static class AppBuilderExtensions
{
  /// <summary>
        /// Adds all Zimba.Maui controls to the application
        /// </summary>
        /// <param name="builder">The MauiAppBuilder instance</param>
        /// <returns>The MauiAppBuilder instance</returns>
        public static MauiAppBuilder UseZimbaMaui(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                // Register any custom handlers here if needed
            });

            // Register Resources
            RegisterResources();

            return builder;
        }

        private static void RegisterResources()
        {
            if (Application.Current == null)
                return;

            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            
            // Check if our resources are already registered
            if (mergedDictionaries.Any(d => d.GetType().Name == "Resources"))
                return;

            // Load resources from embedded resources
            var assembly = typeof(AppBuilderExtensions).Assembly;
            var resourceDictionary = new ResourceDictionary();

            // Load colors from embedded XAML
            var zimbaColors = new ResourceDictionary
            {
                Source = new Uri("Resources/Colors.xaml", UriKind.Relative)
            };
            resourceDictionary.MergedDictionaries.Add(zimbaColors);

            // Tag this as our dictionary for future reference
            resourceDictionary.Add("Resources", true);
            
            // Add to application resources
            mergedDictionaries.Add(resourceDictionary);
        }
    }


// Alternative approach using embedded resource files (if loading from URI doesn't work)
// Alternative implementation for RegisterResources method

/* 
private static void RegisterResources()
{
    if (Application.Current == null)
        return;

    var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
    
    // Check if our resources are already registered
    if (mergedDictionaries.Any(d => d.GetType().Name == "ZimbaResourceDictionary"))
        return;

    var resourceDictionary = new ResourceDictionary();
    
    // Define our colors directly in code
    // FAB colors
    resourceDictionary.Add("FabBackgroundColor", Color.FromArgb("#512BD4"));
    resourceDictionary.Add("FabTextColor", Colors.White);
    
    // Card colors
    resourceDictionary.Add("CardBackgroundColor", Colors.White);
    resourceDictionary.Add("CardBorderColor", Color.FromArgb("#E0E0E0"));
    resourceDictionary.Add("CardTitleBackgroundColor", Color.FromArgb("#F5F5F5"));
    resourceDictionary.Add("CardTitleTextColor", Color.FromArgb("#212121"));
    resourceDictionary.Add("CardFooterBackgroundColor", Color.FromArgb("#F5F5F5"));
    
    // Dark theme colors
    resourceDictionary.Add("CardBackgroundColorDark", Color.FromArgb("#2D2D2D"));
    resourceDictionary.Add("CardBorderColorDark", Color.FromArgb("#3F3F3F"));
    resourceDictionary.Add("CardTitleBackgroundColorDark", Color.FromArgb("#3F3F3F"));
    resourceDictionary.Add("CardTitleTextColorDark", Colors.White);
    resourceDictionary.Add("CardFooterBackgroundColorDark", Color.FromArgb("#3F3F3F"));
    
    // Tag this as our dictionary for future reference
    resourceDictionary.Add("ZimbaResourceDictionary", true);
    
    // Add to application resources
    mergedDictionaries.Add(resourceDictionary);
}
*/
