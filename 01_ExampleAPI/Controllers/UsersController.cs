using ExampleAPI.FakeDB;
using ExampleAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);

        [HttpGet]
        /* api/users */
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        /* api/users/12 */
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        /* api/users */
        public User Post([FromBody] User user)
        {
            user.Id = _users.Count() + 1;
            _users.Add(user);
            return user;
        }

        [HttpPut]
        /* api/users */
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Address = user.Address;
            return user;
        }

        [HttpDelete("{id}")]
        /* api/users/12 */
        public string Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
            return $"{id} nolu {deletedUser.FirstName} silme işlemi başasılı";
        }
    }
}