using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //ProductTestV2();
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();

            if (!result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + "//" + item.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Product product = new Product
            {
                CategoryId = 1,
                ProductName = "Test",
                UnitPrice = 1234,
                UnitsInStock = 22
            };
                
        }

        private static void ProductTestV2()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetProductDetails().Success.ToString())
            {
                Console.WriteLine(item);
                //Console.WriteLine(item.ProductName + "//" + item.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);

            }
        }

        private static void ProductTest()
        {
            ProductManager pm = new ProductManager(new EfProductDal());
            /*
             foreach (var item in pm.GetAllByCategoryId(2))
             {
                 Console.WriteLine(item.ProductName);
             }
            */
            foreach (var item in pm.GetByUnitPrice(10, 20).Data)
            {
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.CategoryId);
            }
        }
    }
}