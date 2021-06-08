using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testo
{
    class Testa
    {

        enum Direction
        {
            Right,
            Down,
            Left,
            Up
        }

        public void Run()
        {
            testabranch(1);
        }

        public void testabranch(int StartIndex)
        {
            Console.WriteLine("Ange Matris storlek (MAX 15):>");
            var MatrixXY = Convert.ToInt32(Console.ReadLine()); //lägg till funktion som kontrollerar om input är int

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

                    if (TheMatrix[j, i] < 10) StrBuilder.Append($"[{TheMatrix[j,i]}  ]");
                    else if (TheMatrix[j, i] < 100) StrBuilder.Append($"[{TheMatrix[j, i]} ]");
                    else StrBuilder.Append($"[{TheMatrix[j, i]}]");
                }
            }

            Console.WriteLine(StrBuilder.ToString());
            Console.ReadLine();

        }
    }
}
