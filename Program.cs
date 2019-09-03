using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//namespace Chess
//{
//    class Program
//    {
//        static int[,] Ar = new int[8, 8];
//        static int X, Y, n;

//        static void Main(string[] args)
//        {
//            int[,] Ar = new int[8, 8];
//            Console.Write("Enter X (1-8): ");
//            X = Int32.Parse(Console.ReadLine()) - 1;
//            Console.Write("Enter Y (1-8): ");
//            Y = Int32.Parse(Console.ReadLine()) - 1;
//            Move(X, Y);
//            Console.ReadLine();

//        }

//        static void Move(int X, int Y)
//        {
//            int iX = 0, iY = 0, nn = ++n;
//            bool WasStep = false;
//            Ar[X, Y] = 1;
//            for (int i = 0; i < 8; i++)
//            {
//                switch (i)
//                {
//                    case 0: iX = X + 1; iY = Y - 2; break;
//                    case 1: iX = X + 2; iY = Y + 1; break;
//                    case 2: iX = X - 1; iY = Y + 2; break;
//                    case 3: iX = X - 2; iY = Y - 1; break;
//                    case 4: iX = X - 1; iY = Y - 2; break;
//                    case 5: iX = X + 2; iY = Y - 1; break;
//                    case 6: iX = X + 1; iY = Y + 2; break;
//                    case 7: iX = X - 2; iY = Y + 1; break;
//                }
//                if (iX > -1 && iX < 8 && iY > -1 && iY < 8 && Ar[iX, iY] == 0)
//                {
//                    WasStep = true;
//                    Console.WriteLine("{0,4}:  {1}-{2}  ->   {3}-{4}", "(" + nn + ")", X + 1, Y + 1, iX + 1, iY + 1);
//                    writeBoard();
//                    Move(iX, iY);
//                }
//            }
//            if (!WasStep) n--;
//        }

//        private static void writeBoard()
//        {
//            for (int i = 0; i < 8; i++)
//            {
//                for (int j = 0; j < 8; j++)
//                {
//                    Console.Write("{0} ", Ar[i, j]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}

namespace HorsePower
{
    class Program
    {
        static int[][] arrDesk = new int[8][];

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
            for (int a = 0; a <=7; a++)
            {
                // if all possible moves are done print them
                if (move_num >= 64) {
                    writeBoard();
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
                if (arrDesk[b][e] != 0 )
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

        private static void writeBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0}\t", arrDesk[i][j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}


       //private static void addKnight()
       // {
       //     int b, e;



       //     //mark cell as attended and remember coordinates of cell
       //     arrDesk[i][j] = 1;
       //     row[move_num] = i;
       //     col[move_num] = j;
       //     move_num++;

       //     //check 8 possible knight moves
       //     for (int a = 0; a <=7; a++)
       //     {
       //         // if all possible moves are done print them
       //         if (move_num >= 64) {
       //             writeBoard();
       //             Console.ReadLine();
       //             System.Environment.Exit(1);
       //         }
                
       //         //check column and row for the next move
       //         b = i + ktmove1[a];
       //         e = j + ktmove2[a];

       //         //checking that after making a move_num knight is still on the chess desk
       //         if (b < 0 || b > 7 || e < 0 || e > 7)
       //             continue;

       //         //checking if we already attended that cell
       //         if (arrDesk[b][e] == 1)
       //             continue;
       //         i = b;
       //         j = e;
       //         addKnight();

       //     }
       //     //decrease counter of moves and try to make next move
       //     move_num--;

       //     //clear cell previously knight possessed
       //     arrDesk[row[move_num]][col[move_num]] = 0;
       //     move_num--; //try to do next step

       //     i = row[move_num];
       //     j = col[move_num];
       //     move_num++;
            

       // }
