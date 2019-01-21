
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

    // GetVaultKeepsByVaultId
    public IEnumerable<VaultKeep> GetVaultKeepsByVaultId(int vaultId)
    {
      return _db.Query<VaultKeep>($@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @VaultId);
      ", new { vaultId });
    }

    //AddVaultKeep
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaultkeeps(vaultId, keepId, userId)
            VALUES(@VaultId, @KeepId, @UserId);
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