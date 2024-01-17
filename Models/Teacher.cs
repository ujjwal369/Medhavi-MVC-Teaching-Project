using System.ComponentModel.DataAnnotations;

namespace Medhavi_MVC.Models
{
    public class Teacher : BaseModel
    {
        public string Name { get; set; }
        [StringLength(200)]

        public string? Description { get; set; }

    }
}
