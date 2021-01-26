using Application.Locations.Commands.AddLocationImage;
using Application.Locations.Commands.CreateLocation;
using Application.Locations.Commands.UpdateLocationMetaData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
  public class LocationController : ApiControllerBase
  {
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
    [HttpPost]
    public async Task<ActionResult<int>> AddNewLocation(CreateLocationCommand command)
    {
      return await Mediator.Send(command);
    }
  }
}
