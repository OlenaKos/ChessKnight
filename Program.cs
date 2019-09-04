using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;

//using ConsoleExtender;

//namespace ConsoleExtender
//{
//    [StructLayout(LayoutKind.Sequential, Pack = 1)]
//    public struct ConsoleFont
//    {
//        public uint Index;
//        public short SizeX, SizeY;
//    }

//    public static class ConsoleHelper
//    {
//        //[DllImport("kernel32")]
//        //public static extern bool SetConsoleIcon(IntPtr hIcon);

//        //public static bool SetConsoleIcon(Icon icon)
//        //{
//        //    return SetConsoleIcon(icon.Handle);
//        //}

//        [DllImport("kernel32")]
//        private extern static bool SetConsoleFont(IntPtr hOutput, uint index);

//        private enum StdHandle
//        {
//            OutputHandle = -11
//        }

//        [DllImport("kernel32")]
//        private static extern IntPtr GetStdHandle(StdHandle index);

//        public static bool SetConsoleFont(uint index)
//        {
//            return SetConsoleFont(GetStdHandle(StdHandle.OutputHandle), index);
//        }

//        [DllImport("kernel32")]
//        private static extern bool GetConsoleFontInfo(IntPtr hOutput, [MarshalAs(UnmanagedType.Bool)]bool bMaximize,
//            uint count, [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFont[] fonts);

//        [DllImport("kernel32")]
//        private static extern uint GetNumberOfConsoleFonts();

//        public static uint ConsoleFontsCount
//        {
//            get
//            {
//                return GetNumberOfConsoleFonts();
//            }
//        }

//        public static ConsoleFont[] ConsoleFonts
//        {
//            get
//            {
//                ConsoleFont[] fonts = new ConsoleFont[GetNumberOfConsoleFonts()];
//                if (fonts.Length > 0)
//                    GetConsoleFontInfo(GetStdHandle(StdHandle.OutputHandle), false, (uint)fonts.Length, fonts);
//                return fonts;
//            }
//        }

//    }
//}

namespace HorsePower
{
    class Program
    {
        static int[][] arrDesk = new int[8][];
        static int deskSize = 8;

        static int[] row = new int[64];
        static int[] col = new int[64];
        static int[] ktmove1 = { -2, -1, 1, 2, 2, 1, -1, -2 };
        static int[] ktmove2 = { 1, 2, 2, 1, -1, -2, -2, -1 };

        static int i = 0, j = 0, move_num = 0;


        static void Main(string[] args)
        {
            for (int k = 0; k < 8; k++)
            {
                arrDesk[k] = new int[8];
            }
            Console.WriteLine("Please enter a first x position");
            i = Int32.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Please enter a first y position");
            j = Int32.Parse(Console.ReadLine()) - 1;
            addKnight();
        }

        private static void addKnight()
        {
            int b, e;

            //mark cell as attended and remember coordinates of cell
            arrDesk[i][j] = move_num;
            row[move_num] = i;
            col[move_num] = j;
            move_num++;

            //check 8 possible knight moves
            for (int a = 0; a <= 7; a++)
            {
                // if all possible moves are done print them
                if (move_num >= 64)
                {
                    writeBoardReDraw();
                    Console.ReadLine();
                    System.Environment.Exit(1);
                }

                //check column and row for the next move
                b = i + ktmove1[a];
                e = j + ktmove2[a];

                //checking that after making a move_num knight is still on the chess desk
                if (b < 0 || b > 7 || e < 0 || e > 7)
                    continue;

                //checking if we already attended that cell
                if (arrDesk[b][e] != 0)
                    continue;
                i = b;
                j = e;
                addKnight();

            }
            //decrease counter of moves and try to make next move
            move_num--;

            //clear cell previously knight possessed
            arrDesk[row[move_num]][col[move_num]] = 0;
            move_num--; //try to do next step

            i = row[move_num];
            j = col[move_num];
            move_num++;


        }

        private static void writeBoardReDraw()
        {
            int[][] arrDeskTemp = new int[8][];
            for (int k = 0; k < deskSize; k++)
            {
                arrDeskTemp[k] = new int[8];
            }

            InitializeTempArray(arrDeskTemp);

            int step = 0;
            for (int k = 0; k < deskSize; k++)
            {
                for (int n = 0; n < deskSize; n++)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    addNewStepToArray(step, arrDeskTemp, arrDesk);
                    step++;
                    PrintTempArray(arrDeskTemp);
                }
            }
        }

        private static void InitializeTempArray(int[][] arrDeskTemp)
        {
            for (int i = 0; i < deskSize; i++)
            {
                for (int j = 0; j < deskSize; j++)
                {
                    arrDeskTemp[i][j] = 0;
                }
            }
        }

        private static void addNewStepToArray(int step, int[][] arrDeskTemp, int[][] arrDesk)
        {

            for (int i = 0; i < deskSize; i++)
            {
                for (int j = 0; j < deskSize; j++)
                {

                    if (arrDesk[i][j] == step)
                    {
                        arrDeskTemp[i][j] = arrDesk[i][j];
                        break;
                    }
                }
            }


        }

        private static void PrintTempArray(int[][] arrDeskTemp)
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

                        s = String.Format("{0,2}", arrDeskTemp[i][j]) + " ";
                        Console.Write("{0}", s);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        s = String.Format("{0,2}", arrDeskTemp[i][j]) + " ";
                        Console.Write("{0}", s);
                    }
                }
                else
                {
                    if (j % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        s = String.Format("{0,2}", arrDeskTemp[i][j]) + " ";
                        Console.Write("{0}", s);

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        s = String.Format("{0,2}", arrDeskTemp[i][j]) + " ";
                        Console.Write("{0}", s);
                    }
                }
            }
                Console.WriteLine();
        }
    }

        private static void writeBoardExt()
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
                            
                            s = String.Format("{0,2}", arrDesk[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            s = String.Format("{0,2}", arrDesk[i][j]) + " ";
                            Console.Write("{0}", s);
                            //Console.Write("{0}\t", arrDesk[i][j]);
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            s = String.Format("{0,2}", arrDesk[i][j]) + " ";
                            Console.Write("{0}", s);

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            s = String.Format("{0,2}", arrDesk[i][j]) + " ";
                            Console.Write("{0}", s);
                        }
                    }

                }

                Console.WriteLine();
            }
        }
    }
}