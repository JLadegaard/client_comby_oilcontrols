using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
  public class Location : AuditableEntity
  {
    public int Id { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }
    public FuelTank FuelTank { get; set; }
    public int FuelTankId { get; set; }
    public RefillSchedule Schedule { get; set; }
    public string Address { get; set; }
    public string Comments { get; set; }
    public double EstimateFuelConsumption { get; set; }
    public ICollection<Refill> Refills { get; set; }
  }
}
