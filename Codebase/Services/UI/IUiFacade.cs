using Codebase.UI.Base;
using Codebase.UI.Interfaces;
using Codebase.UI.TransferArgs;

namespace Codebase.Services.UI
{
    public interface IUiFacade
    {
        BaseScreen CurrentScreen { get; }
        BaseWindow CurrentWindow { get; }
        SystemMessageBox CurrentMessageBox { get; }
        BaseScreenBlocker CurrentBlocker { get; }
        
        void SetInitialScreen<T>() where T : BaseScreen;
        void OpenScreen<T>(ITransferArgs args = null) where T : BaseScreen;
        bool TryBackToPreviousScreen();

        void OpenWindow<T>(ITransferArgs args = null) where T : BaseWindow;
        void CloseCurrentWindow();

        void OpenLoadingScreen();
        void CloseLoadingScreen();
        void SetLoadingScreenProgress(ProgressData data);

        void OpenMessageBox(ISystemMessage message);
        void CloseCurrentMessageBox();
        
        void OpenElement<T>(ITransferArgs args = null) where T : SwitchableElement;
        void CloseElement<T>(ITransferArgs args = null) where T : SwitchableElement;
        
        void OpenScreenBlocker<T>(ITransferArgs args) where T : BaseScreenBlocker;
        void CloseCurrentBlocker();
    }
}