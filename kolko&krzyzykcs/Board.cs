using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolko_krzyzykcs
{
    public class Board
    {
        public string[,] Grid { get; set; } = new string[3, 3];

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Grid[i, j] = "";
        }

        public bool CheckWin(string symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Grid[i, 0] == symbol && Grid[i, 1] == symbol && Grid[i, 2] == symbol) return true;
                if (Grid[0, i] == symbol && Grid[1, i] == symbol && Grid[2, i] == symbol) return true;
            }
            if (Grid[0, 0] == symbol && Grid[1, 1] == symbol && Grid[2, 2] == symbol) return true;
            if (Grid[0, 2] == symbol && Grid[1, 1] == symbol && Grid[2, 0] == symbol) return true;

            return false;
        }

        public bool IsFull()
        {
            foreach (var cell in Grid)
                if (string.IsNullOrEmpty(cell))
                    return false;
            return true;
        }
    }

}
