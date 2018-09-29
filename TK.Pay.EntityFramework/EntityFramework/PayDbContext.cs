using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using MySql.Data.Entity;
using TK.Pay.Authorization.Roles;
using TK.Pay.Authorization.Users;
using TK.Pay.Chat;
using TK.Pay.Friendships;
using TK.Pay.MultiTenancy;
using TK.Pay.Storage;

namespace TK.Pay.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PayDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public PayDbContext()
            : base("Default")
        {
            
        }

        public PayDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public PayDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public PayDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("TK_", null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
