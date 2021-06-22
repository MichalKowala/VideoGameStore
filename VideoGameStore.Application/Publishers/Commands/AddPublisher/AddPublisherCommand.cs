using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Application.Publishers.Commands.AddPublisher
{
    public class AddPublisherCommand : IRequest
    {
        public Publisher Publisher { get; set; }
        public AddPublisherCommand(Publisher publisher)
        {
            Publisher = publisher;
        }
    }
}
