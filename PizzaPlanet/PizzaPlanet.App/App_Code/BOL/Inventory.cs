namespace PizzaPlanet.App.App_Code.BOL
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        public int StartingQuantity { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

    }
}
