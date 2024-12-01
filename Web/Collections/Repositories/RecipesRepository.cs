using Collections.Data;
using Collections.Models;
using Microsoft.EntityFrameworkCore;

namespace Collections.Repositories;

public class RecipesRepository(CollectionsDbContext context)
{
    public async Task<RecipeModel?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await context.Recipes.FirstOrDefaultAsync(recipe => recipe.Id == id, cancellationToken);
    }
}