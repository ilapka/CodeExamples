namespace Codebase.Infrastructure.StateMachine
{
    public class RestartApplicationState : ApplicationState
    {
        private readonly SceneLoader _sceneLoader;
        
        public RestartApplicationState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter(IStateArgs args = null)
        {
            if (_sceneLoader.CurrentScene != Scenes.Initial)
            {
                _sceneLoader.Load(Scenes.Initial, onLoaded: LoadMainMenu);
            }
            else
            {
                LoadMainMenu();
            }
        }

        private void LoadMainMenu()
        {
            AppStateMachine.Enter<LoadMainMenuState>();
        }
        
        public override void Exit()
        {
            
        }
    }
}