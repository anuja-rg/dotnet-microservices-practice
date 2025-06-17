using FluentValidation;

namespace Play.Catalog.Service.Validators
{
    public class ItemDtoValidator : AbstractValidator<ItemDto>
    {
        public ItemDtoValidator()
        {
            RuleFor(item => item.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(item => item.Description).MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(item => item.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
