using System.Collections.ObjectModel;
using System.Linq;

namespace FerraraGame
{
    internal class Soldier : GameEntity
    {
        public Soldier(Player owner, Cell targetCell) : base(owner, targetCell)
        {
            AttackRadius = 2;
            Route = new AStarRoute(CurrentCell, TargetCell);
            Health = 10;
            Reward = 10;
            AttackDamage = 5;
        }

        public override void Update()
        {
            //check for dudes

            var neighbors = CurrentCell.CellsWithinRadius(CurrentCell, AttackRadius);
            var nearbyEnemies = new Collection<GameEntity>();

            foreach (
                var e in
                    from neighbor in neighbors from e in neighbor.GameEntities where !e.Owner.Equals(Owner) select e)
            {
                nearbyEnemies.Add(e);
            }

            //if dudes
            if (nearbyEnemies.Count > 0)
            {
                var toAttack = nearbyEnemies[0];
                toAttack.TakeDamage(AttackDamage);
            }
            else
            {
                //if no dudes
                if (!CurrentCell.Equals(TargetCell))
                {
                    MoveEntity(Route.GetNextCell());
                }
            }
        }
    }
}