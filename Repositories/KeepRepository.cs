
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
    //GetAllPublicKeeps
    public IEnumerable<Keep> GetAllPublicKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }

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
      int success = _db.Execute(@"DELETE FROM Keeps WHERE id = @keepId AND userId = @userId", new { keepId, userId });
      return success != 0;
    }

    //EditKeeps
    public Keep EditKeep(int id, Keep newKeep)
    {
      try
      {
        return _db.QueryFirstOrDefault<Keep>($@"
        UPDATE keeps SET
        Id = @Id,
        UserId = @UserId,
        Name = @Name,
        Description = @Description,
        Img = @Img,
        IsPrivate = @IsPrivate,
        Views = @Views,
        Shares = @Shares,
        Keeps = @Keeps
        WHERE id = @Id;
        SELECT * FROM keeps WHERE id = @Id;
        ", newKeep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

  }
}


