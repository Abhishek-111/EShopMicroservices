namespace Basket.API.Basket.StoreBasket;
public record StoreBasketCommand(ShoppingCart cart): ICommand<StoreBasketResult>;

public record StoreBasketResult(string userName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.cart).NotNull().WithMessage("Cart cannot be null");
        RuleFor(x => x.cart.UserName).NotEmpty().WithMessage("UserName is required!");
    }
}
public class StoreBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.cart;

        await repository.StoreBasket(command.cart, cancellationToken);

        return new StoreBasketResult(command.cart.UserName);
    }
}
