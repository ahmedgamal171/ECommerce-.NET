//To Support TagHelper which will be used to add page links at the bottom to make an easy way for the customer to navigate generating html for links required

//Passing  Info to the view about the number pages available ,current page and total number of pages for the repository
//A Tag Helper is a feature in ASP.NET Core that allows developers to generate HTML markup dynamically using C# code within Razor views.
// Creating a viewmodel class to pass data between controller and view
namespace ECommerce.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int  ItemsPerPage { get; set; }
        public int CurrentPage {  get; set; }

        public int TotalPages=>(int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
    }
}
