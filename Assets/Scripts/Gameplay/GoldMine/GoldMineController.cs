using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Extensions;
using Extensions.Spawner;
using Gameplay.GoldMine.Config;
using Gameplay.Installers.Tokens;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.GoldMine
{
    public class GoldMineController : IDisposable
    {
        [Inject(Id = SpawnerType.GoldMine)]
        private ISpawner<GoldMineGO> _spawner;
        private readonly GoldMineControllerConfig _config;
        private readonly List<GoldMineGO> _mines = new ();
        private Subject<Unit> _onDestroy = new();
        
        public GoldMineController(GoldMineControllerConfig config)
        {
            _config = config;
        }

        private GoldMineGO Spawn()
        {
            var position = RandomExtension.GenerateRandomCoordinates(_config.CenterPosition, _config.MinRadiusSpawn,_config.MaxRadiusSpawn);
            var mine = _spawner.Spawn(position);
            mine.OnEnded
                .First()
                .TakeUntil(_onDestroy)
                .Subscribe(value =>
                {
                    _spawner.Hide(mine);
                });
            return mine;
        }

        public void Dispose()
        {
            _onDestroy.OnNext(Unit.Default);
            _onDestroy.OnCompleted();
            _onDestroy.Dispose();
        }

        public void Init()
        {
            for (int i = 0; i < _config.StartSpawn; i++)
            {
                _mines.Add(Spawn());
            }
        }

        public List<IExtractable> GetMines()
        {
            return new List<IExtractable>(_mines);
        }
        
    }
}