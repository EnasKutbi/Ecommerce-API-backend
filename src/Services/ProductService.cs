using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.DTOs;
using api.EntityFramework;
using api.Helpers;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{

    public class ProductService
    {

        private AppDbContext appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

        }
        public async Task <PaginationDto<ProductModel>> GetProducts(int pageNumber, int pageSize)
        {
            var totalProductCount = await appDbContext.Products.CountAsync();

            var products = await appDbContext.Products
            .Select(p => new ProductModel
            {
                
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

        public async Task<Product?> GetProductById(Guid ProductId)
    {
        return await appDbContext.Products.Include(Product => Product.Category)
        .Include(product => product.OrderItems)
               .ThenInclude(orderItem => orderItem.Product)
        .FirstOrDefaultAsync(Product => Product.Id == ProductId);
    }
    public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword) 

        { 

             return await appDbContext.Products 
                .Where(p => p.Name.Contains(keyword)) 
                .ToListAsync(); 

        }
         public async Task<Product> CreateProductService(Product NewProduct)
        {

           
            
                NewProduct.Id = Guid.NewGuid();
                NewProduct.Name = NewProduct.Name;
                NewProduct.Slug = NewProduct.Slug;
                NewProduct.ImageUrl = NewProduct.ImageUrl;
                NewProduct.Description = NewProduct.Description;
                NewProduct.Price = NewProduct.Price;
                NewProduct.Quantity = NewProduct.Quantity;
                NewProduct.Sold = NewProduct.Sold;
                NewProduct.Shipping = NewProduct.Shipping;
                NewProduct.CreatedAt =DateTime.UtcNow;
                appDbContext.Products.Add(NewProduct);
                await appDbContext.SaveChangesAsync();
                return NewProduct;
        }
            
        public async Task AddProdetOrder(Guid ProductId, Guid OrderId){
         var orderItem = new OrderItem
      {
        
        OrderId = OrderId,
        ProductId = ProductId
        
        
      };

      await appDbContext.OrderItems.AddAsync(orderItem);
      await appDbContext.SaveChangesAsync();
        }
        public async Task<Product?> UpdateProductService(Guid ProductId, ProductModel updatpoduct)
    {
            //     //create record 
            var productUpdated = appDbContext.Products
            .Include(product=>product.Category)
            .Include(product => product.OrderItems)
            .ThenInclude(orderItem => orderItem.Product)
            .FirstOrDefault(product =>
            product.Id == ProductId);
            {
                if (productUpdated != null)
                {
                    productUpdated.Name = updatpoduct.Name ;
                    productUpdated.Slug = updatpoduct.Slug ;
                    productUpdated.ImageUrl = updatpoduct.ImageUrl ;
                    productUpdated.Description = updatpoduct.Description ;
                    productUpdated.Quantity = updatpoduct.Quantity;
                    productUpdated.Sold = updatpoduct.Sold;
                    productUpdated.Shipping = updatpoduct.Shipping;
                    productUpdated.CategoryId = updatpoduct.CategoryId;


                }
                 appDbContext.SaveChanges();
                return  productUpdated;



            }
        }
        public async Task<bool> DeleteProductService(Guid ProductId)
        {
            
            var ProductToRemove = appDbContext.Products.FirstOrDefault(P => P.Id == ProductId);
            if (ProductToRemove != null)
            {
                appDbContext.Products.Remove(ProductToRemove);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
             return await appDbContext.Products
                .Where(p => p.Name.Contains(keyword))
                .ToListAsync();
        }
        


    }


}


