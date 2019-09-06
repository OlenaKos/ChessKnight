using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Knight3
{
    class Program
    {
        static int deskSize = 6;
        static int[] bx = new int[deskSize * deskSize];
        static int[] by = new int[deskSize * deskSize];
        static int[][] board = new int[deskSize][];


        static void Main(string[] args)
        {

            for (int k = 0; k < deskSize; k++)
            {
                board[k] = new int[deskSize];
            }
            Console.WriteLine("Please enter a first x position");
            bx[0] = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a first y position");
            by[0] = Int32.Parse(Console.ReadLine());

            int s = 1;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (steps(0))
            {
                for (int i = 0; i < deskSize * deskSize; ++i)
                {
                    board[bx[i] - 1][by[i] - 1] = s;
                    ++s;
                }
            }
            else
                Console.WriteLine("No decision");

            sw.Stop();
            Console.WriteLine("Time spent on solution search(sec): {0}", sw.Elapsed);

            for (int i = 0; i < deskSize; i++)
            {
                for (int j = 0; j < deskSize; j++)
                {
                    Console.WriteLine("board[i][j] = {0}", board[i][j]);
                }
            }
            writeBoardExt();

            Console.ReadLine();

        }

        private static bool steps(int c)
        {
            if (c + 1 >= deskSize * deskSize)
                return true;

            for (int dx = -2; dx <= 2; ++dx)
            {
                for (int dy = -2; dy <= 2; ++dy)
                {
                    if (Math.Abs(dx) + Math.Abs(dy) != 3)
                        continue;

                    int xn = bx[c] + dx, yn = by[c] + dy;
                    if (xn < 1 || xn > deskSize || yn < 1 || yn > deskSize)
                        continue;

                    if (сhecking(xn, yn, c))
                        continue;

                    bx[c + 1] = xn; by[c + 1] = yn;
                    if (steps(c + 1))
                        return true;
                }
            }
            return false;
        }

        private static bool сhecking(int x, int y, int c)
        {
            for (int i = 0; i <= c; ++i)
                if (bx[i] == x && by[i] == y)
                    return true;
            return false;
        }

        //private static void writeBoardReDraw()
        //{
        //    int[][] arrDeskTemp = new int[8][];
        //    for (int k = 0; k < deskSize; k++)
        //    {
        //        arrDeskTemp[k] = new int[deskSize];
        //    }

        //    InitializeTempArray(arrDeskTemp);

        //    int step = 0;
        //    for (int k = 0; k < deskSize; k++)
        //    {
        //        for (int n = 0; n < deskSize; n++)
        //        {
        //            Thread.Sleep(1000);
        //            Console.BackgroundColor = ConsoleColor.Black;
        //            Console.Clear();
        //            addNewStepToArray(step, arrDeskTemp, arrDesk);
        //            step++;
        //            PrintTempArray(arrDeskTemp);
        //        }
        //    }
        //}

        private static void writeBoardExt()
        {
            string s;
            for (int i = 0; i < deskSize; i++)
            {
                for (int j = 0; j < deskSize; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;

                            s = String.Format("{0,2}", board[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            s = String.Format("{0,2}", board[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            s = String.Format("{0,2}", board[i][j]) + " ";
                            Console.Write("{0}", s);

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            s = String.Format("{0,2}", board[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                    }

                }

                Console.WriteLine();
            }
        }
    }
}


//board[i][j] = 1
//board[i][j] = 12
//board[i][j] = 9
//board[i][j] = 6
//board[i][j] = 3
//board[i][j] = 14
//board[i][j] = 17
//board[i][j] = 20
//board[i][j] = 10
//board[i][j] = 7
//board[i][j] = 2
//board[i][j] = 13
//board[i][j] = 18
//board[i][j] = 21
//board[i][j] = 4
//board[i][j] = 15
//board[i][j] = 31
//board[i][j] = 28
//board[i][j] = 11
//board[i][j] = 8
//board[i][j] = 5
//board[i][j] = 16
//board[i][j] = 19
//board[i][j] = 22
//board[i][j] = 64
//board[i][j] = 25
//board[i][j] = 32
//board[i][j] = 29
//board[i][j] = 36
//board[i][j] = 23
//board[i][j] = 48
//board[i][j] = 45
//board[i][j] = 33
//board[i][j] = 30
//board[i][j] = 27
//board[i][j] = 24
//board[i][j] = 49
//board[i][j] = 46
//board[i][j] = 37
//board[i][j] = 58
//board[i][j] = 26
//board[i][j] = 63
//board[i][j] = 52
//board[i][j] = 35
//board[i][j] = 40
//board[i][j] = 57
//board[i][j] = 44
//board[i][j] = 47
//board[i][j] = 53
//board[i][j] = 34
//board[i][j] = 61
//board[i][j] = 50
//board[i][j] = 55
//board[i][j] = 42
//board[i][j] = 59
//board[i][j] = 38
//board[i][j] = 62
//board[i][j] = 51
//board[i][j] = 54
//board[i][j] = 41
//board[i][j] = 60
//board[i][j] = 39
//board[i][j] = 56
//board[i][j] = 43
