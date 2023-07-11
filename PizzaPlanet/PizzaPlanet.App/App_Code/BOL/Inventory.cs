using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.App.App_Code.BOL
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public int StartingQuantity { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

    }
}
