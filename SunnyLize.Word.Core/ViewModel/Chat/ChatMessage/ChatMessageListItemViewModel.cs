

using System;

namespace SunnyLize.Word.Core
{

    /// <summary>
    /// A view model for each chat message thread item in a chat thread
    /// </summary>
    public class ChatMessageListItemViewModel :BaseViewModel
    {
        /// <summary>
        /// The display name of sender of chat message
        /// </summary>
        public string SenderName { get; set; }

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
        /// True if the item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// True if this message is sent by the signed in user
        /// </summary>
        public bool SentByMe { get; set; }

        /// <summary>
        /// The time message was read or<see cref="DateTimeOffset.MaxValue"/> if not read
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }

        /// <summary>
        /// True if this message has been read
        /// </summary>
        public bool MessageRead => MessageReadTime > DateTimeOffset.MaxValue;

        /// <summary>
        /// The time message was sent
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }

    }
}
