

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel:  BaseViewModel
    {
        /// <summary>
        /// The display name of the chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from the chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show the picture profile background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// this is the RGB values (in hex) for the background color of the profile picture
        /// for example FF00FF for Red and blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if they are unread message in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if the item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
