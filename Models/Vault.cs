using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{

  //CreateVault Helper Class
  public class CreateVault
  {
    public int Id { get; set; }
    // [Required]
    public string UserId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

  }

  //Vault Class
  public class Vault
  {
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
  }
  //VaultKeep Class
  public class VaultKeep
  {
    public int Id { get; set; }
    [Required]
    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}