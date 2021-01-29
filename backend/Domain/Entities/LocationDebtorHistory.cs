using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class LocationDebtorHistory : AuditableEntity 
    {
        LocationDebtorType Type { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int DebtorId { get; set; }
        public Debtor Debtor { get; set; }
    }
}