/*
Challenge Lab: Tic Tac Toe
allow 2 humans to play tic tac toe, determine when a winner reached, output boards
*/

Board myBoard = new(); //initialize chess board
char userTurn = 'x'; //'x' == x goes     'o' == o goes

while (true)
{
    Console.WriteLine("The board is:\n");
    myBoard.PrintBoard(); //print out board

    Console.WriteLine($"User {userTurn} select an empty spot: ");
    int userSelection = int.Parse(Console.ReadLine());
    Console.WriteLine();
     
    if (!myBoard.SpotAvailable(userSelection)) //if spot already taken
    {
        Console.WriteLine("Invalid entry, try again");
        continue; //go to next iteration of loop so the same user can try again
    }

    myBoard.MakeEntry(userSelection, userTurn); //make the entry
    char winner = myBoard.CheckWinner();
    switch (winner)
    {
        case 'x':
        case 'o': //x wins or o wins
            myBoard.PrintBoard(); //print out winning board
            Console.WriteLine($"Congratulations! The winner is {winner}!");
            return;
        case 't':
            myBoard.PrintBoard();
            Console.WriteLine("Tie game! Better luck next time");
            return;
        default: //no winner yet
            break;
    }


    if (userTurn == 'x') //flip to the other user for next iteration of loop
    {
        userTurn = 'o';
    }
    else
    {        
        userTurn = 'x';
    }

}



//length 9 array, flattened board 2d -> 1d
//0 1 2 3 4 5 6 7 8

//e e e e e e e e e     empty board

//x e e x e e x e e     vertical line win          036 or 147 or 258

//x x x e e e e e e     horizontal line win        012 or 345 or 678

//x e e e x e e e x     diagonal line win          049 or 246

public class Board{
    
    //flattened board to 1d array initialized to all spots 'e'mpty
    public char[] Entries = 
    {
        'e', 'e', 'e',
        'e', 'e', 'e',
        'e', 'e', 'e'
    };

    //2d array of winning combos
    public int[][] WinningCombos =
    {
        [0, 1, 2 ], [3, 4, 5], [6, 7, 8 ], //horizontal line wins
        [0, 3, 6 ], [1, 4, 7 ], [2, 5, 8], //vertical line wins
        [0, 4, 8 ], [2, 4, 6 ]        //diagonal wins
    };

    public bool SpotAvailable(int Position) //check for spot taken
    {
        if (Entries[Position] == 'e')
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public char CheckWinner() // check board for winner, 
    {

        //check for winners by going through each winning combo array, making sure all 3 entries in one line are the same and not 'e'mpty
        foreach ( int[] line in WinningCombos )
        {
            char first = Entries[line[0]];
            if (first != 'e' && first == Entries[line[1]] && first == Entries[line[2]])
            {
                return first;
            }
        }


        foreach (char entry in Entries) //if any empty field, we know the board isn't full -> no tie yet
        {
            if (entry == 'e')
            {
                return 'n';
            }
        }      

        return 't'; //return tie
    }

    public void MakeEntry(int Position , char User)
    {
        Entries[Position] = User; 
    }

    public void PrintBoard() //print out board
    {
        for (int i = 0 ; i < 9 ; i++)
        {
            if (Entries[i] != 'e') //spot not empty
            {
                Console.Write(" " + Entries[i] + " "); //write x or o based on which user has filled the spot
            }
            else //if spot empty write number user would enter to fill it 
            {
                Console.Write(" " + i + " ");
            }

            if (i == 8) 
            {
                Console.WriteLine("\n");
                break; //don't need horizontal line between rows
            }

            if( (i+1) % 3 == 0) //need new line
            {
                Console.WriteLine();
                Console.Write("-----------");
                Console.WriteLine();
            }
            else //don't need new line
            {
                Console.Write("|");
            }            
        }
    }


}



