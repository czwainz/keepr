using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepsController(KeepRepository keepRepo)
    {
      _repo = keepRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_repo.GetAllPublicKeeps());
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Keep> AddKeep(Keep keep)
    {
      var id = HttpContext.User.Identity.Name;
      keep.UserId = id;
      return Ok(_repo.AddKeep(keep));
    }

    [Authorize]
    [HttpDelete("{keepId}")]
    public ActionResult<string> DeleteKeep(int keepId)
    {
      var id = HttpContext.User.Identity.Name;
      _repo.DeleteKeep(keepId, id);

      // if (_repo.DeleteKeep(keepId, id))
      // {
      return Ok("Successfully deleted");
      // }
      // return BadRequest("Unable to delete");


    }
  }
}