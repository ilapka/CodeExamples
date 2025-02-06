using UnityEngine;

namespace Codebase.Services.ResourceManager
{
	public interface IResources
    {
        public T Load<T>(string path) where T : MonoBehaviour;
    }
}