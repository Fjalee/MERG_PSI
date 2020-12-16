using Autofac;
using System.Collections.Generic;

namespace WebScraper
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FormsLog>().As<ILog>();

            builder.RegisterType<AllScrapers>().AsSelf();
            builder.RegisterType<KampasScraper>().AsSelf();
            builder.RegisterType<DomosplusScraper>().AsSelf();
            builder.RegisterType<OutputToJson>().AsSelf();
            
            return builder.Build();
        }
    }
}
