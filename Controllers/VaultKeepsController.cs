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

    //GetKeepByVaultId
    [Authorize]
    [HttpGet("{id}")]
    public IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      _repo.GetKeepsByVaultId(id, userId);
      return new List<Keep>();

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