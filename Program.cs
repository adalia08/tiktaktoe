using System;
using static System.Console;

namespace Problem2
{
	static class TicTacToe
	{
		// board for tic-tac-toe game
		// 0 is an empty cell
		// 1 is an X 
		// 2 is an O
		
		static int[,] board = new int[3,3]{
			{0,0,0},
			{0,0,0},
			{0,0,0}
			};
			
			public static string winner = " ";
		// Method for adding Symbol to the board. 
		// If move is possible, returns true. 
		// If move is not possible, returne false
		// symbole is 1 for X, 2 for O
		public static bool AddSymbol(int row, int col, int playerSymbol)
		{
			if(board[row,col] == 0){
				board[row,col] = playerSymbol;
				return true;
			}else{
				return false;
			}
		}
	
		
		
		
		// Method for displaying the board
		public static void PrintBoard( )
		{
			Console.Clear();
			WriteLine( "    0   1   2 " );
			WriteLine( "             " );
			WriteLine( "0  {0}|{1}|{2} ", Mark( board[ 0, 0 ]), Mark( board[ 0, 1 ]), Mark( board[ 0, 2 ]) );
			WriteLine( "   ---+---+--- " );
			WriteLine( "1  {0}|{1}|{2} ", Mark( board[ 1, 0 ]), Mark( board[ 1, 1 ]), Mark( board[ 1, 2 ]) );
			WriteLine( "   ---+---+--- " );
			WriteLine( "2  {0}|{1}|{2} ", Mark( board[ 2, 0 ]), Mark( board[ 2, 1 ]), Mark( board[ 2, 2 ] ));
		}
		static string Mark( int boardValue )
		{
			if( boardValue == 1 ) return " X ";
			if( boardValue == 2 ) return " O ";
			return "   ";
		}
		
		public static bool gameOver(){
			for(int x = 1; x < 3; x++){
				if(board[0,0] == x){
					if(board[0,1] == x){
						if(board[0,2] == x){
							
							return true;
						}
					}else if(board[1,0] == x){
						if(board[2,0] == x){
							
							return true;
						}
					}else if(board[1,1] == x){
						if(board[2,2] == x){
							
							return true;
						}
					}
				}else if(board[1,0] == x){
					if(board[1,1] == x){
						if(board[1,2] == x){
						
							return true;
						}
					}
				}else if(board[2,0] == x){
					if(board[2,1] == x){
						if(board[2,2] == x){
							
							return true;
						}	
					}
				}else if(board[0,1] == x){
					if(board[1,1] == x){
						if(board[2,1] == x){
							
							return true;
						}
					}
				}else if(board[0,2] == x){
					if(board[1,2] == x){
						if(board[2,2] == x){
													
							return true;
						}
					}else if(board[1,1] == x){
						if(board[2,0] == x){
							
							return true;
						}
					}
				}else{
					int full = 0
					for(int row = 0; row < 3; row++){
						for(int col = 0; col < 3; col++){
							if(board[row,col] != 0){
								full++;
							}
						}
					}
					if(full == 9)
						TicTacToe.winner = "it's a draw!";
						return true;
					}
				}
			}
			return false;
		}
	}
	
	
    class Program
    {
        static void Main(string[] args)
        {
			
			// Variables for tracking turn number and state of game
            int turn = 0;
            bool gameRunning = true;
            

            // Show the empty board at start
            TicTacToe.PrintBoard();
            
            // Loop that repeats for game
            while(gameRunning)
            {
								

				
				// Tell user which turn it is
				WriteLine("Turn {0}",turn);

	
				// Tell the user whose turn it is
				if(turn % 2 == 0)
				{
					WriteLine("It is X-Player's turn");
				}
				else
				{
					WriteLine("It is O-Player's turn");
				}
				
				// Inform the user of instructions
				WriteLine("Please enter coordinates of cell you would like to enter your symbol");
				WriteLine("Coordinates are to be input as a code ab, where");
				WriteLine("a denotes the row in index 0 and");
				WriteLine("b denotes the column in index 0.");
				WriteLine("Example: 12");
				
				
				// Tell the user whose turn it is
				if(turn % 2 == 0)
				{
					// Code for x player
					// Get code from user
					if(TicTacToe.gameOver()){
						gameRunning = false;
					}
					Write("Enter code for X: ");
					string codeFromPlayer = ReadLine();
					
					int row = int.Parse(codeFromPlayer[0].ToString());
					int col = int.Parse(codeFromPlayer[1].ToString());
					
					bool validMove = TicTacToe.AddSymbol(row, col,1);
					while(!validMove)
					{
						WriteLine("Invalid move.");
						Write("Enter code for X: ");
						codeFromPlayer = ReadLine();
					
						row = int.Parse(codeFromPlayer[0].ToString());
						col = int.Parse(codeFromPlayer[1].ToString());
						
						validMove = TicTacToe.AddSymbol(row, col,1);
					}
					if(TicTacToe.gameOver()){
						WriteLine("X wins!");
						TicTacToe.winner = "X wins!";
						gameRunning = false;
					}
					
				}
				else
				{
					// Code for O player
					// Get code from user
					if(TicTacToe.gameOver()){
						gameRunning = false;
					}
					Write("Enter code for O: ");
					
					string codeFromPlayer = ReadLine();
					
					int row = int.Parse(codeFromPlayer[0].ToString());
					int col = int.Parse(codeFromPlayer[1].ToString());
					
					bool validMove = TicTacToe.AddSymbol(row, col,2);
					while(!validMove)
					{
						WriteLine("Invalid move.");
						Write("Enter code for O: ");
						codeFromPlayer = ReadLine();
					
						row = int.Parse(codeFromPlayer[0].ToString());
						col = int.Parse(codeFromPlayer[1].ToString());
						
						validMove = TicTacToe.AddSymbol(row, col, 2);
					}
					
					if(TicTacToe.gameOver()){
						WriteLine("O wins!");
						TicTacToe.winner = "O wins!";
						gameRunning = false;
					}
				}

						
				
				// Print the current state of the board
				TicTacToe.PrintBoard();
				
				WriteLine(TicTacToe.winner);
				
				
				
				
				
				// Increment turn counter
				turn += 1;

			}
        }
    }
}
