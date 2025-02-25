using Main.Scripts.Gameplay.Features.GameResources.Config;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Gameplay.Features.GameResources.Controller
{
    public class GameResourceController
    {
        [Inject]
        private readonly GameResourceControllerConfig _config;

        public void Init()
        {
            Debug.Log(_config);
        }
    }
}