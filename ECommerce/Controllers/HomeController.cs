﻿using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
namespace ECommerce.Controllers
{
    public class HomeController:Controller
    {
        public int PageSize = 4;  //4 products per Page
        private IStoreRepository repository;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        //Pagination
        public ViewResult Index(int productPage =1) //Optional parameter to the index method if the method called without a parameter 
         => View(repository.Products
         .OrderBy(p => p.ProductID)
         .Skip((productPage - 1) * PageSize) //Skip over the products that appeared before current page
         .Take(PageSize)); // take number of products as by PageSize
    }
}
