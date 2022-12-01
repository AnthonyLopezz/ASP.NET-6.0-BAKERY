using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace DarsBakeryv3.Models
{
    public class Employee : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee name is required")]
        public string Name { get; set; }

        [Display(Name = "Employee photo profile")]
        [Required(ErrorMessage = "Employee photo profile is required")]
        public string Photo { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "DNI is required")]
        public string DNI { get; set; }
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        //Relationships
        [Display(Name = "Role Category")]
        public RoleJob RoleJob { get; set; }
    }
}
