using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Board
    {
        public const int n = 4;
        public int[ , ] cell = new int[n, n];
        int xEmpty, yEmpty;

        public Board()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    cell[i, j] = i * n + j;
            xEmpty = n - 1;
            yEmpty = n - 1;
        }

        public void gen(int Difficult)
        {
            Random rand = new Random();
            for (int i = 0; i <= Difficult; i++)
            {
                switch (rand.Next() % 4)
                {
                    case 0 :
                        moveLeft();
                        break;
                    case 1 :
                        moveRight();
                        break;
                    case 2 :
                        moveUp();
                        break;
                    case 3 :
                        moveDown();
                        break;
                }
            }
        }

        void swap(ref int x, ref int y)
        {
            int buf = x;
            x = y;
            y = buf;
        }

        public void moveLeft()
        {
           if (yEmpty == 0)
                return;
            swap(ref cell[xEmpty, yEmpty], ref cell[xEmpty, yEmpty - 1]);
            yEmpty--;
        }
        public void moveRight()
        {
            if (yEmpty == n - 1)
                return;
            swap(ref cell[xEmpty, yEmpty], ref cell[xEmpty, yEmpty + 1]);
            yEmpty++;
        }

        public void moveUp()
        {
            if (xEmpty == 0)
                return;
            swap(ref cell[xEmpty, yEmpty], ref cell[xEmpty - 1, yEmpty]);
            xEmpty--;
        }
        public void moveDown()
        {
            if (xEmpty == n - 1)
                return;
            swap(ref cell[xEmpty, yEmpty], ref cell[xEmpty + 1, yEmpty]);
            xEmpty++;
        }

        public bool isWon()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (cell[i, j] != i * n + j)
                        return false;
            return true;
        }
    }
}
