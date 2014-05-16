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

        public Cell SpawnCell;

        public Player(Cell spawnCell)
        {
            SpawnCell = spawnCell;
        }
    }
}
