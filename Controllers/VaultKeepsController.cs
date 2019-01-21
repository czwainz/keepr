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

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository vkRepo)
    {
      _repo = vkRepo;
    }

    //GetKeepsByVaultId (id is vaultId)
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> result = _repo.GetKeepsByVaultId(id, userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    //AddVaultKeep
    // [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep val)
    {
      val.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddVaultKeep(val);
      return Created("/api/vaultkeep/" + result.Id, result);
    }



    //DeleteVaultKeep
    //ID is vaultkeepId
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      // _repo.DeleteVaultKeep(id, userId);

      if (_repo.DeleteVaultKeep(id, userId))
      {
        return Ok("Successfully deleted");
      }
      return BadRequest("Unable to delete");
    }


  }
}