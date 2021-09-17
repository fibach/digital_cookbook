using AI.AILogic;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
 

namespace AI.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string testText = "1 kg Kartoffeln,mehlig kochend\n 120 g Butter\n 120 ml Milch\n 1 Prise(m) Muskat Salz und Pfeffer\n 1 Zweig/e Rosmarin\n\r" +
                "Zunächst die Kartoffeln schälen, halbieren und in einem Kochtopf in 20 - 25 Min gar dämpfen. Milch und Butter in einem Topf\n erhitzen und die Gewürze dazugeben.\n\r Den Rosmarinzweig eine Weile mitkochen und dann wieder herausnehmen.";
            LineLogic lineLogic = new();
           
            var actual = lineLogic.SplitLines(testText);
            List<string> expected = new List<string> { "1 kg Kartoffeln,mehlig kochend", " 120 g Butter"," 120 ml Milch", " 1 Prise(m) Muskat Salz und Pfeffer", " 1 Zweig/e Rosmarin", " erhitzen und die Gewürze dazugeben." };
            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void ShouldParseIngredientWithNumber()
        {
            string testText = "2 Knoblauchzehen\n 3 EL Butter\n Das hier ist nur ein Text für Testzwecke :)\n Das ist TestText";
            WordCollection wordCollection = new();
            LineLogic lineLogic = new();
            var splitLines = lineLogic.SplitLines(testText);
            var acutal = lineLogic.Ingredients(splitLines, wordCollection);
            List<string> expected = new List<string> { "2 Knoblauchzehen", " 3 EL Butter" };
            acutal.Should().BeEquivalentTo(expected);
        }
    }
}