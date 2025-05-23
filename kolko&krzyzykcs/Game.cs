using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolko_krzyzykcs
{
    public class Game
    {
        public Player PlayerX { get; set; }
        public Player PlayerO { get; set; }
        public Player CurrentPlayer { get; set; }
        public Board GameBoard { get; set; }

        public Game()
        {
            PlayerX = new Player("Gracz X", "X");
            PlayerO = new Player("Gracz O", "O");
            CurrentPlayer = PlayerX;
            GameBoard = new Board();
        }

        public void SwitchTurn()
        {
            CurrentPlayer = (CurrentPlayer == PlayerX) ? PlayerO : PlayerX;
        }

        public void ResetGame()
        {
            GameBoard.Reset();
            CurrentPlayer = PlayerX;
        }
        public void ResetScores()
        {
            PlayerX.Score = 0;
            PlayerO.Score = 0;
        }

    }

}
