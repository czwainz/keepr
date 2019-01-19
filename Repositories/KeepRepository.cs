
using System;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace Keepr.Repositories
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
    //AddKeeps
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Keeps (name, description, userId, isPrivate, img, views, shares, keeps)
      VALUES (@Name, @Description, @UserId, @IsPrivate, @Img, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();", newKeep);
      if (id == 0)
      {
        return null;
      }
      newKeep.Id = id;
      return newKeep;
    }

    //DeleteKeeps
    public bool DeleteKeep(int keepId, string userId)
    {
      int success = _db.ExecuteScalar<int>(@"DELETE FROM Keeps WHERE id = @keepId AND userId = @userId", new { keepId, userId });
      if (success != 1) return false;
      return true;
    }

  }
}


