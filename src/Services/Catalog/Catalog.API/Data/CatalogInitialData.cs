using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            // Martin UPSERT will cater for existing records
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                Name = "Iphone 17",
                Description = "Good phone",
                ImageFile = "phone.jpg",
                Price = 250.00M,
                Category = new List<string> {"Smart Phone"}
            },
            new Product()
            {
                Id = new Guid("5334c236-8458-4cf0-815c-ed2b77c4kk62"),
                Name = "Samsung s25",
                Description = "Great phone",
                ImageFile = "phone2.jpg",
                Price = 255.00M,
                Category = new List<string> {"Smart Phone"}
            },
            new Product()
            {
                Id = new Guid("5334c237-3458-4cr0-815c-ed2b77c4kk69"),
                Name = "Daiken AC",
                Description = "Air conditioner",
                ImageFile = "air.jpg",
                Price = 56.00M,
                Category = new List<string> {"Air Conditioner"}
            },
        };
    }
}
