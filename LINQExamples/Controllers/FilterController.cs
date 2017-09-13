using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LINQExamples.Models;

namespace LINQExamples.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index()
        {
            var db = new ProductContext();
           
            // grouping
            var products = db.Products.GroupBy(p => p.Price).ToList();

            var vm = new Tuple<List<IGrouping<decimal, Product>>>(products);


            return View(vm);
        }

        public ActionResult Search(string id = "", string title = "", string description = "", string columnOrderByName = "", bool isDesc = true)
        {
            var db = new ProductContext();

            // Searching
            List<Product> products = db.Products.Where(product => product.Title.Contains(title)
                                                        && product.Id.ToString().Contains(id)
                                                        && product.Description.Contains(description)).ToList();

            // Order by 
            if (!string.IsNullOrWhiteSpace(columnOrderByName))
            {
                if (isDesc)
                {
                    PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(Product))
                        .Find(columnOrderByName, true);
                    products = products.OrderByDescending(p => prop.GetValue(p)).ToList();
                }
                else
                {
                    PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(Product))
                        .Find(columnOrderByName, true);
                    products = products.OrderBy(p => prop.GetValue(p)).ToList();
                }
            }

            var vm = new Tuple<List<Product>>(products);


            return View(vm);
        }
    }
}