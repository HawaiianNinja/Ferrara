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

        private Cell[][] _graphBuildingArray;

        public CellGraph(int x, int y)
        {
            this.MaxX = x;
            this.MaxY = y;

            this.GenerateEmptyGraph();

        }



        public void GenerateEmptyGraph()
        {

            _graphBuildingArray = new Cell[MaxX][];

            for (int i = 0; i < MaxX; i++)
            {
                _graphBuildingArray[i] = new Cell[MaxY];
                for (int j = 0; j < MaxY; j++)
                {
                    _graphBuildingArray[i][j] = new Cell(new Position(i, j));

                }
            }

            for (int x = 0; x < MaxX; x++)
            {
                for (int y = 0; y < MaxY; y++)
                {

                    Cell c = _graphBuildingArray[x][y];

                    //iterate over all 8 cells around x,y
                    for (int i = x - 1; (i <= x + 1); i++)
                    {
                        for (int j = y - 1; (j <= y + 1); j++)
                        {




                            int ti = Math.Min(Math.Abs(i), Math.Abs(MaxX - 1));
                            int tj = Math.Min(Math.Abs(j), Math.Abs(MaxY - 1));

                            Cell tentativeNeighborCell = _graphBuildingArray[ti][tj];

                            if (c.Position.Equals(new Position(0, 2)))
                            {
                                if (!c.Equals(tentativeNeighborCell)
                               && !c.NeighborCells.Contains(tentativeNeighborCell))
                                {
                                    c.NeighborCells.Add(tentativeNeighborCell);
                                }
                            }
                            else
                            {

                                if (!c.Equals(tentativeNeighborCell)
                                    && !c.NeighborCells.Contains(tentativeNeighborCell))
                                {
                                    c.NeighborCells.Add(tentativeNeighborCell);
                                }
                            }

                      



                        }

                        
                    }

                }
            }

            rootCell = _graphBuildingArray[0][0];


        }




        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    b.Append(_graphBuildingArray[x][y]);
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
