using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// View model for a register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {

        #region public properties
        /// <summary>
        /// the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        #endregion


        #region Commands

        /// <summary>
        /// the command users login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// the command to register for new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public RegisterViewModel()
        {

            //Creating a command
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());

        }


        #endregion

        #region User Login Task Method
        /// <summary>
        /// Attempt to register the user in
        /// </summary>
        /// <param name="parameter">The securestring pass in from the view for the user password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            
            await RunCommandAsync(() => this.RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
            });
            

        }
        #endregion

        #region User Registeration Task Method
        /// <summary>
        /// Takes the user to login page 
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            //IOCContainer.Application.SideMenuVisible ^= true;
            //return;


            // go register page
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;

            IOCContainer.Application.GotToPage(ApplicationPage.Login);


            await Task.Delay(1);


        }
        #endregion
    }
}
