﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_Intro_Demo.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Intro_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products
            = new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 7.00,
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50,
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.50,
                }
            };

        [ActionName("My-Products")]
        public IActionResult All(string key)
        {
            if(key != null)
            {
                IEnumerable<ProductViewModel> foundProduct = this.products.Where(x=>x.Name.ToLower().Contains(key.ToLower()));

                return View(foundProduct);
            }

            return View(this.products);
        }

        public IActionResult ById(int id)
        {
            var product = this.products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var text = new StringBuilder();
            foreach (var item in products)
            {
                text.AppendLine($"Product {item.Id}: {item.Name} - {item.Price}lv");
            }

            return Content(text.ToString().TrimEnd());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in products)
            {
                sb.AppendLine($"Product {item.Id}: {item.Name} - {item.Price:f2}lv");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
