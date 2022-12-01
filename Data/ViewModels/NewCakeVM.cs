using DarsBakeryv3.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace DarsBakeryv3.Data.ViewModels
{
    public class NewCakeVM
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Cake name is required")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Cake price is required")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Cake image url is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a shape")]
        [Required(ErrorMessage = "Cake shape is required")]
        public Shape Shape { get; set; }

        //Portions
        [Display(Name = "Select a portion")]
        [Required(ErrorMessage = "Cake portion is required")]
        public int PortionId { get; set; }

        //Flavor
        [Display(Name = "Select a flavor")]
        [Required(ErrorMessage = "Cake flavor is required")]
        public int FlavorId { get; set; }

        //Frosting
        [Display(Name = "Select a frosting")]
        [Required(ErrorMessage = "Cake frosting is required")]
        public int FrostingId { get; set; }
    }
}
