using Main.Scripts.Gameplay.Features.WorkerAcceptor;
using UnityEngine;
using Zenject;


namespace Main.Scripts.Gameplay.Features.Building
{
    public class BuildingMono : MonoBehaviour 
    {
        [Inject] private BuildingConfig _config;
        [Inject] private IWorkerAcceptor _workerAcceptor;
        //[Inject] private IBuildStrategy _strategy;
        [SerializeField] private SpriteRenderer _sprite;

        public BuildingConfig Config => _config;
        public IWorkerAcceptor WorkerAcceptor => _workerAcceptor;


        private void Awake()
        {
            _sprite.sprite = _config.Sprite;
        }
    }
}