using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;


namespace SunnyLize.Word.Core
{
    /// <summary>
    /// A view model for chat message thread list 
    /// </summary>
    public class ChatMessageListViewModel :BaseViewModel
    {
        /// <summary>
        /// The chat message list items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }


    }
}
