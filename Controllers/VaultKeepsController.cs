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

    //GetVaultKeepByVaultId
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<VaultKeep>> Get(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      IEnumerable<VaultKeep> result = _repo.GetVaultKeepsByVaultId(id, userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    //AddVaultKeep
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep val)
    {
      val.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddVaultKeep(val);
      return Created("/api/vaultkeep/" + result.Id, result);
    }



    //DeleteVaultKeep






  }
}