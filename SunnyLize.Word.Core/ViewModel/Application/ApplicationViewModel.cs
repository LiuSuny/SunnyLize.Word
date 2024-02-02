

using System;
using System.Globalization;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// Our application state of view model
    /// <summary>
    
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page login appliaction
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat; //Once we change it ApplicationPage.Login our login animation will appear


        /// <summary>
        /// The view model to use for the current page when the current page changes
        /// NOTE: this is not a live  up-date  view model of the current page
        /// It is simply to used to set the view model of the current page at the time of changes 
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be show or not
        /// </summary>
        public bool SideMenuVisible { get; set; } = true; //false to login and chat message


        /// <summary>
        /// True if the setting menu should be show or not
        /// </summary>
        public bool SettingsMenuVisible { get; set; } 


        /// <summary>
        /// Method help us to navigate to specific page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicity t the  new page</param>
        /// <exception cref="NotImplementedException"></exception>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            //Alway hide the setting page if we are changing pages
            SettingsMenuVisible = false;

            //set the view model
            CurrentPageViewModel = viewModel;

            
            //set the current page
            CurrentPage = page;

            //Fire off a current page  changed event
            OnPropertyChanged(nameof(CurrentPage));

            //show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
