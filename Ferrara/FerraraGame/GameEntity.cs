using System;

namespace FerraraGame
{
    internal abstract class GameEntity
    {
        protected int AttackDamage;
        protected int AttackRadius;
        public Cell CurrentCell;
        protected int Health;
        public Player Owner;
        protected int Reward;
        protected Route Route;
        protected Cell TargetCell;

        protected GameEntity(Player owner, Cell targetCell)
        {
            Owner = owner;
            CurrentCell = Owner.SpawnCell;
            TargetCell = targetCell;

            CurrentCell.GameEntities.Add(this);
        }


        public void MoveEntity(Cell targetCell)
        {
            CurrentCell.GameEntities.Remove(this);
            targetCell.GameEntities.Add(this);
            CurrentCell = targetCell;
        }


        public abstract void Update();

        public override String ToString()
        {
            return "["+Health + " " + Owner.SpawnCell.Position.X+"]";
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }

        public void RemoveFromGraph()
        {
            CurrentCell.GameEntities.Remove(this);
        }
    }
}