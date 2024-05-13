using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.DTOs;
using api.EntityFramework;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{

    public class ProductService
    {
        private AppDbContext _appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task <PaginationDto<ProductModel>> GetProducts(int pageNumber, int pageSize)

        {
            var totalProductCount = await _appDbContext.Products.CountAsync();


            var products = await _appDbContext.Products
            .Select(p => new ProductModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Slug = p.Slug,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                Sold = p.Sold,
                Price = p.Price,
                Quantity = p.Quantity,
                Shipping = p.Shipping,
            })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            return new PaginationDto<ProductModel>
            {
                Items = products,
                TotalCount = totalProductCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

             //return await appDbContext.Products
               //.Include(product => product.Category)
               //.Include(product => product.OrderItems)
               //.ThenInclude(orderItem => orderItem.Product)
            //.ToListAsync();//using appContext to return all product on table

        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }
        public async Task<Product> CreateProductService(Product newProduct)
        {
            newProduct.ProductId = Guid.NewGuid();
            newProduct.CreatedAt = DateTime.UtcNow;
            _appDbContext.Products.Add(newProduct);
            await _appDbContext.SaveChangesAsync();
            return newProduct;

            // var product = new Product
            // {
            //     Id = Guid.NewGuid(),
            //     Name = newProduct.Name,
            //     Slug = newProduct.Slug,
            //     ImageUrl = newProduct.ImageUrl,
            //     Description = newProduct.Description,
            //     Price = newProduct.Price,
            //     Quantity = newProduct.Quantity,
            //     Sold = newProduct.Sold,
            //     Shipping = newProduct.Shipping,
            //     CreatedAt = newProduct.CreatedAt
            // };
            // _appDbContext.Products.Add(newProduct);
            // await _appDbContext.SaveChangesAsync();
            // return newProduct;
        }
        // public async Task AddProductOrder(Guid ProductId, Guid OrderId)
        // {
        //     var orderItem = new OrderItem
        //     {
        //         OrderId = OrderId,
        //         ProductId = ProductId
        //     };

        //     await _appDbContext.OrderItems.AddAsync(orderItem);
        //     await _appDbContext.SaveChangesAsync();
        // }
        public async Task<Product?> UpdateProductService(Guid productId, Product updateProduct)
        {
            //     //create record 
            var productUpdated = await _appDbContext.Products.FirstOrDefaultAsync(p =>
            p.ProductId == productId);
            {
                if (productUpdated != null)
                {
                    productUpdated.Name = updateProduct.Name;
                    productUpdated.Slug = updateProduct.Slug;
                    productUpdated.ImageUrl = updateProduct.ImageUrl;
                    productUpdated.Description = updateProduct.Description;
                    productUpdated.Quantity = updateProduct.Quantity;
                    productUpdated.Sold = updateProduct.Sold;
                    productUpdated.Shipping = updateProduct.Shipping;
                    productUpdated.CategoryId = updateProduct.CategoryId;
                }
                await _appDbContext.SaveChangesAsync();
                return productUpdated;
            }
        }
        public async Task<bool> DeleteProductService(Guid productId)
        {

            var productToRemove = _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
            if (productToRemove != null)
            {
                _appDbContext.Products.Remove(productToRemove);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
            return await _appDbContext.Products
               .Where(p => p.Name.Contains(keyword))
               .ToListAsync();
        }
    }
}