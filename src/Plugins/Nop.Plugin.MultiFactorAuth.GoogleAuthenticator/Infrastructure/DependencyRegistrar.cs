using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Services;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<GoogleAuthenticatorService>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<CustomService>().As<ICustomAttributeService>().InstancePerLifetimeScope();

            //builder.RegisterType<CustomModelFactory>().As<ICustomModelFactory>().InstancePerLifetimeScope();
        }

        public int Order => 1;
    }
}
