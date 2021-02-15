using Application.Common.Interfaces.Pagination;
using Application.LocationHistories.Queries;
using Application.LocationHistories.Queries.GetAllLocationHistories;
using Application.Locations;
using Application.Locations.Commands.AddDebtorToLocation;
using Application.Locations.Commands.AddLocationImage;
using Application.Locations.Commands.CreateLocation;
using Application.Locations.Commands.RemoveDebtorFromLocation;
using Application.Locations.Commands.UpdateDebtorOnLocation;
using Application.Locations.Commands.UpdateLocationMetaData;
using Application.Locations.Queries.GetDebtorHistory;
using Application.Locations.Queries.GetDebtors;
using Application.Locations.Queries.GetLocationImage;
using Application.Refills;
using Application.Refills.Queries;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
  public class LocationController : ApiControllerBase
  {
    [HttpPost]
    public async Task<ActionResult<int>> AddNewLocation(CreateLocationCommand command)
    {
      return await Mediator.Send(command);
    }

    [HttpPost("addDebtor")]
    public async Task<ActionResult<int>> AddDebtor(AddDebtorToLocationCommand command)
    {
      return await Mediator.Send(command);
    }

    [HttpPut("updateDebtor")]
    public async Task<ActionResult<int>> UpdateDebtor(UpdateDebtorOnLocationCommand command)
    {
      return await Mediator.Send(command);
    }

    [HttpPut("removeDebtor")]
    public async Task<ActionResult<int>> RemoveDebtor(RemoveDebtorFromLocationCommand command)
    {
      return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PageResult<LocationDetailsIdDto, DateTime>>> GetAll(
    [FromQuery] TankType? locationType,
    [FromQuery] DateTime? needle = null, [FromQuery] int size = 1000, [FromQuery] int? skip = 0)
    {
      if (!needle.HasValue)
      {
        needle = DateTime.MaxValue;
      }

      return await Mediator.Send(new GetDebtorsQuery
      {
        TankType = locationType,
        Needle = (DateTime)needle,
        Size = size,
        Skip = skip
      });
    }

    // [HttpGet("/histories")]
    // public async Task<ActionResult<PageResult<LocationHistoryDto>>> GetAllLocationHistories(
    //  [FromQuery] int needle, [FromQuery] int size = 1000, [FromQuery] int? skip = 0
    // )
    // {
    //   return await Mediator.Send(new GetAllLocationHistoriesQuery
    //   {
    //     Needle = needle,
    //     Size = size,
    //     Skip = skip
    //   });
    // }

    [HttpGet("{id}")]
    public async Task<ActionResult<LocationDetailsIdDto>> Get(
    [FromRoute] int id)
    {
      return null;
    }

    [HttpGet("{id}/history")]
    [ResponseCache(Duration = 43200)] // 12 hour cache
    public async Task<ActionResult<PageResult<LocationHistoryDto>>> GetLocationHistory(
    [FromRoute] int id, [FromQuery] DateTime? needle = null, [FromQuery] int size = 1000, [FromQuery] int? skip = 0)
    {
      if (!needle.HasValue)
      {
        needle = DateTime.MaxValue;
      }

      return await Mediator.Send(new GetLocationHistoryQuery
      {
        LocationId = id,
        Needle = (DateTime)needle,
        Size = size,
        Skip = skip
      });
    }

    [HttpGet("{id}/debtorHistory")]
    [ResponseCache(Duration = 43200)] // 12 hour cache
    public async Task<ActionResult<PageResult<LocationDebtorHistoryDto, DateTime>>> GetDebtorHistory(
    [FromRoute] int id, [FromQuery] DateTime? needle = null, [FromQuery] int size = 1000, [FromQuery] int? skip = 0)
    {
      if (!needle.HasValue)
      {
        needle = DateTime.MaxValue;
      }

      return await Mediator.Send(new GetDebtorHistoryQuery
      {
        LocationId = id,
        Needle = (DateTime)needle,
        Size = size,
        Skip = skip
      });
    }

    [HttpGet("{id}/refillHistory")]
    [ResponseCache(Duration = 43200)] // 12 hour cache
    public async Task<ActionResult<PageResult<RefillDto, DateTimeOffset>>> GetRefillHistory(
    [FromRoute] int id, [FromQuery] DateTimeOffset? needle = null, [FromQuery] int size = 1000, [FromQuery] int? skip = 0)
    {
      if (!needle.HasValue)
      {
        needle = DateTimeOffset.MaxValue;
      }

      return await Mediator.Send(new GetLocationRefillHistoryQuery
      {
        LocationId = id,
        Needle = (DateTimeOffset)needle,
        Size = size,
        Skip = skip
      });
    }




    [HttpPut("{id}")]
    public async Task<ActionResult<int>> UpdateMetaData([FromRoute] int id, UpdateLocationMetaDataCommand command)
    {
      command.Id = id;
      return await Mediator.Send(command);
    }

    [HttpPost("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<string>> SaveLocationImage([FromRoute] int id, IFormFile file)
    {
      return await Mediator.Send(new AddLocationImageCommand
      {
        Picture = file,
        LocationId = id
      });
    }

    [HttpGet("{id}/image")]
    public async Task<List<ImageResponseDto>> GetLocationImage([FromRoute] int id)
    {
      return await Mediator.Send(new GetLocationImageQuery
      {
        LocationdId = id
      });
    }
  }
}
