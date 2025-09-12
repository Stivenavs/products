namespace product_management.Application.Products.Out
{
    public record ProductDto(int Id, string Name, string? Description, decimal Price, DateTime CreatedAt);
}
