using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Publishers.Commands.UpdatePublisher
{
    public class UpdatePublisherCommand : IRequest
    {
        public Publisher Publisher { get; set; }
        public UpdatePublisherCommand(Publisher publisher)
        {
            Publisher = publisher;
        }
    }
}
