// See https://aka.ms/new-console-template for more information
using AI.AILogic;

namespace AI.AILogic.AI
{


    public class Program
    {
        public static void Main()
        {
            LineLogic lineLogic = new LineLogic();
            WordCollection wordCollection = new WordCollection();
            string[] splitter = new string[] { " " };
            string exampleText = "1 kg Kartoffeln,mehlig kochend \n 120 g Butter \n 120 ml Milch \n 1 Prise(m) Muskat Salz und Pfeffer \n 1 Zweig/e Rosmarin \n\r" +
                "Zunächst die Kartoffeln schälen, halbieren und in einem Kochtopf in 20 - 25 Min gar dämpfen. Milch und Butter in einem Topf \n\r " +
                "erhitzen und die Gewürze dazugeben.\n\r Den Rosmarinzweig eine Weile mitkochen und dann wieder herausnehmen.";
            var lineSplittedText = exampleText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] splittedArray = exampleText.Split("\n"[0]);
            
            List<string> ingredients = new List<string>();
            var splitLines = lineLogic.SplitLines(exampleText);
            var filteredIngediens= lineLogic.FilterWrongStuffOut( splitLines, wordCollection);
            var recipe = lineLogic.Recipe(filteredIngediens, exampleText);
            //var recipe = lineLogic.FilterRecipe(ingredients);
            //lineLogic.FilterWrongStuffOut(filteredIngediens, wordCollection);

        }
    }




}