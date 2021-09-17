using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AI.AILogic
{
    public class Logic
    {
        WordCollection wordCollection = new WordCollection();
        public void disassembleText()
        {
            string exampleText = "1 kg Kartoffeln,mehlig kochend 120 g Butter 120 ml Milch 1 Prise(m) Muskat Salz und Pfeffer 1 Zweig/e Rosmarin \n" +
                "Zunächst die Kartoffeln schälen, halbieren und in einem Kochtopf in 20 - 25 Min gar dämpfen. Milch und Butter in einem Topf \n " +
                "erhitzen und die Gewürze dazugeben.Den Rosmarinzweig eine Weile mitkochen und dann wieder herausnehmen.";

            string[] arrayExampleText =  new[] { exampleText };
            foreach(string word in arrayExampleText)
            {
                Console.WriteLine(word)
;            }
            //List contains 1 - 10000
            List<int> numberList = new List<int>();
            // List contains 1 - 10000 as string/words
            List<string> numberListEntriesAsWords = new List<string>();
            for(int i =0; i<10001; i++)
            {
                numberList.Add(i);
            }
            foreach(int i in numberList)
            {
                numberListEntriesAsWords.Add(i.ToString());
            }
            Console.WriteLine(numberList);
            Console.WriteLine(numberListEntriesAsWords);
           


            // Get numbers from Text
            //string textWithoutWhiteSpaces = Regex.Replace(exampleText, @"\s+", "");
            string[] splitter = new string[] { " " };
            string[] words = exampleText.ToLower().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            string[] numbers = Regex.Split(exampleText, @"\D+");
            List<string> numbersAsString = new List<string>();
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    Console.WriteLine("Number: {0}", i);
                    string a = i.ToString();
                    numbersAsString.Add(a);
                }
            }          

                       
        }


    }
}
