using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
  public class Refill : AuditableEntity
  {
    public int Id { get; set; }
    public Coupon Coupon { get; set; }
    public int CouponId { get; set; }
    public FuelType Type { get; set; }
    public double StartAmount { get; set; }
    public double EndAmount { get; set; }

    public double AmountDelivered { 
      get => EndAmount-StartAmount;
    }
    public TankState TankState { get; set; }
    public DateTime Date { get; set; }
    public Location Location { get; set; }
    public int LocationId { get; set; }
  }
}
