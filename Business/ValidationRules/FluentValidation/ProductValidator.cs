﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2); //buralarda withmessage yazmasak bile bir karşılığı var ama kendimiz kodu yazarsak yok
            RuleFor(p => p.ProductName).Must(StartsWithA).WithMessage("Ürünler A harfi ile başlamalı"); //must içerisinde metodu çağırıyoruz. metod A ile başlamalı

            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//category id si 1 ise 10 dan büyük yada eşit olmalı


        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A"); //A ile başlıyorsa true dönüyor
        }
    }
}
