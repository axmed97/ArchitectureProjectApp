using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public List<ProductDetailDTO> GetProductsDetails()
        {
            using AppDbContext context = new();

            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryId equals c.Id
                         select new ProductDetailDTO {
                             ProductId = p.Id, 
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName, 
                             UnitInStock = p.UnitInStock, 
                             UnitPrice = p.UnitPrice
                         };

            return result.ToList();
        }
    }
}
