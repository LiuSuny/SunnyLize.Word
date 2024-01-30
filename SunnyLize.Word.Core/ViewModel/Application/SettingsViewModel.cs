

using System;
using System.Windows.Input;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// The setting state of view model
    /// <summary>
    
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current user name
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// The current username
        /// </summary>
        public TextEntryViewModel Userame { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        public TextEntryViewModel Password { get; set; }

        /// <summary>
        /// The user email
        /// </summary>
        public TextEntryViewModel Email { get; set; }
        #endregion

        #region Public Command
        /// <summary>
        /// Command to close setting menu
        /// </summary>
        public ICommand CloseSettingsCommand { get; set; }


        /// <summary>
        /// Command to open setting menu
        /// </summary>
        public ICommand OpenSettingsCommand { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        public SettingsViewModel()
        {
            //CloseSettingsCommand = new RelayCommand(()=>Close());
            //CloseSettingsCommand = new RelayCommand(()=>Open());
            CloseSettingsCommand = new RelayCommand(Close);
            OpenSettingsCommand = new RelayCommand(Open);
        }
        #endregion

        #region Command Method
        /// <summary>
        /// close the settings menu
        /// </summary>
        private void Open()
        {
            //OpenSettingsCommand.Execute(null);


            //Open the settings menu
            IOCContainer.Application.SettingsMenuVisible = true;
        }

        /// <summary>
        /// close the settings menu
        /// </summary>
        private void Close()
        {
            //CloseSettingsCommand.Execute(null);

            //close the settings menu
            IOCContainer.Application.SettingsMenuVisible = false;
        }
        #endregion
    }
}
