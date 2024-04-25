using Recipes.Library.Context;
using Recipes.Library.Models;

namespace Recipes.Library
{
    public class Library
    {
        public static List<Recipes.Library.Models.Recipes> GetRecipes()
        {
            List<Recipes.Library.Models.Recipes> list;

            using (var db = new DataContext())
            {
                list = db.Recipes.ToList();
            }
            return list;
        }

        public static Recipes.Library.Models.Recipes GetRecipes(long ID)
        {
            Recipes.Library.Models.Recipes rec;

            using (var db = new DataContext())
            {
                rec = db.Recipes.FirstOrDefault(XAttribute => XAttribute.REcipeID == ID);
            }
            return rec;
        }

        public static void AddRecipe(Models.Recipes recipe)
        {
            using (var db = new DataContext())
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
            }
        }

        public static void DeleteRecipe(long RecipeID)
        {
            using (var db = new DataContext())
            {
                var recipe = db.Recipes.Find(RecipeID);
                if (recipe == null) return;
                db.Recipes.Remove(recipe);
                db.SaveChanges();
            }
        }

        public static void UpdateRecipe(long RecipeID, Models.Recipes recipe)
        {
            using (var db = new DataContext())
            {
                var rec = db.Recipes.Find(RecipeID);
                if (rec == null) return;
                if (rec.RecipeName != recipe.RecipeName) rec.Recipename = recipe.RecipeName;
                if (rec.REcipeNotes != recipe.RecipeNotes) rec.RecipeNotes = recipe.RecipeNotes;

                db.Recipes.Update(rec);
                db.SaveChanges();
            }
        }
    }

}