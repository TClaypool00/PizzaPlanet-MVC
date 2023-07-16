using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaPlanet.App.App_Code.BLL;
using PizzaPlanet.App.App_Code.CoreModels;
using PizzaPlanet.App.App_Code.ViewModels;

namespace PizzaPlanet.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FoodsController : ControllerHelper
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public async Task<ActionResult> Index()
        {
            var foods = await _foodService.GetFoodsAsync();
            var apiFoods = new List<FoodViewModel>();

            if (foods.Count > 0)
            {
                for (int i = 0; i < foods.Count; i++)
                {
                    apiFoods.Add(new FoodViewModel(foods[i]));
                }
            }

            return View(apiFoods);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromBody] FoodViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrors()[0]);
                }

                if (await _foodService.FoodExists(model.FoodDescription))
                {
                    return BadRequest("Food Description already exists");
                }

                var coreFood = new CoreFood(model);

                coreFood = await _foodService.CreateFoodAsync(coreFood);

                return Ok(new FoodViewModel(coreFood));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
