using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameStore.Application.VideoGames.Queries.GetAllVideoGames;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoGamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<VideoGame>> Get()
        {

            List<VideoGame> games = await _mediator.Send(new GetAllVideoGamesQuery());
            return games;
        }
    }
}
