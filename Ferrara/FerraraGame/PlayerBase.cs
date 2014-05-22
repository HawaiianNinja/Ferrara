namespace FerraraGame
{
    internal class PlayerBase : GameEntity
    {
        public PlayerBase(Cell target, Player owner)
            : base(owner, target)
        {
        }

        public override void Update()
        {
        }
    }
}