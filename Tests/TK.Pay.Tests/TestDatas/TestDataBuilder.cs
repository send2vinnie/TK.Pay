using EntityFramework.DynamicFilters;
using TK.Pay.EntityFramework;

namespace TK.Pay.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly PayDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(PayDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
