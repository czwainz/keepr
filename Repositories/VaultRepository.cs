
using System;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Repositories
{

  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    //GetVaultKeepsByUserId
    // public IEnumerable<VaultKeep> GetVaultKeepsByUserId(string id)
    // {
    //   return _db.Query<VaultKeep>($@"
    //   SELECT * FROM vaultkeeps vk
    //   INNER JOIN vaults v ON v.id = vk.vaultId
    //   WHERE (userId = @id);
    //   ", new { id });
    // }

    public IEnumerable<Vault> GetVaultsByUserId(string uId)
    {
      return _db.Query<Vault>($@"SELECT * FROM vaults WHERE userId = @uId", new { uId });
    }

    //AddVaults
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Vaults (name, description, userId)
      VALUES (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();", newVault);
      if (id == 0)
      {
        return null;
      }
      newVault.Id = id;
      return newVault;
    }

    public bool DeleteVault(int vaultId, string userId)
    {
      int success = _db.Execute(@"DELETE FROM Vaults WHERE id = @vaultId AND userId = @userId", new { vaultId, userId });
      return success != 0;
    }

  }
}