using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserAPIDbContext dbContext;

        public UsersController(UserAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await dbContext.UserDetail.ToListAsync());
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.UserDetail.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                firstName = addUserRequest.firstName,
                lastName = addUserRequest.lastName,
                Age = addUserRequest.Age,
                Gender = addUserRequest.Gender,
                Country = addUserRequest.Country

            };

            await dbContext.UserDetail.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest updateUserRequest)
        {
            var user = await dbContext.UserDetail.FindAsync(id);
            if (user != null)
            {
                user.firstName = updateUserRequest.firstName;
                user.lastName = updateUserRequest.lastName;
                user.Age = updateUserRequest.Age;
                user.Gender = updateUserRequest.Gender;
                user.Country = updateUserRequest.Country;

                await dbContext.SaveChangesAsync();

                return Ok(user);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await dbContext.UserDetail.FindAsync(id);
            if (user != null)
            {
                dbContext.UserDetail.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }
    }
}
