using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
2 player Tic-Tac-TOe Game in 3x3 display board.  
*/
namespace TicTacToe
{
    class Program
    {
        static bool isWin = false;
        //Display Board numbers
        static string[] tempValueArray = new string[9] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        static int milliseconds = 500;
        static void Main(string[] args)
        {
            //Main action to get input from player and update borad, and check who win the game
            do
            {
                Board();
                AskPlayer(1, "X");
                Thread.Sleep(milliseconds);
                Console.Clear();
                Board();
                if (CheckForWin())
                {
                    break;
                }
                AskPlayer(2, "O");
                Thread.Sleep(milliseconds);
                Console.Clear();
                if (CheckForWin())
                {
                    break;
                }
            } while (isWin == false);
        }

        //Ask player generic
        public static void AskPlayer(int playerNumber, string XorO)
        {
            string playerLocation;
            do
            {
                Console.Write($"Player {playerNumber} choose a location to place {XorO} : ");
                playerLocation = Console.ReadLine();
            } while (tempValueArray[int.Parse(playerLocation)] == "X" || tempValueArray[int.Parse(playerLocation)] == "O");

            //Console.Write($"Player {playerNumber} choose a location to place {XorY} : ");
            //string playerLocation = Console.ReadLine();
            //if(tempValueArray[int.Parse(playerLocation)] == "X" || tempValueArray[int.Parse(playerLocation)] == "Y")
            //{
            //    Console.WriteLine("You can not make entry to this location!!!!!");
            //    Thread.Sleep(milliseconds);
            //    Thread.Sleep(milliseconds);
            //    Console.Clear();
            //    Board();
            //    AskPlayer(playerNumber, XorY);
            //}

            tempValueArray[int.Parse(playerLocation)] = XorO;
        }

        public static void callAgain()
        {

        }
        ////Ask player 1 to place an X in the board
        //public static void AskPlayer1()
        //{
        //    Console.Write("Player 1 chose a location to place X: ");
        //    string player1Location = Console.ReadLine();
        //    tempValueArray[int.Parse(player1Location)] = "X";
        //}

        ////Ask player 2 to place an Y in the board
        //public static void AskPlayer2()
        //{
        //    Console.Write("Player 2 chose a location to place O: ");
        //    string player2Location = Console.ReadLine();
        //    tempValueArray[int.Parse(player2Location)] = "O";
        //}

        //Display Board
        public static void Board()
        {
            Console.WriteLine($" {tempValueArray[0]} | {tempValueArray[1]} | {tempValueArray[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {tempValueArray[3]} | {tempValueArray[4]} | {tempValueArray[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {tempValueArray[6]} | {tempValueArray[7]} | {tempValueArray[8]} ");   
        }

        public static bool CheckForWin()
        {
            //Horizontal win check
            for (int i=0; i<9; i = i+3)
            {
                if (tempValueArray[i] == tempValueArray[i + 1] && tempValueArray[i] == tempValueArray[i + 2])
                {
                    Console.WriteLine($"Player {tempValueArray[i]} win the game");
                    isWin = true;
                    return isWin;
                }
            }

            //Vertical win check
            for (int i = 0; i < 3; i = i + 1)
            {
                if (tempValueArray[i] == tempValueArray[i + 3] && tempValueArray[i] == tempValueArray[i + 6])
                {
                    Console.WriteLine($"Player {tempValueArray[i]} win the game");
                    isWin = true;
                    return isWin;
                }
            }

            //Diagonal win check
            if (tempValueArray[0] == tempValueArray[4] && tempValueArray[1] == tempValueArray[8])
            {
                Console.WriteLine($"Player {tempValueArray[0]} win the game");
                isWin = true;
                return isWin;
            }else if(tempValueArray[2] == tempValueArray[4] && tempValueArray[2] == tempValueArray[6])
            {
                Console.WriteLine($"Player {tempValueArray[2]} win the game");
                isWin = true;
                return isWin;
            }
            return isWin;
        }
    }
}
