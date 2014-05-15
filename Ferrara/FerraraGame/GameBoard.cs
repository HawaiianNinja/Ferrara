using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class GameBoard
    {
        private const int boardSizeX = 20;
        private const int boardSizeY = 20;
        // 0,0 is bottom left

        private GameEntity[][] board;

        private Player player1;

        public GameBoard()
        {
            board = new GameEntity[boardSizeX][];
            for (int i = 0; i < boardSizeX; i++)
            {
                board[i] = new GameEntity[boardSizeY];
            }
            var base1 = new PlayerBase(new Position(0,boardSizeY/2),1);
             player1 = new Player(base1, 1);
            board[0][boardSizeY / 2] = base1;

            var base2 = new PlayerBase(new Position(boardSizeX-1, boardSizeY/2),-1);
            Player player2 = new Player(base2, -1);
            board[boardSizeX - 1][boardSizeY / 2] = base2;

            var solider1 = new Soldier(player1.Base.CurrentPostion.Add(new Position(player1.PosX, 0)), 
                player1.PosX);
            player1.Pieces.Add(solider1);
            board[solider1.CurrentPostion.X][solider1.CurrentPostion.Y] = solider1;
        }

        public void Update()
        {
            player1.Update(board);
        }

        public override String ToString(){
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < boardSizeX; i++) {
                for (int j = 0; j < boardSizeY; j++)
                {
                    b.Append(board[i][j] == null ? "0" : board[i][j].ToString());
                }
                b.Append("\n");
            }
                return b.ToString();
        }

    }
}
