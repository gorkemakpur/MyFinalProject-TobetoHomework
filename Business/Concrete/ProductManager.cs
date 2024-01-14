using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.ResultType;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), 
                CheckIfProductNameExists(product.ProductName)
            );
            
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if (CheckIfProductNameExists(product.ProductName).Success)
                {
                    _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
            }
            return new ErrorResult();

        }

        //---------------------eski yorum satırlarıyla kodlar--------------------------------
        //ValidationTool.Validate(new ProductValidator(), product);//aspect ekledik
        ////////iş kuralı kontrol edilip hata verilirse error mesaj basılır
        //////if (product.ProductName.Length < 2)
        //////{
        //////    //magic strings stringleri ayrı ayrı yazmak bi süre sonra değiştirmemiz gerekirse heryere ulaşmamız gerekir 
        //////    return new ErrorResult(Messages.ProductNameInvalid);
        //////}
        ////////business code -> işlendiği varsayılıp ekleme işlemi yapılır
        //////_productDal.Add(product);
        ////////ardından ürünün eklendiğine dair bilgi,mesaj return edilir
        //////return new SuccessResult(Messages.ProductAdded);
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //data result döndürüyoruz ( bu datayı döndürüyoruz-işlem sonucu true-mesajımız bu)
            if (DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId), Messages.ProductListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                _productDal.Update(product);
            }
            throw new NotImplementedException();
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();

        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();

        }
    }
}
