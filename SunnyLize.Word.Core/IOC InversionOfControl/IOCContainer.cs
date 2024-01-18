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
            //Bindin =g to a single instance of Application view model
            kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());


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