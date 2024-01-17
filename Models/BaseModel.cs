using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Medhavi_MVC.Models
{
    public class BaseModel : RootModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDataTime { get; set; }

    }
}
