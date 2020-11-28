using Autofac;

namespace WebScraper
{
    public static class LogService
    {
        public static ILifetimeScope Scope { get; }

        static LogService()
        {
            var container = BuildContainer();
            var scope = container.BeginLifetimeScope();
            Scope = scope;
        }

        public static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            //containerBuilder.RegisterType<FileLog>().As<ILog>();
            containerBuilder.RegisterType<FormsLog>().As<ILog>();

            return containerBuilder.Build();
        }
    }
}
