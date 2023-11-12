using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager(new InMemoryProductDal());
           
            foreach (var item in pm.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}