﻿using System.Collections.ObjectModel;
using System.Linq;

namespace FerraraGame
{
    internal class Game
    {
        private readonly CellGraph _graph;
        private readonly Player _leftPlayer;
        private readonly Player _rightPlayer;


        private Collection<GameEntity> _gameEntities = new Collection<GameEntity>();


        public Game(int width, int height)
        {
            _graph = new CellGraph(width, height);


            _leftPlayer = new Player(_graph.GetCellByPosition(new Position(0, height/2)));
            _rightPlayer = new Player(_graph.GetCellByPosition(new Position(width - 1, height/2)));


            _graph.GetCellByPosition(new Position(width/2, height/2)).Transversable = false;
            //_graph.GetCellByPosition(new Position(6, 5)).Transversable = false;
            //_graph.GetCellByPosition(new Position(1, 1)).Transversable = false;
        }

        public void AddLeftSoilder()
        {
            var leftSolider = new Soldier(_leftPlayer, _rightPlayer.SpawnCell);
            _gameEntities.Add(leftSolider);
        }

        public void AddRightSoilder()
        {
            var rightSolider = new Soldier(_rightPlayer, _leftPlayer.SpawnCell);
            _gameEntities.Add(rightSolider);
        }

        public void Update()
        {
            foreach (var e in _gameEntities)
            {
                e.Update();
            }

            foreach (var gameEntity in _gameEntities.Where(gameEntity => gameEntity.IsDead()))
            {
                gameEntity.RemoveFromGraph();
            }
            _gameEntities = new Collection<GameEntity>(_gameEntities.Where(o => !o.IsDead()).ToList());
        }

        public override string ToString()
        {
            return _graph.ToString();
        }
    }
}
