using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //ProductTestV2();

        }

        private static void ProductTestV2()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetProductDetails())
            {
                Console.WriteLine(item.ProductName + "//" + item.CategoryName);
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
            foreach (var item in pm.GetByUnitPrice(10, 20))
            {
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.CategoryId);
            }
        }
    }
}