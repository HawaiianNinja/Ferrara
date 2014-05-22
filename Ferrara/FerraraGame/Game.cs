using System.Linq;
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


            _leftPlayer = new Player(_graph.GetCellByPosition(new Position(0, height / 2)));
            _rightPlayer = new Player(_graph.GetCellByPosition(new Position(width - 1,height/2)));


            _graph.GetCellByPosition(new Position(width/2, height/2)).Transversable = false;
            //_graph.GetCellByPosition(new Position(6, 5)).Transversable = false;
            //_graph.GetCellByPosition(new Position(1, 1)).Transversable = false;


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
