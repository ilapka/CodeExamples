using Codebase.UI.Base;
using Codebase.UI.Interfaces;
using Codebase.UI.Screens.Loading;
using Codebase.UI.TransferArgs;

namespace Codebase.Services.UI
{
    public class UiFacade : IUiFacade
    {
        private readonly IUiManagersRegistry _uiRegistry;
        
        public BaseScreen CurrentScreen => _uiRegistry.ScreensManager.CurrentScreen;
        public BaseWindow CurrentWindow => _uiRegistry.WindowsManager.CurrentWindow;
        public SystemMessageBox CurrentMessageBox => _uiRegistry.MessageBoxesManager.CurrentMessageBox;
        public BaseScreenBlocker CurrentBlocker => _uiRegistry.BlockersManager.CurrentBlocker;

        public UiFacade(IUiManagersRegistry uiRegistry)
        {
            _uiRegistry = uiRegistry;
        }
        
        public void SetInitialScreen<T>() where T : BaseScreen => _uiRegistry.ScreensManager.SetInitialScreen(typeof(T));
        public void OpenScreen<T>(ITransferArgs args = null) where T : BaseScreen => _uiRegistry.ScreensManager.OpenScreen(typeof(T), args);
        public bool TryBackToPreviousScreen() => _uiRegistry.ScreensManager.TryBackToPreviousScreen();
        
        public void OpenWindow<T>(ITransferArgs args = null) where T : BaseWindow => _uiRegistry.WindowsManager.OpenWindow(typeof(T), args);
        public void CloseCurrentWindow() => _uiRegistry.WindowsManager.CloseCurrentWindow();

        public void OpenLoadingScreen() => _uiRegistry.LoadingScreensManager.OpenLoadingScreen(typeof(LoadingSceneScreen));
        public void CloseLoadingScreen() => _uiRegistry.LoadingScreensManager.CloseCurrentLoadingScreen();
        public void SetLoadingScreenProgress(ProgressData data) => _uiRegistry.LoadingScreensManager.SetProgress(data);
        
        public void OpenMessageBox(ISystemMessage message) => _uiRegistry.MessageBoxesManager.EnqueueMessage(message);
        public void CloseCurrentMessageBox() => _uiRegistry.MessageBoxesManager.CloseCurrentMessageBox();
        
        public void OpenElement<T>(ITransferArgs args = null) where T : SwitchableElement => _uiRegistry.SwitchableElementsManager.OpenElement(typeof(T), args);
        public void CloseElement<T>(ITransferArgs args = null) where T : SwitchableElement => _uiRegistry.SwitchableElementsManager.CloseElement(typeof(T));
        
        public void OpenScreenBlocker<T>(ITransferArgs args) where T : BaseScreenBlocker => _uiRegistry.BlockersManager.OpenScreenBlocker(typeof(T), args);
        public void CloseCurrentBlocker() => _uiRegistry.BlockersManager.CloseCurrentBlocker();
    }
}