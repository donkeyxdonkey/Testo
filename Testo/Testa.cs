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
            //BYGGA EN MATRIX @KEANU

            Console.WriteLine("Ange Matris storlek:>");
            var MatrixXY = Convert.ToInt32(Console.ReadLine());

            var TheMatrix = new int[MatrixXY, MatrixXY];

        }
    }
}
