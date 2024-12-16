namespace ECommerce.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; } //used to get only the products that i query for instead of getting all the data
    }
}
