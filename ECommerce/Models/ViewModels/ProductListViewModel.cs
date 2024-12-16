namespace ECommerce.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set;}=Enumerable.Empty<Product>();
        public PageInfo PageInfo { get; set;} = new PageInfo();

    }
}
