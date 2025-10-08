// See https://aka.ms/new-console-template for more information

// Boss Battle: Tic-Tac-Toe

new Game().StartGame();
public class Game
{
    public void StartGame()
    {
        Board board = new Board();
        BoardRenderer renderer = new BoardRenderer();
        Player playerOne = new Player(Cell.X);
        Player playerTwo = new Player(Cell.O);
        int round = 0;
        
        Player currentPlayer = playerOne;

        while (round < 9)
        {
            renderer.Draw(board);
            Console.WriteLine($"It is {currentPlayer.Symbol}'s turn.");
            Square square = currentPlayer.PickSquare(board);
            board.SetCell(square.Row, square.Column, currentPlayer.Symbol);
            if (HasWon(board, Cell.X))
            {
                renderer.Draw(board);
                Console.WriteLine("X is the winner!");
                return;
            }
            else if (HasWon(board, Cell.O))
            {
                renderer.Draw(board);
                Console.WriteLine("O is the winner!");
                return;
            }
            currentPlayer = currentPlayer == playerOne ? playerTwo : playerOne;
            round++;
        }
        renderer.Draw(board);
        Console.WriteLine("It is a draw!");
    }

    private bool HasWon(Board board, Cell cell)
    {
        if (board.GetCell(0, 0) == cell && board.GetCell(0, 1) == cell && board.GetCell(0, 2) == cell) return true;
        if (board.GetCell(1,0) == cell && board.GetCell(1, 1) == cell && board.GetCell(1, 2) == cell) return true;
        if (board.GetCell(2,0) == cell && board.GetCell(2, 1) == cell && board.GetCell(2, 2) == cell) return true;
        
        if (board.GetCell(0, 0) == cell && board.GetCell(1, 0) == cell && board.GetCell(2, 0) == cell) return true;
        if (board.GetCell(0,1) == cell && board.GetCell(1, 1) == cell && board.GetCell(2, 1) == cell) return true;
        if (board.GetCell(0,2) == cell && board.GetCell(1, 2) == cell && board.GetCell(2, 2) == cell) return true;
        
        if (board.GetCell(0,0) == cell && board.GetCell(1, 1) == cell && board.GetCell(2, 2) == cell) return true;
        if (board.GetCell(2,0) == cell && board.GetCell(1, 1) == cell && board.GetCell(0, 2) == cell) return true;
        
        return false;
    }
}

public class Player
{
    public Cell Symbol { get; }

    public Player(Cell symbol)
    {
        Symbol = symbol;
    }

    public Square PickSquare(Board board)
    {
        while (true)
        {
            Console.Write("Which square would you like to pick? ");
            ConsoleKey  key = Console.ReadKey().Key;
            Console.WriteLine();

            Square chosenSquare = key switch
            {   
                ConsoleKey.D7 => new Square(0, 0),
                ConsoleKey.D8 => new Square(0,1),
                ConsoleKey.D9 => new Square(0, 2),
                ConsoleKey.D4 => new Square(1,0),
                ConsoleKey.D5 => new Square(1,1),
                ConsoleKey.D6 => new Square(1,2),
                ConsoleKey.D1 => new Square(2,0),
                ConsoleKey.D2 => new Square(2,1),
                ConsoleKey.D3 => new Square(2,2)
            };
            
            if (board.IsEmpty(chosenSquare.Row, chosenSquare.Column))
                return chosenSquare;
            else 
                Console.WriteLine("Square already picked.");
        }
    }
}


public class BoardRenderer
{
    public void Draw(Board board)
    {
        char[,] symbols = new char[3, 3];
        symbols[0, 0] = GetCharForCell(board.GetCell(0, 0));
        symbols[0, 1] = GetCharForCell(board.GetCell(0, 1));
        symbols[0, 2] = GetCharForCell(board.GetCell(0, 2));
        symbols[1, 0] = GetCharForCell(board.GetCell(1, 0));
        symbols[1, 1] = GetCharForCell(board.GetCell(1, 1));
        symbols[1, 2] = GetCharForCell(board.GetCell(1, 2));
        symbols[2, 0] = GetCharForCell(board.GetCell(2, 0));
        symbols[2, 1] = GetCharForCell(board.GetCell(2, 1));
        symbols[2, 2] = GetCharForCell(board.GetCell(2, 2));
        
        Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 1]} | {symbols[0, 2]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {symbols[1, 0]} | {symbols[1, 1]} | {symbols[1, 2]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {symbols[2, 0]} | {symbols[2, 1]} | {symbols[2, 2]}");
    }

    private char GetCharForCell(Cell cell) => cell switch { Cell.X => 'X', Cell.O => 'O', Cell.Empty => ' ' };
}

public class Square
{
    public int Row { get; }
    public int Column { get; }

    public Square(int row, int column)
    {
        Row = row;
        Column = column;
    }
}


public class Board
{
    private readonly Cell[,] _cells = new Cell[3, 3];

    public Cell GetCell(int row, int col)
    {
        return _cells[row, col];
    }

    public void SetCell(int row, int col, Cell cell)
    {
        _cells[row, col] = cell;
    }

    public bool IsEmpty(int row, int col)
    {
        return _cells[row, col] == Cell.Empty;
    }
}


public enum Cell { Empty, X , O}