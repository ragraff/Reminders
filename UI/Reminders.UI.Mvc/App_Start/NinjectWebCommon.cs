using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.Mvc;
using Reminders.Data.Repository.Interfaces;
using Reminders.Data.Repository.SqlServer;
using Reminders.Models.Domain;
using Reminders.UI.Mvc;
using Serilog;
using Serilog.Sinks.RollingFileAlternate;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Reminders.UI.Mvc
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            var ninjectResolver = new NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(ninjectResolver); //MVC

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IBindingRoot kernel)
        {
            kernel.Bind<ILogger>()
                .ToMethod(x => new LoggerConfiguration()
                    .WriteTo.RollingFileAlternate(@"C:\Reminders.log")
                    .CreateLogger());

            ServiceModule(kernel);
            RepositoryModule(kernel);
        }

        private static void RepositoryModule(IBindingRoot kernel)
        {
            const string connectionString = "YOUR CONNECTION STRING HERE";    
            throw new NotImplementedException("Don't forget to put in your connection string.");
            kernel
                .Bind<IDbConnection>()
                .To<SqlConnection>()
                .WithConstructorArgument("connectionString", connectionString);

            kernel.Bind<IRepository<Reminder>>().To<Repository<Reminder>>();
            kernel.Bind<ISqlProvider>().To<SqlProvider>();
            kernel.Bind<ISqlMapperWrapper>().To<SqlMapperWrapper>();
            kernel.Bind<ISqlHelper<Reminder>>().To<ReminderSqlHelper>();
        }

        private static void ServiceModule(IBindingRoot kernel) { }
    }
}