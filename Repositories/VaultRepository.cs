
using System;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace Keepr.Repositories
{

  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    //GetVaultsByUserId
    public IEnumerable<Vault> GetVaultsByUserId(int id)
    {
      return _db.Query<Vault>($@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN vaults v ON v.id = vk.vaultId
      WHERE (userId = @id);
      ", new { id });
    }
    //AddVaults
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Vaults (name, description, isPrivate)
      VALUES (@Name, @Description, @IsPrivate);
      SELECT LAST_INSERT_ID();", newVault);
      if (id == 0)
      {
        return null;
      }
      newVault.Id = id;
      return newVault;
    }



  }
}