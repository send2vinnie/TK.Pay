using TK.Pay.EntityFramework;

namespace TK.Pay.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly PayDbContext _context;

        public InitialHostDbBuilder(PayDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
