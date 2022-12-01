using DarsBakeryv3.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DarsBakeryv3.Models
{
    public class Frosting : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Frosting name")]
        [Required(ErrorMessage = "Frosting name is required!")]
        public string Name { get; set; }

        //Relationships
        public List<Cake>? Cakes { get; set; }
    }
}
