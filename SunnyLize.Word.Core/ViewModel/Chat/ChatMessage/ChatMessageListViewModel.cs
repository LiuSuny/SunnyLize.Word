using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// A view model for chat message thread list 
    /// </summary>
    public class ChatMessageListViewModel :BaseViewModel
    {
        #region Public Property
        /// <summary>
        /// The chat message list items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }


        /// <summary>
        /// true to show the attached menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any popup menu is visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible; //pratically the same

        /// <summary>
        /// View model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }
      
        #endregion

        #region Public Command

        /// <summary>
        /// The command for when the attached button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked 
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// The command for when user clicked send command
        /// </summary>
        public ICommand SendCommand { get; set; }

        #endregion


        #region Constructors

        public ChatMessageListViewModel()
        {
            //We try to create command
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            PopupClickAwayCommand = new RelayCommand(PopupClickAway);

            SendCommand = new RelayCommand(Send);

            //Creating default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }
      
        #endregion

        #region Command method
        /// <summary>
        /// When the attachment button is clicked it show/hidden the attachement popup
        /// </summary>
        public void AttachmentButton()
        {
            //Toggle menu visible --- (^) this operator is boolean which toggle object to true or false
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// When the Popup Click Away  area is clicked, hidden any other popups
        /// </summary>
        public void PopupClickAway()
        {
           //Hide attachemnt menu
            AttachmentMenuVisible = false;
        }

        /// <summary>
        /// When the user Click send button message area is clicked
        /// </summary>
        public /*async*/ void Send()
        {


            //this UI independent as the core has no idea as we can invoke the UI function
            /* await*/
            IOCContainer.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Send Message",
                Message = "Thank you for writing a nice message :)",
                OkText = "OK"
            });

            //var ss = true;

        }

        #endregion
    }
}
