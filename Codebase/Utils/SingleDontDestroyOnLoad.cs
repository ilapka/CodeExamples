using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Codebase.Utils
{
    /// <summary>
    /// <para> Allows you to use DontDestoroyOnLoad and ensure that if a GameObject with the same component and the same name is created, it will be destroyed. </para>
    /// <para> The execution order should be higher than all scripts but lower than architectural components (such as Zenject). </para>
    /// </summary>
    [DefaultExecutionOrder(-500)]
    public class SingleDontDestroyOnLoad : MonoBehaviour
    {
        private static List<SingleDontDestroyOnLoad> _singleInstances = new();

        public string InstanceName => gameObject.name;

        private void Awake()
        {
            SingleDontDestroyOnLoad instanceWithMyName = _singleInstances.FirstOrDefault(instance =>
                    instance.InstanceName == InstanceName);
            
            if (instanceWithMyName != null && instanceWithMyName != this)
            {
                gameObject.SetActive(false);
                Destroy(gameObject); 
            }
            else
            {
                _singleInstances.Add(this);
                DontDestroyOnLoad(gameObject); 
            }
        }
    }
}