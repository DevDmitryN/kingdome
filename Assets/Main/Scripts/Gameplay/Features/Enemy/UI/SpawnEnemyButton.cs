using System;
using System.Linq;
using Main.Scripts.Gameplay.Features.Enemy.Factory;
using Main.Scripts.Gameplay.Features.Enemy.Installer;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Enemy.UI
{
    public class SpawnEnemyButton : MonoBehaviour
    {
        private EnemyConfigs _enemyConfigs;
        private IEnemyFactory _enemyFactory;
        
        [SerializeField] private Vector3 _position;
        [SerializeField] private Button _button;

        [Inject]
        public void Construct(EnemyConfigs enemyConfigs, IEnemyFactory enemyFactory)
        {
            _enemyConfigs = enemyConfigs;
            _enemyFactory = enemyFactory;
        }
        private void OnEnable()
        {
            _button.OnClickAsObservable()
                .TakeUntilDisable(this)
                .Subscribe(value => Spawn());
        }

        private void Spawn()
        {
            var enemyMono = _enemyFactory.Create(_position,_enemyConfigs.EnemyUnitConfigs.First());
            
        }
    }
}