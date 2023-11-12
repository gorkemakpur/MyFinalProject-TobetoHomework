﻿using DataAccess.Abstract;
using Entities.Concrete;
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

        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product(){ProductId = 1,CategoryId=1,ProductName="Bardak",UnitPrice=16,UnitsInStock=11},
                new Product(){ProductId = 2,CategoryId=1,ProductName="Tabak",UnitPrice=33,UnitsInStock=10},
                new Product(){ProductId = 3,CategoryId=2,ProductName="Telefon",UnitPrice=11888,UnitsInStock=1},
                new Product(){ProductId = 4,CategoryId=2,ProductName="Klavye",UnitPrice=1131,UnitsInStock=8},
                new Product(){ProductId = 5,CategoryId=2,ProductName="Mouse",UnitPrice=151,UnitsInStock=6}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
