using DarsBakeryv3.Models;

namespace DarsBakeryv3.Data.ViewModels
{
    public class NewCakeDropdownsVM
    {
        public NewCakeDropdownsVM()
        {
            Flavors = new List<Flavor>();
            Frostings = new List<Frosting>();
            Portions = new List<Portion>();
        }

        public List<Flavor> Flavors { get; set; }
        public List<Frosting> Frostings { get; set; }
        public List<Portion> Portions { get; set; }
    }
}
