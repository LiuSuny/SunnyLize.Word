using SunnyLize.Word.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SunnyLize.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Customize startup so we can load our IOC container immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //We are allowing the base appliaction do what it need
            base.OnStartup(e);


            //Setup the main application
            ApplicationSetUp();


            ////Setup ioc
            //IOCContainer.SetUp();

            //Next we show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configure our application ready for use
        /// </summary>
        private void ApplicationSetUp()
        {
            ////Setup ioc
            IOCContainer.SetUp();

            //Bind the UI manager
            // IOCContainer.kernel.Bind<IUIManager>().ToSelf();

            IOCContainer.kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}
