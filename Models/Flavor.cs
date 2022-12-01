using DarsBakeryv3.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DarsBakeryv3.Models
{
    public class Flavor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Flavor name")]
        [Required(ErrorMessage = "Flavor name is required!")]
        public string Name { get; set; }

        //Relationships
        public List<Cake>? Cakes { get; set; }
    }
}
