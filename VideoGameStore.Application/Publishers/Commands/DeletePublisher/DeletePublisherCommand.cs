using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Application.Publishers.Commands.DeletePublisher
{
    public class DeletePublisherCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeletePublisherCommand(Guid id)
        {
            Id = id;
        }
    }
}
