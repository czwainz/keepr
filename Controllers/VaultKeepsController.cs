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
      // val.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddVaultKeep(val);
      return Created("/api/vaultkeep/" + result.Id, result);
    }



    //DeleteVaultKeep
    [HttpDelete]
    public ActionResult<string> DeleteVaultKeep(int vkId, string uId)
    {
      var userId = HttpContext.User.Identity.Name;
      _repo.DeleteVaultKeep(vkId, userId);

      // if (_repo.DeleteKeep(keepId, id))
      // {
      return Ok("Successfully deleted");
      // }
      // return BadRequest("Unable to delete");





    }
  }