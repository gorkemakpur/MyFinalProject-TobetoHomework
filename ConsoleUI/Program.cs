using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager(new EfProductDal());
           /*
            foreach (var item in pm.GetAllByCategoryId(2))
            {
                Console.WriteLine(item.ProductName);
            }
           */
            foreach (var item in pm.GetByUnitPrice(10,20))
            {
                Console.WriteLine(item.ProductName);
            }


        }
    }
}