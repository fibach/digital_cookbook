using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AI.AILogic
{
    public  class LineLogic
    {
        public List<string>  SplitLines()
        {
            
                WordCollection wordCollection = new WordCollection();
                List<string> possibleIngredients = new List<string>();
                List<string> ingredients = new List<string>();
                
                string[] splitter = new string[] { " " };
                string exampleText = "1 kg Kartoffeln,mehlig kochend \n 120 g Butter \n 120 ml Milch \n 1 Prise(m) Muskat Salz und Pfeffer \n 1 Zweig/e Rosmarin \n\r" +
                    "Zunächst die Kartoffeln schälen, halbieren und in einem Kochtopf in 20 - 25 Min gar dämpfen. Milch und Butter in einem Topf \n\r " +
                    "erhitzen und die Gewürze dazugeben.\n\r Den Rosmarinzweig eine Weile mitkochen und dann wieder herausnehmen.";
                var lineSplittedText = exampleText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string[] splittedArray = exampleText.Split("\n"[0]);

                for (int i = 0; i < splittedArray.Length; i++)
                {
                    possibleIngredients.Add(splittedArray[i]);

                }
                // if line < 7 add to list
                foreach (string lane in possibleIngredients)
                {

                    string[] laneSplitter = new string[] { " " };
                    string[] words = lane.ToLower().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length < 7)
                    {
                        ingredients.Add(lane);
                   
                    }
                
                }
            return ingredients;
        }

        //check if units included (get units from list: WordCollection
        public List<string> FilterWrongStuffOut(List<string> ingredients, WordCollection wordCollection)
        {

            List<string> filteredList = new List<string>();
            var wordCollectionItems = wordCollection.GetWordList();
            foreach (var unit in ingredients)
            {
                string[] splitter = new string[] { " " };
                string[] words = unit.ToLower().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                
                foreach(string word in words)
                {
                    if (word.Select(w => w.ToString()).Any(wordCollectionItems.Contains))
                    {
                        bool containsItem = filteredList.Any(item => item == unit);
                        // doesnt add if already exists
                        if (!containsItem)
                        {
                            filteredList.Add(unit);
                        }
                        
                        
                    }
                }

            }
            return filteredList;
        }
       
    }
}
