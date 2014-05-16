using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class CellGraph
    {


        private int MaxX;
        private int MaxY;

        private Cell rootCell;

        private Cell[][] _debug;

        public CellGraph(int x, int y)
        {
            this.MaxX = x;
            this.MaxY = y;

            this.GenerateEmptyGraph();

        }



        public void GenerateEmptyGraph()
        {

            _debug = new Cell[MaxX][];

            for (int i = 0; i < MaxX; i++)
            {
                _debug[i] = new Cell[MaxY];
                for (int j = 0; j < MaxY; j++)
                {
                    _debug[i][j] = new Cell(new Position(i, j));

                }
            }

            for (int x = 0; x < MaxX; x++)
            {
                for (int y = 0; y < MaxY; y++)
                {
                    //[x][y]
                    //Left neightbor
                    if (x > 0)
                    {
                        _debug[x][y].NeighborCells.Add(_debug[x - 1][y]);
                    }

                    //right neighbor
                    if (x < MaxX - 1)
                    {
                        _debug[x][y].NeighborCells.Add(_debug[x + 1][y]);
                    }

                    //north neigh
                    if (y > 0)
                    {
                        _debug[x][y].NeighborCells.Add(_debug[x][y - 1]);

                    }

                    if (y < MaxY - 1)
                    {
                        _debug[x][y].NeighborCells.Add(_debug[x][y + 1]);

                    }

                }
            }

            rootCell = _debug[0][0];


        }




        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    b.Append(_debug[x][y]);
                }
                b.Append("\n");
            }
            return b.ToString();
        }


        public Cell GetCellByPosition(Position p)
        {

            return rootCell.CellAtPosition(p);

        }



    }
}
