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
            

            List<string> ingredients = new List<string>();
            var splitLines = lineLogic.SplitLines();
            //lineLogic.SplitLines();
            var filteredIngediens= lineLogic.FilterWrongStuffOut( splitLines, wordCollection);
            //lineLogic.FilterWrongStuffOut(filteredIngediens, wordCollection);

        }
    }




}