using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateStreamer")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand command)
        {
            var streamer = await _mediator.Send(command);
            return Ok(streamer);
        }

        [HttpPut(Name = "UpdateStreamer")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpdateStreamer([FromBody] UpdateStreamerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteStreamer")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> DeleteStreamer(int id)
        {
            var command = new DeleteStreamerCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
