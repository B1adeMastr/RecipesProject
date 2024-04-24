using Recipes.Context;
using Recipes.Models;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Recipes;


public class Recipes
{
    public Recipes()
    {
        //Constructor
    }
    public void SaveRecipe()
    {
        try
        {
            if ((!String.IsNullOrEmpty(RecipeName)) && (!String.IsNullOrEmpty(Instructions)) && recipeIngredients != null && recipeIngredients.Any())
            {
                //save code go here
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    public int RecipeID { get; set; }
    public string RecipeName { get; set; }
    public string Notes { get; set; }
    public Ingredients Ingredients { get; set; }
    public string Instructions { get; set; }

    public List<Ingredients> recipeIngredients = new List<Ingredients>();


    public delegate void MyDelegate(string msg);
    MyDelegate del = new MyDelegate(SendMessage);
    //or
    MyDelegate del2 = SaveToDatabase;

    static void SendMessage(string message)
    {
        string strToSave = string.Empty;
        strToSave = message;
    }

    static void SaveToDatabase(string message)
    {
        string strToSave = string.Empty;
        strToSave = message;
    }

    public interface IRecipe
    {
        void ReadRecipe();
        void WriteRecipe(string text);
    }

    private class RecipeInfo : IRecipe
    {
        string readRecipe = string.Empty;
        string writeRecipe = string.Empty;
        string searchRecipe = string.Empty;

        void IRecipe.ReadRecipe()
        {
            readRecipe = "Reading Recipe";
        }
        void IRecipe.WriteRecipe(string text)
        {
            writeRecipe = text;
        }

        public void Search(string text)
        {
            searchRecipe = "Searching in Recipe";
        }
    }

    private class RecipeOperations
    {
        public static void ProcessRecipe()
        {
            IRecipe recipe1 = new RecipeInfo();
            RecipeInfo recipe2 = new RecipeInfo();

            recipe1.ReadRecipe();
            recipe1.WriteRecipe("content");

            recipe2.Search("text to be searched");
        }
    }


    public void AddIngredient(int amtWhole, string amtFraction, MeasureType measuretype, string ingredient)
    {
        Ingredients stuff = new Ingredients()
        {
            AmountWhole = amtWhole,
            AmountFraction = amtFraction,
            Measure = measuretype,
            Name = ingredient
        };

        recipeIngredients.Add(stuff);
    }

    try
    {
        Recipes recipe = new Recipes()
        {
            RecipeName = "Test Recipe 1234",
            Notes = "Test Note bwahaha",
            Instructions = "Inne de benninging"
        };
    AddRecipe(recipe);
    }
    catch (Exception ex)
    {
        if (ex.InnerException != null)
        {

        }
    }


    void AddRecipe (Recipes recipe)
    {
        using (var db = new DataContext())
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }
    }

    void DeleteRecipe(long RecipeID)
    {
        using (var db = new DataContext())
        {
            var recipe = db.Recipes.Find(RecipeID);
            if (recipe == null) return;
            db.Recipes.Remove(recipe);
            db.SaveChanges();
        }
    }

    void UpdateRecipe(Recipes recipe)
    {
        using (var db = new DataContext())
        {
            db.Recipes.Update(recipe);
            db.SaveChanges();
        }
    }


}

public enum MeasureType
{
    Pinch,
    Tsp,
    Tbsp,
    Cup,
    Ounce,
    Pound,
    Pint,
    Quart,
    Gallon
}

public class Ingredients
{
        public int AmountWhole;
        public string AmountFraction;
        public MeasureType Measure;
        public string Name;

}

public class RecipeName
{

}

public class Notes
{

}

public class Instructions
{

}
