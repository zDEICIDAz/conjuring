using conjuring.Models;
using conjuring.Services;
using Microsoft.AspNetCore.Mvc;

namespace conjuring.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserService userService) : ControllerBase {
    private readonly UserService service = userService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers() {
        return Ok(await service.GetUsers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserEntity>> GetUser(int id) {
        UserEntity? user = await service.GetUser(id);

        if (user != null) {
            return Ok(user);
        }

        return NotFound(new {
            Error = "User not found"
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserEntity user) {
        bool create = await service.Create(user);

        if (create) {
            return NoContent();
        }

        return BadRequest(new {
            Error = "Username always exists",
        });
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> Update(int id, UserEntity user) {
        bool update = await service.Update(id, user);

        if (update) {
            return NoContent();
        }

        return BadRequest(new {
            Error = "User not found",
        });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        bool delete = await service.Delete(id);

        if (delete) {
            return NoContent();
        }

        return BadRequest(new {
            Error = "User not found"
        });
    }
}
