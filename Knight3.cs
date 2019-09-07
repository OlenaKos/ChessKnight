using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Knight3
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] board = new int[8][];
            initializeBoard(board);
            int[][] solution = new int[8][];

            Console.WriteLine("Please enter a first x position");
            int initialX = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a first y position");
            int initialY = Int32.Parse(Console.ReadLine());

            solution = getSolutionBoard(initialX, initialY, board);
            //printSolutionBoard(solution);
            drawBoard(solution);
            //drawBoardReDraw(solution);

            Console.ReadLine();

        }
        private static void initializeBoard(int[][] board)
        {
            board[0] = new int[8] { 50, 11, 24, 63, 14, 37, 26, 35 };
            board[1] = new int[8] { 23, 62, 51, 12, 25, 34, 15, 38 };
            board[2] = new int[8] { 10, 49, 64, 21, 40, 13, 36, 27 };
            board[3] = new int[8] { 61, 22, 9, 52, 33, 28, 39, 16 };
            board[4] = new int[8] { 48, 7, 60, 1, 20, 41, 54, 29 };
            board[5] = new int[8] { 59, 4, 45, 8, 53, 32, 17, 42 };
            board[6] = new int[8] { 6, 47, 2, 57, 44, 19, 30, 55 };
            board[7] = new int[8] { 3, 58, 5, 46, 31, 56, 43, 18 };
        }

        private static int[][] getSolutionBoard(int initialX, int initialY, int[][] board)
        {
            int[][] solution = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                solution[i] = new int[8];
            }

            int x = initialX - 1, y = initialY - 1;// numeration of array from 1, while desk from 0
            int jumpDown = board[x][y] - 1;//if value = 50 we define shift needed to recalculate steps order starting from 1, making 50 = 1, 51 = 2, 52 = 3, ... 64 = 14.
            int jumpUp = 64 - board[x][y] + 1; // if value = 1 we define the rest we need to add, 64 - 50 + 1, so previously 1 = 15, 2 = 16, 3 = 17.

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i][j] > jumpDown)
                    {
                        solution[i][j] = board[i][j] - jumpDown;
                    }
                    else
                    {
                        solution[i][j] = board[i][j] + jumpUp;
                    }
                }
            }
            return solution;
        }

        private static void printSolutionBoard(int[][] solution)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.WriteLine("solution[i][j] = {0}", solution[i][j]);
                }
            }
        }

        private static void drawBoardReDraw(int[][] solution)
        {
            int[][] tempBoard = new int[8][];
            for (int k = 0; k < 8; k++)
            {
                tempBoard[k] = new int[8];
            }

            int step = 1;
            for (int k = 0; k < 8; k++)
            {
                for (int n = 0; n < 8; n++)
                {
                    Thread.Sleep(10);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    addNewStepToBoard(step, tempBoard, solution);
                    drawBoard(tempBoard);
                    step++;
                }
            }
        }

        private static void addNewStepToBoard(int step, int[][] tempBoard, int[][] solution)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (solution[i][j] == step)
                    {
                        tempBoard[i][j] = solution[i][j];
                        break;
                    }
                }
            }
        }

        private static void drawBoard(int[][] solution)
        {
            string s;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;

                            s = String.Format("{0,2}", solution[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            s = String.Format("{0,2}", solution[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            s = String.Format("{0,2}", solution[i][j]) + " ";
                            Console.Write("{0}", s);

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            s = String.Format("{0,2}", solution[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                    }

                }

                Console.WriteLine();
            }
        }
    }
}
