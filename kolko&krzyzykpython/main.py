
# -*- coding: utf-8 -*-
import tkinter as tk
from tkinter import messagebox
from game import Game

class TicTacToeApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Kolko i Krzyzyk w Python")
        self.game = Game()
        self.buttons = [[None for _ in range(3)] for _ in range(3)]

        self.label_x = tk.Label(root, text="X: 0", font=("Arial", 12))
        self.label_x.grid(row=4, column=0)
        self.label_o = tk.Label(root, text="O: 0", font=("Arial", 12))
        self.label_o.grid(row=4, column=2)

        self.create_buttons()
        self.create_controls()

    def create_buttons(self):
        for i in range(3):
            for j in range(3):
                btn = tk.Button(self.root, text="", width=10, height=4, font=("Arial", 16),
                                command=lambda i=i, j=j: self.cell_clicked(i, j))
                btn.grid(row=i, column=j)
                self.buttons[i][j] = btn

    def create_controls(self):
        restart_btn = tk.Button(self.root, text="Restart", command=self.restart)
        restart_btn.grid(row=5, column=0, columnspan=1)
        exit_btn = tk.Button(self.root, text="Wyjdz", command=self.root.quit)
        exit_btn.grid(row=5, column=2, columnspan=1)

    def cell_clicked(self, i, j):
        btn = self.buttons[i][j]
        if btn["text"] != "":
            return

        symbol = self.game.current_player.symbol
        btn["text"] = symbol
        self.game.board.grid[i][j] = symbol

        if self.game.board.check_win(symbol):
            messagebox.showinfo("Koniec gry", f"{self.game.current_player.name} wygrywa!")
            self.game.current_player.score += 1
            self.update_scores()
            self.reset_board()
            return

        if self.game.board.is_full():
            messagebox.showinfo("Koniec gry", "Remis!")
            self.reset_board()
            return

        self.game.switch_turn()

    def reset_board(self):
        self.game.reset_game()
        for row in self.buttons:
            for btn in row:
                btn["text"] = ""

    def update_scores(self):
        self.label_x["text"] = f"X: {self.game.player_x.score}"
        self.label_o["text"] = f"O: {self.game.player_o.score}"

    def restart(self):
        self.reset_board()
        self.game.reset_scores()
        self.update_scores()

if __name__ == "__main__":
    root = tk.Tk()
    app = TicTacToeApp(root)
    root.mainloop()
