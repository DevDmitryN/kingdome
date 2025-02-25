using Main.Scripts.Gameplay.Features.GameResources.Config;
using Main.Scripts.Gameplay.Features.GameResources.Controller;
using Main.Scripts.Gameplay.Features.GameResources.UI;
using Zenject;

namespace Main.Scripts.Gameplay.Installers
{
    public class GameResourcesInstaller : MonoInstaller
    {
        public UIGameResourceListItem UIResourceItemPrefab;
        public GameResourceControllerConfig GameResourceControllerConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<GameResourceControllerConfig>()
                .FromInstance(GameResourceControllerConfig)
                .AsSingle();

            // Container.InstantiatePrefab(UIResourceItemPrefab);

            Container.Bind<UIGameResourceListItem>()
                .FromInstance(UIResourceItemPrefab)
                .AsSingle();
            
            Container.Bind<GameResourceController>()
                .AsSingle();
            Container.Bind<UIGameResourceList>()
                .AsSingle();
        }
    }
}