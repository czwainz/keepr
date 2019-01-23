
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
            INSERT INTO vaultkeeps(vaultId, keepId, userId)
            VALUES(@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();
            ", vk);
      vk.Id = id;
      return vk;
    }

    //DeleteVaultKeep
    public bool DeleteVaultKeep(VaultKeep vk)
    {
      try
      {
        return _db.QueryFirstOrDefault<VaultKeep>($@"
      UPDATE vaultkeeps SET 
      keepId = @KeepId,
      userId = @UserId", vk);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


  }
}