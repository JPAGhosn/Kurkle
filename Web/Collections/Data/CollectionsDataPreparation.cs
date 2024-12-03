using Collections.Repositories.ElasticSearch;
using Collections.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Collections.Data;

public static class CollectionsDataPreparation
{
    public static async Task GenerateData(IApplicationBuilder app, bool isProd)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        await SeedData(app, serviceScope.ServiceProvider.GetService<CollectionsDbContext>()!, isProd);
    }

    private static async Task SeedData(IApplicationBuilder app, CollectionsDbContext context, bool isProd)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        await serviceScope.ServiceProvider.GetService<CollectionElasticSearchRepository>()!
            .CreateIndexIfNotExistsAsync();

        if (isProd)
            try
            {
                Console.WriteLine("Building the database...");
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        if (!context.Collections.Any())
        {
            Console.WriteLine("Seeding recipes...");
            foreach (var glimpse in CollectionsSeeder.Data)
                context.Collections.Add(glimpse);

            context.SaveChanges();
        }
    }
}