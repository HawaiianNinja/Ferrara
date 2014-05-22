using System.Collections.ObjectModel;
using System.Linq;

namespace FerraraGame
{
    class Soldier : GameEntity
    {
        
        public Soldier(Cell spawnCell, Cell targetCell, Player _leftPlayer) : base(spawnCell, targetCell, _leftPlayer)
        {
            _attackRadius = 1;
            _route = new AStarRoute(spawnCell, targetCell);
            _health = 10;
            _reward = 10;
            _attackDamage = 5;
        }

        public override void Update(){
            //check for dudes
            var neighbors = CurrentCell.CellsWithinRadius(CurrentCell, _attackRadius);
            var nearbyEnemies = new Collection<GameEntity>();

            foreach (var e in from neighbor in neighbors from e in neighbor.GameEntities where !e._owner.Equals(_owner) select e)
            {
                nearbyEnemies.Add(e);
            }

            //if dudes
            if (nearbyEnemies.Count > 0)
            {
                var toAttack = nearbyEnemies[0];
                toAttack.TakeDamage(_attackDamage);
            }
            else
            {
                //if no dudes
                if (!CurrentCell.Equals(_targetCell))
                {
                    MoveEntity(_route.GetNextCell());
                }
            }

        }
    }

    
}
