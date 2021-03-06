
using System;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Repositories
{

  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    // GetKeepsByVaultId  
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _db.Query<Keep>($@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vaultId = @vaultId AND vk.userId = @userId)",
    new { vaultId, userId });
    }


    //AddVaultKeep
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      //check here for dups
      int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaultkeeps(vaultId, keepId, userId)
            VALUES(@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();
            ", vk);
      vk.Id = id;
      return vk;
    }

    //DeleteVaultKeep
    public bool DeleteVaultKeep(int vaultId, int keepId, string userId)
    {
      int success = _db.Execute($@"DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId AND userId = @userId", new { vaultId, userId, keepId });
      return success != 0;
    }


  }
}