using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
    [CreateAssetMenu(menuName = "SkilledIn/Create ApplicationSettingsInstaller", fileName = "ApplicationSettingsInstaller", order = 0)]
    public class ApplicationSettingsInstaller : ScriptableObjectInstaller<ApplicationSettingsInstaller>
    {
        // [SerializeField]
        // private ApplicationSettings _settings;
        //
        // public override void InstallBindings()
        // {
        //     Container.BindInstance(_settings).IfNotBound();
        // }
    }
}