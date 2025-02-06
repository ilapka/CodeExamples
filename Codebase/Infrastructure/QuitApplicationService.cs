using Codebase.Infrastructure.StateMachine;
using Codebase.Services.UI;
using Codebase.UI.TransferArgs;
using UnityEditor;

namespace Codebase.Infrastructure
{
    public class QuitApplicationService : IQuitApplicationService
    {
        private readonly IApplicationStateMachine _appStateMachine;
        private readonly IUiFacade _uiFacade;
        private readonly IRestartApplicationService _restartApplicationService;
        
        private bool _isExitMessageOpened;

        public QuitApplicationService(
            IApplicationStateMachine appStateMachine,
            IUiFacade uiFacade,
            IRestartApplicationService restartApplicationService)
        {
            _appStateMachine = appStateMachine;
            _uiFacade = uiFacade;
            _restartApplicationService = restartApplicationService;
        }
        
        public void ShowExitConfirmation()
        {
            if (_isExitMessageOpened)
                return;
            
            _isExitMessageOpened = true;

            ChooseMessage message = new ChooseMessage(
                "Exit",
                "Do you want to leave game?",
                YesCallback, 
                NoCallback);
                        
            _uiFacade.OpenMessageBox(message);
        }
        
        private void YesCallback()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false; 
#else
            Application.Quit(); 
#endif
            _isExitMessageOpened = false;
        }
        
        private void NoCallback()
        {
            _isExitMessageOpened = false;
        }
    }
}