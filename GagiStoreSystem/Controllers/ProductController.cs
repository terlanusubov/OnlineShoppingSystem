using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GagiStoreSystem.Attributes;
using GagiStoreSystem.Data;
using GagiStoreSystem.Infrastructure.Models;
using GagiStoreSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GagiStoreSystem.Controllers
{
    [Auth]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> List()
        {
            var products = await _context.Products.OrderByDescending(c => c.CreatedDate).ToListAsync();
            return View(products);
        }

        public IActionResult Add()
        {
            return View(new ProductM());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Product product = new Product()
            {
                Name = model.Name,
                SaleAmount = model.SaleAmount,
                Barcode = model.Barcode,
                Specifications = model.Specifications,
                BuyAmount = model.BuyAmount,
                CostAmount = model.CostAmount,
                CreatedDate = DateTime.Now,
                Link = model.Link,
                Photo = Guid.NewGuid().ToString() + model.Photo.FileName
            };

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products", product.Photo);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await model.Photo.CopyToAsync(stream);
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Product");
        }


        public async Task<JsonResult> GetProductBarcodes()
        {
            var productBarcodes = await _context.Products.Select(c => new
                                                                    {
                                                                        ProductId = c.Id,
                                                                        Barcode = c.Barcode
                                                                    }).ToListAsync();

            return Json(new
            {
                data = productBarcodes,
                status = 200
            });
        }

        public async Task<JsonResult> GetProductPriceById(int? productId)
        {
            if (productId == null)
                return Json(new
                {
                    status = 400
                });

            var product = await _context.Products.Where(c => c.Id == productId).Select(c => new
            {
                SaleAmount = c.SaleAmount
            }).FirstOrDefaultAsync();

            return Json(new
            {
                data = product,
                status = 200
            });
        }
    }
}
