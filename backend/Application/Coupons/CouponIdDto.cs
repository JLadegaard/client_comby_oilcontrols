using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Coupons.Queries.GetCoupons
{
  public class CouponIdDto : IAutoMap<Coupon>
  {
    public int Id { get; set; }

    public void Mapping(Profile profile)
    {
      profile.CreateMap<Coupon, CouponIdDto>()
        .IncludeBase<Coupon, CouponDto>()
      ;
    }
  }
}
