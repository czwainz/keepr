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
    public string Title { get; set; }
    public string Description { get; set; }

    public bool IsPrivate { get; set; }


  }
}