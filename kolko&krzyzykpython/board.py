class Board:
    def __init__(self):
        self.grid = [["" for _ in range(3)] for _ in range(3)]

    def reset(self):
        self.grid = [["" for _ in range(3)] for _ in range(3)]

    def check_win(self, symbol):
        for i in range(3):
            if all(self.grid[i][j] == symbol for j in range(3)) or \
               all(self.grid[j][i] == symbol for j in range(3)):
                return True
        if all(self.grid[i][i] == symbol for i in range(3)) or \
           all(self.grid[i][2 - i] == symbol for i in range(3)):
            return True
        return False

    def is_full(self):
        return all(cell != "" for row in self.grid for cell in row)
