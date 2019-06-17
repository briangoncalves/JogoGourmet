using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet.Domain
{
    public class FoodChain
    {
        public string Food { get; set; }

        public FoodChain Yes { get; set; }

        public FoodChain No { get; set; }

        public FoodChain Parent { get; set; }

        public bool IsCategory { get; set; }
    }
}
