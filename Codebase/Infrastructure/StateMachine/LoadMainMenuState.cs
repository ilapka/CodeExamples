using Codebase.Services.UI;

namespace Codebase.Infrastructure.StateMachine
{
    public class LoadMainMenuState : ApplicationState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IUiFacade _uiFacade;

        public LoadMainMenuState(SceneLoader sceneLoader, IUiFacade uiFacade)
        {
            _sceneLoader = sceneLoader;
            _uiFacade = uiFacade;
        }

        public override void Enter(IStateArgs args = null)
        {
            _uiFacade.OpenLoadingScreen();
            
            if (_sceneLoader.CurrentScene != Scenes.MainMenu)
            {
                _sceneLoader.Load(Scenes.MainMenu, onLoaded: EnterMainMenu);
            }
            else
            {
                EnterMainMenu();
            }
        }
        
        private void EnterMainMenu()
        {
            AppStateMachine.Enter<MainMenuState>();
            _uiFacade.CloseLoadingScreen();
        }

        public override void Exit()
        {
            
        }
    }
}