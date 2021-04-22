using Jour.Database;
using Microsoft.EntityFrameworkCore;

namespace Jour.UnitTest
{
    public class JourContextWrapper : JourContext
    {
        public JourContextWrapper(DbContextOptions<JourContext> options) : base(options)
        {
            base.Database.EnsureDeleted();
            base.Database.EnsureCreated();
        }
    }
}