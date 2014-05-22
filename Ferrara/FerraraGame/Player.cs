namespace FerraraGame
{
    internal class Player
    {
        public Cell SpawnCell;

        public Player(Cell spawnCell)
        {
            SpawnCell = spawnCell;
        }

        public int Coins { get; set; }
    }
}