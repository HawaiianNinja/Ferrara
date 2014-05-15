using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Player
    {
        public int Coins { get; set; }
        public int PosX;
        public PlayerBase Base { get; set; }

        public Collection<GameEntity> Pieces { get; set; }

        public Player(PlayerBase playerBase, int direction)
        {
            Base = playerBase;
            Pieces = new Collection<GameEntity>();
            PosX = direction;
        }



        internal void Update(GameEntity[][] board)
        {
            foreach (var entity in Pieces){
                entity.Update(board);
            }
        }
    }
}
