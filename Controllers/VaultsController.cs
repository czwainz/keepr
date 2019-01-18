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

  public class VaultsController : ControllerBase
  {
    private readonly UserRepository _userRepo;
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository vaultRepo)
    {
      _repo = vaultRepo;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> GetVaults()
    {
      var id = HttpContext.User.Identity.Name;
      IEnumerable<Vault> result = _repo.GetVaultsByUserId(id);
      return Ok(result);

    }

    //addVault
    [Authorize]
    // [HttpGet("Authenticate")]
    [HttpPost]
    public ActionResult<Vault> AddVault(Vault vault)
    {
      var id = HttpContext.User.Identity.Name;
      vault.UserId = id;
      return Ok(_repo.AddVault(vault));

    }

    //delete vault
    [Authorize]
    [HttpDelete("{vaultId}")]
    public ActionResult<string> DeleteVault(int vaultId)
    {
      var id = HttpContext.User.Identity.Name;
      if (_repo.DeleteVault(vaultId, id))
      {
        return Ok("Successfully deleted");
      }
      return BadRequest("Unable to delete");
    }





  }
}