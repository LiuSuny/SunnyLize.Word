

using System;

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
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login; //Once we change it ApplicationPage.Login our login animation will appear

        /// <summary>
        /// True if the side menu should be show or not
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// Method help us to navigate to specific page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <exception cref="NotImplementedException"></exception>
        public void GotToPage(ApplicationPage page)
        {
            //set the current page
            CurrentPage = page;

            //show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
