
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool isSuccess);

    //Validator
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Product Id is Required");
        }
    }
    public class DeleteProductCommandHandler
        (IDocumentSession session)        
        :ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            //logger.LogInformation($"Delete product command handler with command {command}");

            session.Delete<Product>(command.id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
