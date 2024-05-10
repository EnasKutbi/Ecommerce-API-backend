using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.EntityFramework;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Service
{

    public class ProductService
    {

        private AppDbContext appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

        }
        public List<Product> GetProducts()
        {

    return appDbContext.Products
    .Include(c => c.Category)
    .Include(product => product.OrderItems)
        .ThenInclude(orderItem => orderItem.Order)
    .ToList();//using appContext to return all product on table
 }

        public Product? CreateNewProduct(Product NewProduct)
        {

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = NewProduct.Name,
                Slug = NewProduct.Slug,
                ImageUrl = NewProduct.ImageUrl,
                Description = NewProduct.Description,
                Price = NewProduct.Price,
                Quantity = NewProduct.Quantity,
                Sold = NewProduct.Sold,
                Shipping = NewProduct.Shipping,
                CreatedAt = NewProduct.CreatedAt
            };
            appDbContext.Products.Add(product);
            appDbContext.SaveChanges();
            return product;
        }
        public void Updatedproductd(Guid ProductId, ProductModel updatpoduct)
        {
            //     //create record 
            var productUpdated = appDbContext.Products
            .Include(c => c.Category)
            .Include(product => product.OrderItems)
                .ThenInclude(orderItem => orderItem.Order)
            .FirstOrDefault(product =>
            product.Id == ProductId);
            {
                if (productUpdated != null)
                {
                    productUpdated.Name = updatpoduct.Name ?? productUpdated.Name;
                    productUpdated.Slug = updatpoduct.Slug ?? productUpdated.Slug;
                    productUpdated.ImageUrl = updatpoduct.ImageUrl ?? productUpdated.ImageUrl;
                    productUpdated.Description = updatpoduct.Description ?? productUpdated.Description;
                    productUpdated.Quantity = updatpoduct.Quantity;
                    productUpdated.Sold = updatpoduct.Sold;
                    productUpdated.Shipping = updatpoduct.Shipping;
                    productUpdated.CategoryId = updatpoduct.CategoryId;


                }
                appDbContext.SaveChanges();



            }
        }
        public bool deleteProduct(Guid id)
        {
            var product = appDbContext.Products.FirstOrDefault(Product =>
                    Product.Id == id);
            if (product != null)
            {
                appDbContext.Products.Remove(product);
                appDbContext.SaveChanges();
                return true;
            }
            return false;

        }

    }


}