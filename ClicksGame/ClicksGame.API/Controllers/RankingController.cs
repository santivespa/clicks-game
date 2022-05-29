using ClicksGame.BLL.Interfaces;
using ClicksGame.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClicksGame.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IRankingController _rankingController;

        public RankingController(IRankingController rankingController)
        {
            _rankingController = rankingController;
        }
        [HttpGet("/ranking")]
        public List<Ranking> GetRankings()
        {
            return _rankingController.GetRanking().OrderByDescending(x=>x.Points).ToList();
        }
    }
}
