namespace FerraraGame
{
    internal class PlayerBase : GameEntity
    {
        public PlayerBase(Cell cell1, Cell cell2, Player _leftPlayer)
            : base(_leftPlayer, cell2)
        {
        }

        public override void Update()
        {
        }
    }
}