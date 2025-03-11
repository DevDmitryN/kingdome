using System;
using Main.Scripts.Gameplay.Features.Enemy.Config;
using Main.Scripts.Gameplay.Features.Enemy.Strategy;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.Enemy.Models
{
    public class EnemyMono : MonoBehaviour
    {
        [Inject] private EnemyUnitConfig _config;
        [Inject] private IEnemyStrategy _strategy;

        private void Awake()
        {
            
        }
    }
}