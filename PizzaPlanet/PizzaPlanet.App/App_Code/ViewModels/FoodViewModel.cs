using PizzaPlanet.App.App_Code.CoreModels;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.App.App_Code.ViewModels
{
    public class FoodViewModel
    {
        private readonly CoreFood _coreFood;

        public int FoodId { get; set; }

        [Required(ErrorMessage = "Food Description is required")]
        [MaxLength(255, ErrorMessage = "Food Description has a max length of 255")]
        public string FoodDescription { get; set; }

        public FoodViewModel()
        {

        }

        public FoodViewModel(CoreFood coreFood)
        {
            if (coreFood is null) 
            {
                throw new ArgumentNullException(nameof(coreFood));
            }

            _coreFood = coreFood;

            FoodId = _coreFood.FoodId;
            FoodDescription = _coreFood.FoodDescription;
        }
    }
}
