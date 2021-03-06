using System;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Infrastructure.Services.Contracts;
using FoodSupplementsSystem.Infrastructure.Caching;
using FoodSupplementsSystem.Infrastructure.Populators;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FoodSupplementsSystem.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FoodSupplementsSystem.App_Start.NinjectWebCommon), "Stop")]

namespace FoodSupplementsSystem.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IFoodSupplementsSystemDbContext)).To(typeof(FoodSupplementsSystemDbContext)).InRequestScope();

            kernel.Bind(typeof(IEfGenericRepository<>)).To(typeof(EfGenericRepository<>));

            kernel.Bind(b => b.From("FoodSupplementsSystem.Services.Data")
                              .SelectAllClasses()
                              .BindDefaultInterface());

            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<ICacheService>().To<InMemoryCache>();

            kernel.Bind<IDropDownListPopulator>().To<DropDownListPopulator>();
        }
    }
}
