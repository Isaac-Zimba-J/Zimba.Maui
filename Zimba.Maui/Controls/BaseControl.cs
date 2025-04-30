namespace Zimba.Maui.Controls;

public class BaseControl : ContentView
{
    /// <summary>
    /// Initializes a new instance of the BaseControl class
    /// </summary>
    public BaseControl()
    {
        // Initialize resources if they haven't been yet
        EnsureResourcesInitialized();
    }

    private static bool s_resourcesInitialized = false;
    private static readonly object s_resourceLock = new object();

    /// <summary>
    /// Ensures that the control library resources are initialized
    /// </summary>
    internal static void EnsureResourcesInitialized()
    {
        if (!s_resourcesInitialized)
        {
            lock (s_resourceLock)
            {
                if (!s_resourcesInitialized)
                {
                    // Load  XAML as a typed dictionary
                    var resourceDict = new ResourceDictionary();

                    resourceDict.MergedDictionaries.Add(new Zimba.Maui.Controls.Resources.Colors());


                    Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                    s_resourcesInitialized = true;
                }
            }
        }
    }

}
