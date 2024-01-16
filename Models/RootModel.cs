using System.ComponentModel.DataAnnotations;

namespace Medhavi_MVC.Models
{
    public class RootModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
