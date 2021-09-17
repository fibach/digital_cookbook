using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.AILogic
{
    public class WordCollection
    {
        
        
        public List<string> GetWordList()
        {                            
            List<string> quantities = new List<string>();
            quantities.Add("g");
            quantities.Add("mg");
            quantities.Add("kg");
            quantities.Add("l");
            quantities.Add("ml");
            quantities.Add("prise");
            quantities.Add("prisen");
            quantities.Add("prise(n)");
            quantities.Add("prise(m)");
            quantities.Add("löffel");
            quantities.Add("tl");
            quantities.Add("teelöffel");
            quantities.Add("esslöffel");
            quantities.Add("el");
            quantities.Add("etwas");
            quantities.Add("handvoll");

            return quantities;

        }
    }
}
