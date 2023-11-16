using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.ResultType;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {

            //iş kuralı kontrol edilip hata verilirse error mesaj basılır
            if (product.ProductName.Length<2)
            {
                //magic strings stringleri ayrı ayrı yazmak bi süre sonra değiştirmemiz gerekirse heryere ulaşmamız gerekir 
                return new ErrorResult(Messages.ProductAdded);
            }

            //business code -> işlendiği varsayılıp ekleme işlemi yapılır
            _productDal.Add(product);
            //ardından ürünün eklendiğine dair bilgi,mesaj return edilir
            return new SuccessResult("Ürün Eklendi");
        }

        IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //         data result döndürüyoruz ( bu datayı döndürüyoruz-işlem sonucu true-mesajımız bu)
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult();
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler Listelendi");    
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId==categoryId);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId==productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice<=max && p.UnitPrice>=min);   
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
