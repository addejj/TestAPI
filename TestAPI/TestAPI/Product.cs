namespace TestAPI
{
    public record Product(
     string id,
     string categoryId,
     string categoryName,
     string name,
     int quantity,
     bool sale
 );
}
