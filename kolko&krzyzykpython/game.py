from player import Player
from board import Board

class Game:
    def __init__(self):
        self.player_x = Player("Gracz X", "X")
        self.player_o = Player("Gracz O", "O")
        self.current_player = self.player_x
        self.board = Board()

    def switch_turn(self):
        self.current_player = self.player_o if self.current_player == self.player_x else self.player_x

    def reset_game(self):
        self.board.reset()
        self.current_player = self.player_x

    def reset_scores(self):
        self.player_x.score = 0
        self.player_o.score = 0
