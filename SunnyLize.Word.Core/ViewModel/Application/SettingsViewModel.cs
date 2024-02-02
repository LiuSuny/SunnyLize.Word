

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
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// The user email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// Text for a logout button inside setting
        /// </summary>
        public string LogoutButtonText { get; set; }
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

        /// <summary>
        /// Command to logout setting menu out of application
        /// </summary>
        public ICommand LogoutSettingsCommand { get; set; }

        /// <summary>
        /// Command to clears user data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }
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
            LogoutSettingsCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);



            ////TODO: Remove this with real information pulled out from our data base in the future
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Luke Rowland" };
            Username = new TextEntryViewModel { Label = "Usernname", OriginalText = "Luke" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "johndoe@gmail.com" };

            //TODO : to get from localization
            LogoutButtonText = "Logout";
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

        /// <summary>
        /// Log the user out
        /// </summary>
        private void Logout()
        {
            //TODO: confirm the user wants to logout

            //TODO: we clear every user data/cache

            //Finally we clean all application level view models that contain
            //any information about the current user
            ClearUserData();

            //logout the user settings menu and move back to login page
            IOCContainer.Application.GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clear any user data specific  to the current user once they logout
        /// </summary>
        private void ClearUserData()
        {
            //Clear al view models containing the user info
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
        #endregion
    }
}
