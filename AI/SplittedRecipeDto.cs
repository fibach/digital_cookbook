using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public  class SplittedRecipeDto
    {
        public string Instruction {  get; set; }
        public IEnumerable<string> Ingridients {  get; set; }

        
    }
}
