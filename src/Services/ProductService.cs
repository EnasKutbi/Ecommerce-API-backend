using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.DTOs;
using api.Helpers;
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

        public async Task<PaginationDto<Product>> GetProducts(int pageNumber, int pageSize)
        {
            var totalProductCount = await _appDbContext.Products.CountAsync();

            var products = await _appDbContext.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationDto<Product>
            {
                Items = products,
                TotalCount = totalProductCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }
        public async Task<Product> CreateProductService(Product newProduct, Guid categoryId)
        {
            newProduct.ProductId = Guid.NewGuid();
            newProduct.Slug = Slug.GenerateSlug(newProduct.Name);
            newProduct.CategoryId = categoryId;
            newProduct.CreatedAt = DateTime.UtcNow;
            _appDbContext.Products.Add(newProduct);
            await _appDbContext.SaveChangesAsync();
            return newProduct;
        }
        public async Task<Product?> UpdateProductService(Guid productId, Product updateProduct)
        {
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