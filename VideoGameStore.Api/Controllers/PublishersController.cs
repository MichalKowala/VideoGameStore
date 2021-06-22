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
        public async Task<List<Publisher>> Get()
        {
            List<Publisher> publishers = await _mediator.Send(new GetAllPublishersQuery());
            return publishers;
        }
        [HttpPost]
        public async Task Create(Publisher publisher)
        {
            await _mediator.Send(new AddPublisherCommand(publisher));
        }
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _mediator.Send(new DeletePublisherCommand(id));
        }
        [HttpPut]
        public async Task Update(Publisher publisher)
        {
           await _mediator.Send(new UpdatePublisherCommand(publisher));
        }
    }
}
