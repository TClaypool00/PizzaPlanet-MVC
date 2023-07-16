using Microsoft.EntityFrameworkCore;
using PizzaPlanet.App.App_Code.BLL;
using PizzaPlanet.App.App_Code.BOL;
using PizzaPlanet.App.App_Code.CoreModels;

namespace PizzaPlanet.App.App_Code.DAL
{
    public class FoodService : ServiceHelper, IFoodService
    {
        private readonly PizzaPlanetDbContext _context;

        public FoodService(PizzaPlanetDbContext context)
        {
            _context = context;
        }

        public async Task<CoreFood> CreateFoodAsync(CoreFood food)
        {
            var dataFood = new Food(food);

            await _context.Foods.AddAsync(dataFood);

            await SaveAsync();

            if (dataFood.FoodId == 0)
            {
                throw new ArgumentException("Food could not be added");
            }

            food.FoodId = dataFood.FoodId;

            return food;
        }

        public Task<bool> FoodExists(string foodDescription, int? id = null)
        {
            if (id is null)
            {
                return _context.Foods.AnyAsync(f => f.FoodDescription == foodDescription);
            }

            return _context.Foods.AnyAsync(f => f.FoodDescription == foodDescription && f.FoodId != id);
        }

        public async Task<List<CoreFood>> GetFoodsAsync(string foodDescription = null, int? index = null)
        {
            ConfigureIndex(index);

            var coreFoods = new List<CoreFood>();

            var foods = await _context.Foods
                .Select(f => new Food
                {
                    FoodId = f.FoodId,
                    FoodDescription = f.FoodDescription,
                })
                .Take(10)
                .Skip(_index)
                .ToListAsync();

            if (foods.Count > 0)
            {
                for (int i = 0; i < foods.Count; i++)
                {
                    coreFoods.Add(new CoreFood(foods[i]));
                }
            }

            return coreFoods;
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
