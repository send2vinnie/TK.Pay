using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace TK.Pay.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=Pay; Trusted_Connection=True;");
            csb["Database"].ShouldBe("Pay");
        }
    }
}
