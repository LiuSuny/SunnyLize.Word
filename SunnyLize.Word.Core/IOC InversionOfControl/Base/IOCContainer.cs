using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// The Ioc container for our application
    /// </summary>
    public static class IOCContainer
    {
        #region public property
        /// <summary>
        /// The kernel for our ioc container
        /// Kernel is where we get and bind the whole of our application with Ninject--
        /// Note: we already install Ninject on our appliacation before this time
        /// </summary>
        public static IKernel kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// shortcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IOCContainer.Get<IUIManager>(); //just a sort of shortcut to reach the IUIManager


        /// <summary>
        /// shortcut to access the <see cref="ILogFactory"/>
        /// </summary>
        public static ILogFactory Logger => IOCContainer.Get<ILogFactory>(); //just a sort of shortcut to reach the IUIManager


        /// <summary>
        /// shortcut to access the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager file => IOCContainer.Get<IFileManager>(); //just a sort of shortcut to reach the IFileManager

        /// <summary>
        /// shortcut to access the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager Task => IOCContainer.Get<ITaskManager>(); //just a sort of shortcut to reach the IUIManager

        /// <summary>
        /// shortcut allow us access for shortcut the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => IOCContainer.Get<ApplicationViewModel>();  //just a sort of shortcut to reach the ApplicationViewModel

        /// <summary>
        /// shortcut allow us access for shortcut the <see cref="SettingsViewModel"/>
        /// </summary>
        public static SettingsViewModel Settings => IOCContainer.Get<SettingsViewModel>();  //just a sort of shortcut to reach the IUIManager

        #endregion


        #region Construction
        /// <summary>
        /// Seting up our ioc Container, binding all information require and is ready for us
        /// Note: THIS MUST BE CALL AS SOON AS OUR APPLICATION START UP To ensure all service can be find
        /// </summary>
        public static void SetUp()
        {
            //Binding all the require view models
            BindViewModels();
        }

        /// <summary>
        /// Bind all the singleton view models
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void BindViewModels()
        {
            //Binding to a single instance of Application view model
            kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            //Binding to a single instance of settings view model
            kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel()); 


            //kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope(); //meaning creating a single instance of this class ApplicationViewModels

            //kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel { CurrentPage = ApplicationPage.Register }); //another way of initating our instance of our class incase our app require changes etc
        }
        #endregion

        /// <summary>
        /// Get a service  from the ioc with specified type - Ctr+dot helper function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}