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
        public string[] textSplitted(string text)
        {
            string[] splitter = new string[] { " " };
            var lineSplittedText = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] splittedArray = text.Split("\n"[0]);
            return splittedArray;
        }
        public List<string>  SplitLines(string text)
        {
            
                WordCollection wordCollection = new WordCollection();
                List<string> possibleIngredients = new List<string>();
                List<string> ingredients = new List<string>();
                
                string[] splitter = new string[] { " " };
                
                for (int i = 0; i < textSplitted(text).Length; i++)
                {
                    possibleIngredients.Add(textSplitted(text)[i]);

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
        public List<string> Ingredients(List<string> ingredients, WordCollection wordCollection)
        {

            List<string> filteredList = new List<string>();
            var wordCollectionItems = wordCollection.GetWordList();
            foreach (var unit in ingredients)
            {
                string[] splitter = new string[] { " " };
                string[] words = unit.ToLower().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                
                foreach(string word in words)
                {
                    if(wordCollectionItems.Contains(word))
                    
                    {
                        bool containsItem = filteredList.Any(item => item == unit);
                        // doesnt add if already exists  // MAY CAUSED BUG
                        if (!containsItem)
                        {
                            filteredList.Add(unit);
                        }
                        
                        
                    }
                   
                }
                
            }
            return filteredList;
        }

        public string Recipe(List<string> ingredientsList, string text)
        {
            var ingredientsListToArray = ingredientsList.ToArray<string>();
            //var result = string.Join(",", ingredientsListToArray);
            var splittedArray = textSplitted(text);
            foreach (string line in splittedArray)
            {
                if (ingredientsListToArray.Contains(line))
                {
                   
                    splittedArray = splittedArray.Where(val => val != line).ToArray();
                    
                }
            }
            string recipeText = string.Join(",", splittedArray);
            return recipeText;
        }
               
    }
}
