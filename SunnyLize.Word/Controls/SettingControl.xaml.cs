
using SunnyLize.Word.Core;
using System.Windows.Controls;


namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for SettingControl.xaml
    /// </summary>
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();

            //Set the data context to settings menu
            DataContext = IOCContainer.Settings;
        }
    }
}
