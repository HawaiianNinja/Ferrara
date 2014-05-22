using System;
using System.Text;

namespace FerraraGame
{
    internal class CellGraph
    {
        private readonly int _maxX;
        private readonly int _maxY;

        private Cell[][] _graphBuildingArray;
        private Cell _rootCell;

        public CellGraph(int x, int y)
        {
            _maxX = x;
            _maxY = y;

            GenerateEmptyGraph();
        }


        public void GenerateEmptyGraph()
        {
            _graphBuildingArray = new Cell[_maxX][];

            for (var i = 0; i < _maxX; i++)
            {
                _graphBuildingArray[i] = new Cell[_maxY];
                for (var j = 0; j < _maxY; j++)
                {
                    _graphBuildingArray[i][j] = new Cell(new Position(i, j));
                }
            }

            for (var x = 0; x < _maxX; x++)
            {
                for (var y = 0; y < _maxY; y++)
                {
                    var c = _graphBuildingArray[x][y];

                    //iterate over all 8 cells around x,y
                    for (var i = x - 1; (i <= x + 1); i++)
                    {
                        for (var j = y - 1; (j <= y + 1); j++)
                        {
                            var ti = Math.Min(Math.Abs(i), Math.Abs(_maxX - 1));
                            var tj = Math.Min(Math.Abs(j), Math.Abs(_maxY - 1));

                            var tentativeNeighborCell = _graphBuildingArray[ti][tj];

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

            _rootCell = _graphBuildingArray[_maxX/2][_maxY/2];
        }


        public override string ToString()
        {
            var b = new StringBuilder();
            for (var y = 0; y < _maxY; y++)
            {
                for (var x = 0; x < _maxX; x++)
                {
                    b.Append(_graphBuildingArray[x][y] + "\t");
                }
                b.Append("\n");
            }
            return b.ToString();
        }

        public Cell GetCellByPosition(Position p)
        {
            return _graphBuildingArray[p.X][p.Y];
            //return _rootCell.CellAtPosition(p);
        }
    }
}
