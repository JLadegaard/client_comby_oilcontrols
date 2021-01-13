using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
  public interface IApplicationDbContext
  {

    DbSet<Location> Locations { get; set; }
    DbSet<Coupon> Coupons { get; set; }
    DbSet<Truck> Trucks { get; set; }
    DbSet<Route> Routes { get; set; }
    DbSet<Domain.Entities.Refill> Refills { get; set; }
    DbSet<ExampleEntity> ExampleEntities { get; set; }
    DbSet<ExampleEntityList> ExampleEntityLists { get; set; }
    DbSet<TruckState> DailyTruckStates { get; set; }
    DbSet<TruckRefill> TruckRefills { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  }
}
