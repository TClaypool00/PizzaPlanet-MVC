using PizzaPlanet.App.App_Code.BOL;
using PizzaPlanet.App.App_Code.ViewModels;

namespace PizzaPlanet.App.App_Code.CoreModels
{
    public class CoreFood
    {
        private readonly Food _food;
        private readonly FoodViewModel _foodViewModel;

        public int FoodId { get; set; }

        public string FoodDescription { get; set; }

        public CoreFood()
        {

        }

        public CoreFood(FoodViewModel food)
        {
            _foodViewModel = food ?? throw new ArgumentNullException(nameof(food))
;

            FoodId = _foodViewModel.FoodId;
            FoodDescription = _foodViewModel.FoodDescription;
        }

        public CoreFood(Food food)
        {
            if (food is null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            _food = food;

            FoodId = _food.FoodId;
            FoodDescription = _food.FoodDescription;
        }
    }
}