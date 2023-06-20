using Microsoft.EntityFrameworkCore;
using Sauraav_POE_CLDV.Models;
namespace Sauraav_POE_CLDV.Data
{
    public class ConnectDB: DbContext
    {
        public ConnectDB(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Locations> Locations { get; set; }
    }
}
