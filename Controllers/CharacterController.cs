
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    // this attribute declaures that this and all are controllers
    // comes with some automatic stuff like 400 routing and  
    [ApiController]
    // how we find a specific controllwer when we want to make a service call
    //means that this can be accessed by the name of the controller (Character) from CharacterController
    // can define a route here or in each method
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase 
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // this is a get request
        // it allows us to send status codes
        // sometimes you need to add the [HttpGet] attribute
        // with this endpoint becomes /api/Character/GetAll
        [HttpGet("GetAll")]
        // switched it to action result so swagger would see the Character schema
        public ActionResult<List<Character>> Get()
        {
            // sends ok (200) status code, could be NotFound, etc
            return Ok(_characterService.GetAllCharacters());
        }

        // how you add a query string
        // must match paramter in method
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter) 
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }

    }
}