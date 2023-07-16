using PizzaPlanet.App.App_Code.CoreModels;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.App.App_Code.BOL
{
    public class Food
    {
        private CoreFood _food;

        [Key]
        public int FoodId { get; set; }

        public string FoodDescription { get; set; }

        public List<Inventory> Inventories { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Food()
        {

        }

        public Food(CoreFood food)
        {
            if (food is null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            _food = food;

            if (_food.FoodId > 0)
            {
                FoodId = _food.FoodId;
            }

            FoodDescription = _food.FoodDescription;
        }


    }
}
