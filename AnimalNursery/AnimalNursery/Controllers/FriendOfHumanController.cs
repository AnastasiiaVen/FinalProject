using AnimalNursery.Models;
using AnimalNursery.Models.Animals;
using AnimalNursery.Models.Requests;
using AnimalNursery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace AnimalNursery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendOfHumanController : ControllerBase
    {
        private IFriendOfHumanRepository _friendOfHumanRepository;
        public FriendOfHumanController(IFriendOfHumanRepository friendOfHumanRepository) 
        {
            _friendOfHumanRepository = friendOfHumanRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateFriendsOfHumanRequest createFriendsOfHumanRequest)
        {
            FriendOfHuman friendOfHuman = TypeOfFriendsOfHuman.create(createFriendsOfHumanRequest.Type);
            friendOfHuman.Name = createFriendsOfHumanRequest.Name;
            friendOfHuman.Birthday = createFriendsOfHumanRequest.Birthday;
            friendOfHuman.Type = createFriendsOfHumanRequest.Type;
            friendOfHuman.Commands = new Models.Commands.CommandsList(createFriendsOfHumanRequest.Commands);
            return Ok(_friendOfHumanRepository.Create(friendOfHuman));
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateFriendsOfHumanRequest updateFriendsOfHumanRequest)
        {
            FriendOfHuman friendOfHuman = TypeOfFriendsOfHuman.create(updateFriendsOfHumanRequest.Type);
            friendOfHuman.Name = updateFriendsOfHumanRequest.Name;
            friendOfHuman.Birthday = updateFriendsOfHumanRequest.Birthday;
            friendOfHuman.Type = updateFriendsOfHumanRequest.Type;
            friendOfHuman.Commands = new Models.Commands.CommandsList(updateFriendsOfHumanRequest.Commands);
            return Ok(_friendOfHumanRepository.Create(friendOfHuman));
        }

        [HttpGet("get-all")]
        public ActionResult<List<FriendOfHuman>> GetAll()
        {
            return Ok(_friendOfHumanRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<FriendOfHuman> GetById(int id)
        {
            return Ok(_friendOfHumanRepository.GetById(id));
        }
    }
}
