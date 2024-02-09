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

                //Log it
                IOCContainer.Logger.Log("This is debug...", LogLevel.Debug);
            //IOCContainer.Logger.Log("This is verbose...", LogLevel.Verbose);
            //IOCContainer.Logger.Log("This is informative...", LogLevel.Informative);
            //IOCContainer.Logger.Log("This is warning...", LogLevel.Warning);
            //IOCContainer.Logger.Log("This is error...", LogLevel.Error);
            //IOCContainer.Logger.Log("This is success...", LogLevel.Success);

            //IOCContainer.file.WriteAllTextToFileAsync("Some text", "test.txt");

            ////Setup ioc
            //IOCContainer.SetUp();

            //Adding our logger to file using task manager
            //IOCContainer.Task.Run(() =>
            //{
            //    throw new ArgumentNullException("ooops");
            //});


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

            //Bind a Logger
            IOCContainer.kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[] 
            {
                //TODO: Add ApplicationSettings so we can set/edit a log location

                //       for now we just log to the path where application is running
                new FileLogger("log.txt")
            }));

            //Add our task manager
            IOCContainer.kernel.Bind<ITaskManager>().ToConstant(new TaskManager());
            //Bind a file manager
            IOCContainer.kernel.Bind<IFileManager>().ToConstant(new FileManager());

            //Bind the UI manager
            // IOCContainer.kernel.Bind<IUIManager>().ToSelf();
            IOCContainer.kernel.Bind<IUIManager>().ToConstant(new UIManager());

        }
    }
}
