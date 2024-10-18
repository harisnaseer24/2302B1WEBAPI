using _2302B1CodeFirstAPI.Data;
using _2302B1CodeFirstAPI.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2302B1CodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public CricketController(ApplicationDbContext _db)
        {
            db = _db;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var players= db.Players.Include(f=>f.Team).ToList();
            return Ok(players);
        }

        [HttpPost]
        public IActionResult CreatePlayer(PlayerDTO playerDTO)
        {

            if (ModelState.IsValid)
            {
            //Object Mapping
            Player newplayer = new Player()
            {
               Name=playerDTO.Name,
               age=playerDTO.age,
               Skill=playerDTO.Skill,
               TeamId=playerDTO.TeamId

            };
                var players = db.Players.Add(newplayer);
                db.SaveChanges();
            return Ok(players.Entity);
            }
            else
            {
                return BadRequest("Data is invalid");
            }
        }

        [HttpGet("{id}")]
        public IActionResult EditPlayer(int id)
        {

            var player = db.Players.FirstOrDefault(i => i.Id == id);
            if (player == null)
            {
                return BadRequest("Invalid Id");

            }
            else
            {
                return Ok(player);

            }


        }
        [HttpPut]
        public IActionResult EditPlayer(PlayerDTO playerDto)
        {
            var player = db.Players.FirstOrDefault(i => i.Id == playerDto.Id);
            if (playerDto != null && player!=null) {
                player.Name = playerDto.Name;
                player.Skill = playerDto.Skill;
                player.TeamId = playerDto.TeamId;
                player.age = playerDto.age;

                var editdPlayer = db.Players.Update(player);
                db.SaveChanges();
                return Ok(editdPlayer.Entity);

            }
            else
            {
                return BadRequest("Player not found");
            }
          

        }

        // Search Api
        [HttpGet("{query}")]
        public IActionResult SearchPlayer(string query)
        {
            //Exact Match                                                       a
            //var player = db.Players.Include(t=>t.Team).Where(t=> t.Name == query || t.Skill == query || t.Team.Name ==query);
            //Partial Match                                                            a
            var player = db.Players.Include(t => t.Team).Where(t => t.Name.Contains(query) || t.Skill.Contains(query) || t.Team.Name.Contains(query) || t.Team.Description.Contains(query));
            return Ok(player);



        }

    }
}
