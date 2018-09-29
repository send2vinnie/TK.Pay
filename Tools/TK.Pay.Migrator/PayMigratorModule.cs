using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using TK.Pay.EntityFramework;

namespace TK.Pay.Migrator
{
    [DependsOn(typeof(PayDataModule))]
    public class PayMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<PayDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}