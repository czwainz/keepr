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






  }
}