using System;
using System.Text;
using System.Numerics;
using System.Windows.Forms;

namespace Testo
{
    class Testa
    {
        enum Direction
        {
            Right,Down,Left,Up
        }

        public void Run()
        {
            //spiralmatris
            Console.WriteLine("\n   -----------------------------");
            Console.WriteLine("   |                           |");
            Console.WriteLine("   |         THE MATRIX        |");
            Console.WriteLine("   |                           |");
            Console.WriteLine("   -----------------------------\n");
            Console.Write("ANGE START INDEX:>");
            var StartIndex = ReturnInteger(Console.CursorLeft);
            SpiralMatrix(StartIndex);
            Console.ReadLine();
            Console.Clear();

            //fibonacci
            Console.Write("\n FIBONACCI ITTERATIONS:>");
            var Itterations = ReturnInteger(Console.CursorLeft);
            Fibonacci(Itterations);
            Console.ReadLine();
            Console.Clear();

            kaptenmorgan();

        }

        public void SpiralMatrix(int StartIndex)
        {
            Console.Write("Ange Matris storlek (MAX 15):>");
            var MatrixXY = ReturnInteger(Console.CursorLeft);

            var TheMatrix = new int?[MatrixXY, MatrixXY];
            var FacingDirection = Direction.Right;

            int X, Y;
            X = Y = 0;

            for (int i = 0; i < MatrixXY*MatrixXY; i++)
            {
                TheMatrix[X, Y] = StartIndex;

                switch (FacingDirection)
                {
                    case Direction.Right:
                        if (X == MatrixXY -1 || TheMatrix[X+1, Y] != null)
                        {
                            FacingDirection = Direction.Down;
                            Y++;
                        } else X++;

                        break;
                    case Direction.Down:
                        if (Y == MatrixXY - 1 || TheMatrix[X, Y+1] != null)
                        {
                            FacingDirection = Direction.Left;
                            X--;
                        } else Y++;
                        break;
                    case Direction.Left:
                        if (X == 0 || TheMatrix[X-1, Y] != null)
                        {
                            FacingDirection = Direction.Up;
                            Y--;
                        }
                        else X--;
                        break;
                    case Direction.Up:
                        if (TheMatrix[X, Y-1] != null)
                        {
                            FacingDirection = Direction.Right;
                            X++;
                        }
                        else Y--;
                        break;
                }
                StartIndex++;
            }

            var StrBuilder = new StringBuilder();

            for (int i = 0; i < MatrixXY; i++)
            {
                for (int j = 0; j < MatrixXY; j++)
                {
                    if (j == 0 && i > 0) StrBuilder.Append("\n");

                    if (TheMatrix[j, i] < 10) StrBuilder.Append($"[ {TheMatrix[j,i]} ]");
                    else if (TheMatrix[j, i] < 100) StrBuilder.Append($"[{TheMatrix[j, i]} ]");
                    else StrBuilder.Append($"[{TheMatrix[j, i]}]");
                }
            }

            Console.WriteLine($"\n{StrBuilder.ToString()}");            
        }

        public void Fibonacci(int Itterations)
        {            
            var StrBuilder = new StringBuilder();
            BigInteger P = 0, N = 1, PlaceHolder = P;            

            for (int i = 0; i < Itterations; i++)
            {
                if (i == 0) StrBuilder.Append($"{P}\n{N}\n");
                else StrBuilder.Append($"{N}\n");

                PlaceHolder = P + N;
                P = N;
                N = PlaceHolder;
            }
            Console.WriteLine(StrBuilder.ToString());
        }


        public void kaptenmorgan()
        {
            Console.WriteLine("KAPTEN MORGAN PÅSTÅR ATT");
            Console.WriteLine("A ÄR B ÄR DETSAMMA SOM INTE A ÄR INTE B");
            Console.WriteLine("SANT ELLER FALSKT?");
            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.Run(new testi());
            Console.ReadLine();
        }

        //snapshottar consoleposition och skriver över tills korrekt input
        int ReturnInteger(int ConsolePos)
        {
            var Check = false;
            var str = "";

            while (Check == false)
            {
                str = Console.ReadLine();
                Check = IsDigitsOnly(str);
                if (Check == false)
                {
                    Console.SetCursorPosition(ConsolePos, Console.CursorTop-1);
                    for (int i = 0; i < str.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(ConsolePos, Console.CursorTop);
                }
            }
            return Convert.ToInt32(str);
        }


        //från stackoverflow nedan
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

    }
}
