using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarsBakeryv3.Models
{
    public class Cake :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Cake name is required!")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Cake price is required!")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Cake image url is required!")]
        public string ImageURL { get; set; }

        [Display(Name = "Cake form")]
        public Shape Shape { get; set; }

        //Portions
        public int PortionId { get; set; }
        [ForeignKey("PortionId")]
        public Portion Portion { get; set; }

        //Flavor
        public int FlavorId { get; set; }
        [ForeignKey("FlavorId")]
        public Flavor Flavor { get; set; }

        //Frosting
        public int FrostingId { get; set; }
        [ForeignKey("FrostingId")]
        public Frosting Frosting { get; set; }
    }
}
