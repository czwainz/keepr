
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
      int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaultkeeps(vaultId, userId)
            VALUES(@VaultId, @UserId);
            SELECT LAST_INSERT_ID();
            ", vk);
      vk.Id = id;
      return vk;
    }



    //DeleteVaultKeep
    // public bool DeleteVaultKeep(int id)
    // {
    //   int success = _db.Execute(@"DELETE FROM vaultkeeps WHERE id = @id", new { id });
    //   return success != 0;

    // }


  }
}