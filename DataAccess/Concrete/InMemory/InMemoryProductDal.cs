using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ Id = 1, ProductName = "Product #1", CategoryId = 1, UnitInStock = 10, UnitPrice = 1.99m },
                new Product{ Id= 2, ProductName = "Product #2", CategoryId = 1, UnitInStock = 15, UnitPrice = 2.99m },
                new Product{ Id = 3, ProductName = "Product #3", CategoryId = 2, UnitInStock = 1, UnitPrice = 3.99m },
                new Product{ Id = 4, ProductName = "Product #4", CategoryId = 2, UnitInStock = 13, UnitPrice = 4.99m },
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            //Product productToDelete = null;

            //foreach (var item in _products)
            //{
            //    if(product.ProductId == item.ProductId)
            //    {
            //        productToDelete = item;
            //    };
            //}

            Product productToDelete = _products.SingleOrDefault(x => x.Id == product.Id);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
           }

        public List<ProductDetailDTO> GetProductsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.Id == product.Id);
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
