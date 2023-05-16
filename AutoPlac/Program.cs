using Autofac;
using AutoPlac.Repozitorijumi.Context;
using AutoPlac.Repozitorijumi.Interfejsi;
using AutoPlac.Repozitorijumi.Repozitorijumi;
using AutoPlac.Servisi.Interfejsi;
using AutoPlac.Servisi.Servisi;

namespace AutoPlac
{
    internal static class Program
    {
        private static IContainer _container;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Build the dependency injection container
            var builder = new ContainerBuilder();
            builder.RegisterType<AutoPlacDBContext>().InstancePerLifetimeScope();
            builder.RegisterType<AutomobilServis>().As<IAutomobilServis>();
            builder.RegisterType<AutomobilRepozitorijum>().As<IAutomobilRepozitorijum>();
            builder.RegisterType<Form1>().As<Form>();
            // Register other dependencies here
            _container = builder.Build();

            // Resolve the main form from the container
            using (var form = _container.Resolve<Form>())
            {
                Application.Run(form);
            }

        }
    }
}