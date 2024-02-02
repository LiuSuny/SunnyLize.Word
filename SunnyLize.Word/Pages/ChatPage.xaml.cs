
using SunnyLize.Word.Core;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public ChatPage() :base()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// ctor with prameter
        /// </summary>
        /// <param name="specificViewModel"></param>

        public ChatPage(ChatMessageListViewModel specificViewModel = null) : base(specificViewModel)
        {
            InitializeComponent();

        }
    }
}
