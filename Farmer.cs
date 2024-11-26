using Microsoft.AspNetCore.Mvc;
using PROG3A_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG3A_POE.Controllers
{
    public class FarmerController : Controller
    {
        private static List<FarmerProduct> _products = new(); // In-memory product list

        static FarmerController()
        {
            // Add sample products to view
            _products.Add(new FarmerProduct
            {
                Id = 1,
                Name = "Apples",
                Category = "Fruit",
                ProductionDate = new DateTime(2023, 10, 15),
                FarmerId = "farmer1" // Farmer ID corresponds to a logged-in user
            });

            _products.Add(new FarmerProduct
            {
                Id = 2,
                Name = "Carrots",
                Category = "Vegetable",
                ProductionDate = new DateTime(2023, 11, 01),
                FarmerId = "farmer2"
            });

            _products.Add(new FarmerProduct
            {
                Id = 3,
                Name = "Wheat",
                Category = "Grain",
                ProductionDate = new DateTime(2023, 09, 20),
                FarmerId = "farmer1" // another product for farmer1
            });
            _products.Add(new FarmerProduct
            {
                Id = 4,
                Name = "Tomatoes",
                Category = "Vegetable",
                ProductionDate = new DateTime(2023, 11, 18),
                FarmerId = "farmer2"//another for farmer 2
            });
        }
        //show product functions
        public IActionResult ProductList()
        {
            string currentFarmer = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(currentFarmer))
            {
                return RedirectToAction("Login", "Account");
            }

            // Filter products for the logged-in farmer
            var farmerProducts = _products.Where(p => p.FarmerId == currentFarmer).ToList();

            return View(farmerProducts);
        }
        //adding new product
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(FarmerProduct product)
        {
            if (ModelState.IsValid)
            {
                string currentFarmer = HttpContext.Session.GetString("Username");

                if (string.IsNullOrEmpty(currentFarmer))
                {
                    return RedirectToAction("Login", "Account");
                }

                product.FarmerId = currentFarmer;
                product.Id = _products.Count + 1; // Assign a unique ID
                _products.Add(product);

                return RedirectToAction("ProductList");
            }

            return View(product);
        }
        [HttpPost]//serach for specific category
        public IActionResult FilterProducts(string category)
        {
            // to get the current farmer's username from the session
            string currentFarmer = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(currentFarmer))
            {
                return RedirectToAction("Login", "Account");
            }

            
            var farmerProducts = _products.Where(p => p.FarmerId == currentFarmer);

            if (!string.IsNullOrEmpty(category))
            {
                farmerProducts = farmerProducts.Where(p => p.Category.Contains(category, StringComparison.OrdinalIgnoreCase));
            }

            return View("ProductList", farmerProducts.ToList());
        }
        // Update Product 
        public IActionResult EditProduct(int id)
        {
            //  product by ID
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null || product.FarmerId != HttpContext.Session.GetString("Username"))
            {
                return NotFound(); // farmer can only edit their products
            }

            return View(product);
        }

        // Update Product 
        [HttpPost]
        public IActionResult EditProduct(FarmerProduct updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (product == null || product.FarmerId != HttpContext.Session.GetString("Username"))
            {
                return NotFound(); // Ensure the farmer can only edit their products
            }

            // Update the product details
            product.Name = updatedProduct.Name;
            product.Category = updatedProduct.Category;
            product.ProductionDate = updatedProduct.ProductionDate;

            return RedirectToAction("ProductList");
        }

        // Delete Product
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null || product.FarmerId != HttpContext.Session.GetString("Username"))
            {
                return NotFound(); // farmer can only delete their products
            }

            // Remove the product
            _products.Remove(product);

            return RedirectToAction("ProductList");
        }
        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }

    }
}
