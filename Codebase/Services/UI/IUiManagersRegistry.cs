using Codebase.UI.Managers;

namespace Codebase.Services.UI
{
    public interface IUiManagersRegistry
    {
        ScreensManager ScreensManager { get; }
        WindowsManager WindowsManager { get; }
        LoadingScreensManager LoadingScreensManager { get; }
        MessageBoxesManager MessageBoxesManager { get; }
        SwitchableElementsManager SwitchableElementsManager { get; }
        BlockersManager BlockersManager { get; }
        
        void Register(LoadingScreensManager manager);
        void Unregister(LoadingScreensManager manager);
        void Register(ScreensManager manager);
        void Unregister(ScreensManager manager);
        void Register(WindowsManager manager);
        void Unregister(WindowsManager manager);
        void Register(MessageBoxesManager manager);
        void Unregister(MessageBoxesManager manager);
        void Register(SwitchableElementsManager manager);
        void Unregister(SwitchableElementsManager manager);
        void Register(BlockersManager manager);
        void Unregister(BlockersManager manager);
    }
}