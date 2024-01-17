

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

    }
}
