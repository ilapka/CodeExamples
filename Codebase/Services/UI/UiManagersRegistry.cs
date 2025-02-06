using Codebase.UI.Managers;

namespace Codebase.Services.UI
{
    public class UiManagersRegistry : IUiManagersRegistry
    {
        public ScreensManager ScreensManager { get; private set; }
        public WindowsManager WindowsManager { get; private set; }
        public LoadingScreensManager LoadingScreensManager { get; private set; }
        public MessageBoxesManager MessageBoxesManager { get; private set; }
        public SwitchableElementsManager SwitchableElementsManager { get; private set; }
        public BlockersManager BlockersManager { get; private set; }
        
        public void Register(ScreensManager manager) => ScreensManager = manager;
        public void Unregister(ScreensManager manager) => ScreensManager = null;
        public void Register(WindowsManager manager) => WindowsManager = manager;
        public void Unregister(WindowsManager manager) => WindowsManager = null;
        public void Register(LoadingScreensManager manager) => LoadingScreensManager = manager;
        public void Unregister(LoadingScreensManager manager) => LoadingScreensManager = null;
        public void Register(MessageBoxesManager manager) => MessageBoxesManager = manager;
        public void Unregister(MessageBoxesManager manager) => MessageBoxesManager = null;
        public void Register(SwitchableElementsManager manager) => SwitchableElementsManager = manager;
        public void Unregister(SwitchableElementsManager manager) => SwitchableElementsManager = null;
        public void Register(BlockersManager manager) => BlockersManager = manager;
        public void Unregister(BlockersManager manager) => BlockersManager = null;
    }
}