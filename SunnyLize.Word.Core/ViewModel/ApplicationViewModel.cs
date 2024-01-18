

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
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login; //Once we change it ApplicationPage.Login our login animation will appear

        /// <summary>
        /// True if the side menu should be show or not
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;


    }
}
