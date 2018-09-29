using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using TK.Pay.EntityFramework;

namespace TK.Pay
{
    /// <summary>
    /// Entity framework module of the application.
    /// </summary>
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(PayCoreModule))]
    public class PayDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PayDbContext>());

            //web.config (or app.config for non-web projects) file should contain a connection string named "Default".
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
