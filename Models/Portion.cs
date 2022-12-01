using DarsBakeryv3.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DarsBakeryv3.Models
{
    public class Portion:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Portion name")]
        [Required(ErrorMessage = "Portion name is required!")]
        public string Name { get; set; }


        //Relationships
        public List<Cake>? Cakes { get; set; }
    }
}
