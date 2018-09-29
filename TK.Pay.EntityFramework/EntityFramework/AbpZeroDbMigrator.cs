using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;

namespace TK.Pay.EntityFramework
{
    public class AbpZeroDbMigrator : AbpZeroDbMigrator<PayDbContext, Migrations.Configuration>
    {
        public AbpZeroDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IIocResolver iocResolver) :
            base(
                unitOfWorkManager,
                connectionStringResolver,
                iocResolver)
        {

        }
    }
}
