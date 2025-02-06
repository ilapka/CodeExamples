using Codebase.Services.UI;
using Codebase.UI.Screens.MainMenu;

namespace Codebase.Infrastructure.StateMachine
{
    public class MainMenuState : ApplicationState
    {
        private readonly IUiFacade _uiFacade;
        
        public MainMenuState(IUiFacade uiFacade)
        {
            _uiFacade = uiFacade;
        }

        public override void Enter(IStateArgs args = null)
        {
            _uiFacade.SetInitialScreen<MainMenuScreen>();
            _uiFacade.OpenScreen<MainMenuScreen>();
        }

        public override void Exit()
        {
            
        }
    }
}