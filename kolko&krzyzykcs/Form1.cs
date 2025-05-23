using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolko_krzyzykcs
{
    public partial class Form1 : Form
    {
        private Game game;
        private Button[,] buttons;
        public Form1()
        {
            InitializeComponent();
            game = new Game();
            SetupButtons();
        }
        private void SetupButtons()
        {
            buttons = new Button[3, 3]
            {
                { button0, button1, button2 },
                { button3, button4, button5 },
                { button6, button7, button8 }
            };

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    buttons[i, j].Click += Cell_Click;
        }
        private void Cell_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            int row = -1, col = -1;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (buttons[i, j] == clickedButton)
                    {
                        row = i;
                        col = j;
                        break;
                    }

            if (!string.IsNullOrEmpty(clickedButton.Text))
                return;

            clickedButton.Text = game.CurrentPlayer.Symbol;
            game.GameBoard.Grid[row, col] = game.CurrentPlayer.Symbol;

            if (game.GameBoard.CheckWin(game.CurrentPlayer.Symbol))
            {
                MessageBox.Show($"{game.CurrentPlayer.Name} wygrywa!");
                game.CurrentPlayer.Score++;
                UpdateScores();
                ResetBoard();
                return;
            }

            if (game.GameBoard.IsFull())
            {
                MessageBox.Show("Remis!");
                ResetBoard();
                return;
            }

            game.SwitchTurn();
        }
        private void ResetBoard()
        {
            game.ResetGame();
            foreach (var button in buttons)
                button.Text = "";
        }

        private void UpdateScores()
        {
            labelX.Text = game.PlayerX.Score.ToString();
            labelO.Text = game.PlayerO.Score.ToString();
        }
        
        private void restartButton_Click(object sender, EventArgs e) //reset
        {
            ResetBoard();
            game.ResetScores();
            UpdateScores();
            //MessageBox.Show("Gra została zrestartowana. Wyniki wyzerowane."); //test

        }
        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //zbedny kod
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
