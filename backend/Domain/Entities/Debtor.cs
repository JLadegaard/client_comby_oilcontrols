using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
  public class Debtor : AuditableEntity
  {
    public int Id { get; set; }
    public ICollection<LocationDebtor> Locations { get; set; }
  }
}