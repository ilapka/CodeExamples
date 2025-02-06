using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Services.ResourceManager
{
    public class ResourceManager : IResources
    {
        private readonly Dictionary<string, GameObject> _cash = new Dictionary<string, GameObject>();
        
        public T Load<T>(string path) where T : MonoBehaviour
        {
            if (_cash.ContainsKey(path))
            {
                return _cash[path].GetComponent<T>();
            }

            T prefab = Resources.Load<T>(path);

            if (prefab != null)
            {
                _cash.Add(path, prefab.gameObject);
                return prefab;    
            }

            Debug.LogError($"Can't load {typeof(T)} by path {path}");
            return null;
        }
    }
}