using APIBootcamp.API.Entities.Concrete;
using FluentValidation;

namespace APIBootcamp.API.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır");

            RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez").LessThan(10000).WithMessage("Ürün fiyatı 10.000'den büyük olamaz").GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez");
        }
    }
}
