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
            //BYGGA EN MATRIX @KEANU-BOI

            Console.WriteLine("Ange Matris storlek:>");
            var MatrixXY = Convert.ToInt32(Console.ReadLine());

            var TheMatrix = new int?[MatrixXY, MatrixXY];
            var FacingDirection = Direction.Right;

            int X, Y;
            X = Y = 0;

            for (int i = 0; i < MatrixXY*MatrixXY; i++)
            {
                TheMatrix[X, Y] = StartIndex;
                Console.Write(TheMatrix[X, Y]);
                Console.ReadLine();

                switch (FacingDirection)
                {
                    case Direction.Right:
                        if (X == MatrixXY -1)
                        {
                            FacingDirection = Direction.Down;
                            Y++;
                        } else X++;

                        break;
                    case Direction.Down:
                        if (Y == MatrixXY - 1)
                        {
                            FacingDirection = Direction.Left;
                            X--;
                        } else Y++;
                        break;
                    case Direction.Left:
                        if (X == 0)
                        {
                            FacingDirection = Direction.Up;
                            Y--;
                        }
                        else X--;
                        break;
                    case Direction.Up:
                        if (TheMatrix[X, Y] == null)
                        {
                            FacingDirection = Direction.Right;
                            X++;
                        }
                        else Y--;

                        break;
                }
                
                StartIndex++;

            }

            for (int i = 0; i < MatrixXY; i++)
            {
                for (int j = 0; j < MatrixXY; j++)
                {
                    Console.WriteLine(TheMatrix[j,i]);
                }
            }


            Console.ReadLine();

        }
    }
}
