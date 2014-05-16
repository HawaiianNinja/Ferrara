using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FerraraGame
{
    class Game
    {
        private Player _leftPlayer;
        private Player _rightPlayer;


        private CellGraph _graph;

        private Collection<GameEntity> _gameEntities = new Collection<GameEntity>();


        public Game(int width, int height)
        {
            _graph = new CellGraph(width, height);
            _leftPlayer = new Player(_graph.GetCellByPosition(new Position(0,height/2)));
            _rightPlayer = new Player(_graph.GetCellByPosition(new Position(width - 1,height/2)));

            AddLeftSoilder();
            AddRightSoilder();
            
        }

        public void AddLeftSoilder()
        {
            var leftSolider = new Soldier(_leftPlayer.SpawnCell, _rightPlayer.SpawnCell, _leftPlayer);
            _gameEntities.Add(leftSolider);
        }

        public void AddRightSoilder()
        {
            var rightSolider = new Soldier(_rightPlayer.SpawnCell, _leftPlayer.SpawnCell, _rightPlayer);
            _gameEntities.Add(rightSolider);
        }

        public void Update()
        {

            foreach(var e in _gameEntities)
            {
                e.Update();
            }


        }

        public override string ToString()
        {
            return _graph.ToString();
        }


    }
}
