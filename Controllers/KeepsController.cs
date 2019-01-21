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

    //GetAllPublicKeeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_repo.GetAllPublicKeeps());
    }

    //AddKeep
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> AddKeep(Keep keep)
    {
      var id = HttpContext.User.Identity.Name;
      keep.UserId = id;
      return Ok(_repo.AddKeep(keep));
    }
    //DeleteKeep
    [Authorize]
    [HttpDelete("{keepId}")]
    public ActionResult<string> DeleteKeep(int keepId)
    {
      var id = HttpContext.User.Identity.Name;
      if (_repo.DeleteKeep(keepId, id))
      {
        return Ok("Successfully deleted");
      }
      return BadRequest("Unable to delete");
    }

    // EditKeep
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep keep)
    {
      Keep result = _repo.EditKeep(id, keep);
      if (result != null)
      {
        return result;
      }
      return NotFound();

    }


  }
}