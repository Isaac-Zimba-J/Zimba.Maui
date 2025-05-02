using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// namespace Zimba.Maui.Controls;

// /// <summary>
// /// A floating action button (FAB) .NET MAUI Applications
// /// </summary>
// ///
// /// 


// public partial class FAB : Button
// {
//     /// <summary>
//     /// Gets or sets the button icon text
//     /// </summary>

//     public new string Text
//     {
//         get => (string)GetValue(TextProperty);
//         set => SetValue(TextProperty, value);
//     }

//     /// <summary>
//     /// Gets or sets the background color of the button
//     /// </summary>
//     public new Color BackgroundColor
//     {
//         get => (Color)GetValue(BackgroundColorProperty);
//         set => SetValue(BackgroundColorProperty, value);
//     }

//     /// <summary>
//     /// Gets or sets the command to execute when the button is tapped
//     /// </summary>
//     public new ICommand Command
//     {
//         get => (ICommand)GetValue(CommandProperty);
//         set => SetValue(CommandProperty, value);
//     }

//     /// <summary>
//     /// Gets or sets the command parameter
//     /// </summary>
//     public new object CommandParameter
//     {
//         get => GetValue(CommandParameterProperty);
//         set => SetValue(CommandParameterProperty, value);
//     }

//     /// <summary>
//     /// Initializes a new instance of the AddButton class
//     /// </summary>
//     public FAB()
//     {
//         InitializeComponent();
//     }
// }

namespace Zimba.Maui.Controls
{
    public partial class FAB : Button
    {
        public FAB()
        {
            InitializeComponent();
        }
    }
}