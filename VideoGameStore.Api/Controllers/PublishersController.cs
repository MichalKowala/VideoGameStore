using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameStore.Application.Publishers.Commands.AddPublisher;
using VideoGameStore.Application.Publishers.Commands.DeletePublisher;
using VideoGameStore.Application.Publishers.Commands.UpdatePublisher;
using VideoGameStore.Application.Publishers.Queries.GetAllPublishers;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublishersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Publisher> publishers = await _mediator.Send(new GetAllPublishersQuery());
            return Ok(publishers);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            var queryResult = await _mediator.Send(new AddPublisherCommand(publisher));
            return Ok(queryResult);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var queryResult = await _mediator.Send(new DeletePublisherCommand(id));
            return Ok(queryResult);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Publisher publisher)
        {
            var queryResult = await _mediator.Send(new UpdatePublisherCommand(publisher));
            return Ok(queryResult);
        }
    }
}
