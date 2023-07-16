namespace PizzaPlanet.App.App_Code.DAL
{
    public class ServiceHelper
    {
        protected int _index;

        protected void ConfigureIndex(int? index)
        {
            if (!index.HasValue || index == 0)
            {
                _index = 0;
            }
            else
            {
                _index = 10 * index.Value;
            }
        }
    }
}
