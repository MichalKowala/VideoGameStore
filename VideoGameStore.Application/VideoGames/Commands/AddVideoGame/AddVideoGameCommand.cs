using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;
using VideoGameStore.Domain.Enums;

namespace VideoGameStore.Application.VideoGames.Commands.AddVideoGame
{
    public class AddVideoGameCommand : IRequest
    {
        public VideoGame VideoGame { get; set; }
        public AddVideoGameCommand(VideoGame videoGame)
        {
            VideoGame = videoGame;
        }
    }
}
