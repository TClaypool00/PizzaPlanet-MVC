using PizzaPlanet.App.App_Code.CoreModels;

namespace PizzaPlanet.App.App_Code.BLL
{
    public interface IFoodService
    {
        public Task<List<CoreFood>> GetFoodsAsync(string foodDescription = null, int? index = null);

        public Task<CoreFood> CreateFoodAsync(CoreFood food);

        public Task<bool> FoodExists(string foodDescription, int? id = null);
    }
}