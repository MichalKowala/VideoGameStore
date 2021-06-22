using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Application.VideoGames.Commands.DeleteVideoGame
{
    public class DeleteVideoGameCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeleteVideoGameCommand(Guid id)
        {
            Id = id;
        }
    }
}
