using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Keep
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int IsPrivate { get; set; }
    public string Image { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
  }
}