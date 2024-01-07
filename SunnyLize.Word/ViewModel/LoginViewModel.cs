
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Input;
using System.Security;
using System.Threading.Tasks;


namespace SunnyLize.Word
{
    
    /// <summary>
    /// View model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
       
        #region public properties
        /// <summary>
        /// the email of the user
        /// </summary>
       public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
       public bool LoginIsRunning { get; set; }

        #endregion 

        
        #region Commands
        
        /// <summary>
        /// the command users login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public LoginViewModel()
        {
            
            //Creating a command
            LoginCommand = new RelayParameterizedCommand( async (parameter) => await Login(parameter)); 
           
        }

        #endregion

        #region User Login Task Method
        /// <summary>
        /// Attemt to log the user in
        /// </summary>
        /// <param name="parameter">The securestring pass in from the view for the user password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            //if (LoginIsRunning)
            //        return;

            // LoginIsRunning = true;
            await RunCommand(() =>this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = this.Email;

                //Note: Never store unsecure [password in variable like this
                var pass = (parameter as IHavePassword).SecurePassword.UnSecure();
            });
                //LoginIsRunning = false;

        }
        #endregion
    }
}
