using Codebase.Infrastructure.StateMachine;
using Codebase.Services.ErrorService;
using Codebase.Services.ResourceManager;
using Codebase.Services.UI;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
    public class ApplicationInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField]
        private ApplicationQuitDetector _quitDetector;
        
        public override void InstallBindings()
        {
            BindInfrastructure();
            BindServices();
        }

        private void BindInfrastructure()
        {
            Container.Bind<DIFactory>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<ApplicationBootstrapper>().AsSingle();
            Container.Bind<IApplicationStateMachine>().To<ApplicationStateMachine>().AsSingle();
            Container.Bind<IRestartApplicationService>().To<RestartApplicationService>().AsSingle();
            Container.Bind<IQuitApplicationService>().To<QuitApplicationService>().AsSingle();
            Container.BindInstance(_quitDetector).AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<IResources>().To<ResourceManager>().AsSingle();
            Container.Bind<IUiManagersRegistry>().To<UiManagersRegistry>().AsSingle();
            Container.Bind<IUiFacade>().To<UiFacade>().AsSingle();
            Container.Bind<IErrorHandler>().To<ErrorHandler>().AsSingle();
            

            // Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            // Container.BindInterfacesTo<SaveLoadService>().AsSingle();
            // Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            //Container.BindInterfacesTo<InputService>().AsSingle();
        }

        public bool IsAlive() => this != null;
    }
}
