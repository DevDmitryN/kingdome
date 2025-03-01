using Main.Scripts.Gameplay.Features.GameResources.Config;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.UI;
using UnityEngine.Serialization;
using Zenject;

namespace Main.Scripts.Gameplay.Installers
{
    public class GameResourcesInstaller : MonoInstaller
    {
        public UIGameResourceList UIGameResourceList;
        public UIGameResourceListItem UIResourceItemPrefab;
        [FormerlySerializedAs("GameResourceControllerConfig")] public GameResourcesConfig gameResourcesConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<GameResourcesConfig>()
                .FromInstance(gameResourcesConfig)
                .AsSingle();
            
            Container.Bind<GameResourceController>()
                .AsSingle();
            
            Container.Bind<UIGameResourceListItem>()
                .FromInstance(UIResourceItemPrefab)
                .AsSingle();
            
            Container.Bind<UIGameResourceList>()
                .FromInstance(UIGameResourceList)
                .AsSingle();
        }
    }
}