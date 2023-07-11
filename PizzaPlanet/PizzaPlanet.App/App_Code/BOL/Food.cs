using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.App.App_Code.BOL
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodDescription { get; set; }
    }
}
