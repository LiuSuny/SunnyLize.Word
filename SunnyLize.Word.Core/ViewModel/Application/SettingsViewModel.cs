

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
        public TextEntryViewModel Username { get; set; }

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

            //TODO: Remove this with real information pulled out from our data base in the future
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Luke Rowland" };
            Username = new TextEntryViewModel { Label = "Usernname", OriginalText = "Luke" };
            Password = new TextEntryViewModel { Label = "Password", OriginalText = "*******" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "johndoe@gmail.com" };
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
