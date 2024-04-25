using Recipes.Library;
using Recipes.Library.Models;

void RunOperations()
{
    Library lib = new Library();
    try
    {
        Recipes.Library.Models.Recipes recipeItem = new Recipes.Library.Models.Recipes()
        {
            RecipeID = 3,
            RecipeName = "Test Recipe 1234",
            RecipeNotes = "Test Note bwahaha",
            RecipeInstructions = "Inne de benninging"
        };
        //lib.DeleteRecipe(2);
        //lib.AddRecipe(recipeItem);
        //lib.UpdateRecipe(recipeItem);
        Console.WriteLine("Nothing is currently on-fire");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        if (ex.InnerException != null)
        {
            Console.WriteLine(ex.InnerException.Message);
        }
    }
}

RunOperations();
Console.WriteLine("Task(s) complete!");