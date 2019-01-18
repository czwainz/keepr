
using System;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace Keepr.Repository
{

  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    //GetKeepsByUserId
    // public IEnumerable<Keep> GetKeepsByUserId(int id)
    // {
    //   return _db.Query<Keep>($@"
    //   SELECT * FROM vaultkeeps vk
    //   INNER JOIN keeps k ON k.id = vk.keepId
    //   WHERE (userId = @id);
    //   ", new { id });
    // }
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


