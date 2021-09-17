using AI.AILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class Splitter
    {
        public SplittedRecipeDto SplitText(string text) 
        {
            LineLogic lineLogic = new LineLogic();
            WordCollection wordCollection = new WordCollection();


            var splitLines = lineLogic.SplitLines(text);
            var filteredIngediens = lineLogic.Ingredients(splitLines, wordCollection);
            var recipe = lineLogic.Recipe(filteredIngediens, text);
            return new SplittedRecipeDto { Ingridients =filteredIngediens, Instruction = recipe};
        }
    }
}
