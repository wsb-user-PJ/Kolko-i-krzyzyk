using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolko_krzyzykcs
{
    public class Player
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Score { get; set; }

        public Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
            Score = 0;
        }
    }
}
